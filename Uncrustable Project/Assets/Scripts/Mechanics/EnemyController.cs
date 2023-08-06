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
        private static float MAX_WITCH_SPEED = 4.2f;
        private static float WITCH_PAUSE_TIME = 3f;
        public AudioClip ouch;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        internal float movementRight = 1f;
        SpriteRenderer spriteRenderer;
        public float Pause {get; set;}

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            movementRight = .5f;
            Pause = WITCH_PAUSE_TIME;
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
            if (Pause <= 0f){
                var playerTransform = GameObject.FindWithTag("Player").transform;

                var currentX = transform.position.x;
                var nextX = currentX + (movementRight * Time.deltaTime);

                if (movementRight < MAX_WITCH_SPEED)
                {
                    movementRight += movementRight * Time.deltaTime;
                }

                transform.position = new Vector3(nextX, playerTransform.position.y, transform.position.z);
            } else {
                Pause -= Time.deltaTime;
            }
        }

        public void ResetMovementSpeed(){
            movementRight = .5f;
        }
    }
}