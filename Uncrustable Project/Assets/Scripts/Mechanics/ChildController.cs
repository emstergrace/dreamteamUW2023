using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

[RequireComponent(typeof(Collider2D))]
public class ChildController : MonoBehaviour
{
    public bool isCollected {get; set;}
    public GameObject player {get; set;}
    public int childOrder {get; set;}
    public AudioClip scream;
    public static int followDistance = 5;
    private Queue<Vector3> storedPositions;
    internal Collider2D _collider;
    internal AudioSource _audio;
    private Vector3 _destination;
    private float _movementSpeed = 15f;
    private float _childOffset = 0.25f;

    [SerializeField]
    public int childPointValue;

    [SerializeField]
    public int loseChildPointValue;
    public bool isDoll = false;

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
            if (isDoll && childOrder != player.GetComponent<PlayerController>().childrenFollowing.Count){
                childOrder = player.GetComponent<PlayerController>().childrenFollowing.Count + 1;
            }

            var followPosition = new Vector3(player.transform.position.x, player.transform.position.y-_childOffset);
            storedPositions.Enqueue(followPosition);

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
        if (scream != null){
            AudioSource.PlayClipAtPoint(scream, transform.position);
        }
        
        Destroy(gameObject);
    }
}
