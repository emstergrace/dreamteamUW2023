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
    public static int followDistance = 40;
    private Queue<Vector3> storedPositions;
    internal Collider2D _collider;
    internal AudioSource _audio;
    SpriteRenderer spriteRenderer;
    internal Vector3 currentDestination;
    internal float moveSpeed = 200f;

    [SerializeField]
    public int childPointValue;

    public Bounds Bounds => _collider.bounds;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        storedPositions = new Queue<Vector3>(); 
        isCollected = false;
        currentDestination = transform.position;
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

    void Update()
    {
        if (isCollected){
            CollectedFollow();
        }
    }

    private void CollectedFollow(){
        storedPositions.Enqueue(player.transform.position);

        if(storedPositions.Count > (followDistance * (childOrder+1)))
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, moveSpeed * Time.deltaTime);
            if (transform.position == currentDestination){
                currentDestination = storedPositions.Dequeue();
            }
        }
    }

    public void CaughtByWitch(){
        AudioSource.PlayClipAtPoint(scream, transform.position);
        Destroy(gameObject);
    }
}
