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
        internal float movementSpeed;
        SpriteRenderer spriteRenderer;
        public float Pause { get; set; }

        public Bounds Bounds => _collider.bounds;

        void Start()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            movementSpeed = .5f;
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

                var directionToPlayer = CalculateDirectionToPlayer(playerTransform);
                var movementTowardsPlayer = directionToPlayer * (movementSpeed * Time.deltaTime);

                if (movementSpeed < MAX_WITCH_SPEED)
                {
                    movementSpeed += movementSpeed * Time.deltaTime;
                }

                gameObject.transform.position = movementTowardsPlayer + gameObject.transform.position;
            } else {
                Pause -= Time.deltaTime;
            }
        }

        public void ResetMovementSpeed(){
            movementSpeed = .5f;
        }

        private Vector3 CalculateDirectionToPlayer(Transform playerTransform){
            var direction =  playerTransform.position - gameObject.transform.position;
            direction.Normalize();
            return direction;
        }
    }
}