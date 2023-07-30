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
    public GameObject leader {get; set;}
    public GameObject follower {get; set;}
    public int followDistance;
    public int orderOfChildInLine;
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
        
        followDistance = 100;
        orderOfChildInLine = 0;
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
            if (follower != null){
                storedPositions.Add(transform.position);

                if(storedPositions.Count > followDistance)
                {
                    follower.transform.position = storedPositions[0]; //move the player
                    storedPositions.RemoveAt (0); //delete the position that player just move to
                }
            }
        }
    }
}
