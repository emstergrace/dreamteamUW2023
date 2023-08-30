using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using static Platformer.Core.Simulation;

[RequireComponent(typeof(Collider2D))]
public class ChildController : MonoBehaviour
{
    public bool isCollected {get; set;}
    public GameObject player {get; set;}
    public int childOrder {get; set;}
    public AudioClip scream;
    public static int followDistance = 10;
    private Queue<Vector3> storedPositions;
    internal Collider2D _collider;
    internal AudioSource _audio;
    private Vector3 _destination;
    private float _movementSpeed = 10f;

    [SerializeField]
    public int childPointValue;

    [SerializeField]
    public int loseChildPointValue;

    public Bounds Bounds => _collider.bounds;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        storedPositions = new Queue<Vector3>(); 
        isCollected = false;
        _destination = gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().AddScore(childPointValue);

            var ev = Schedule<PlayerChildCollision>();
            ev.player = player;
            ev.child = this;
        }
    }

    void FixedUpdate()
    {
        if (isCollected){
            storedPositions.Enqueue(player.transform.position);
            Debug.Log("Queue new position");

            if(storedPositions.Count > (followDistance * (childOrder+1)))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _destination, _movementSpeed * Time.deltaTime);

                if (gameObject.transform.position == _destination){
                    _destination = storedPositions.Dequeue();
                }
            }
        }
    }

    public void CaughtByWitch(){
        AudioSource.PlayClipAtPoint(scream, transform.position);
        Destroy(gameObject);
    }
}
