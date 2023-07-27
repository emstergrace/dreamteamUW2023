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
    internal Collider2D _collider;
    internal AudioSource _audio;
    SpriteRenderer spriteRenderer;

    public Bounds Bounds => _collider.bounds;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            
        }
    }
}
