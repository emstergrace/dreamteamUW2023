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
    public static int followDistance = 50;
    private List<Vector3> storedPositions;
    internal Collider2D _collider;
    internal AudioSource _audio;
    SpriteRenderer spriteRenderer;

    public Bounds Bounds => _collider.bounds;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        storedPositions = new List<Vector3>(); 
        isCollected = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            var ev = Schedule<PlayerChildCollision>();
            ev.player = player;
            ev.child = this;
        }
    }

    void Update()
    {
        if (isCollected){
            storedPositions.Add(player.transform.position);

            if(storedPositions.Count > (followDistance * (childOrder+1)))
            {
                gameObject.transform.position = storedPositions[0]; //move the player
                storedPositions.RemoveAt (0); //delete the position that player just move to
            }
        }
    }

    public void CaughtByWitch(){
        Destroy(gameObject);
    }
}
