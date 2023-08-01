using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public AudioClip ouch;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        internal float movementRight = 1f;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D collision) {
            var player = collision.gameObject.GetComponent<PlayerController>();
            var child = collision.gameObject.GetComponent<ChildController>();
            if (player != null)
            {
                Debug.Log("Player hit by witch");
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }

            if (child != null && child.isCollected){
                Debug.Log("Player hit by witch");
                var ev = Schedule<ChildEnemyCollision>();
                ev.child = child;
                ev.enemy = this;
            }
        }

        void Update()
        {
            var playerTransform = GameObject.FindWithTag("Player").transform;

            var current = transform.position.x;
            var next = current + (movementRight * Time.deltaTime);

            transform.position = new Vector3(next, playerTransform.position.y, transform.position.z);
        }

    }
}