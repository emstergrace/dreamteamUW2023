using System;
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
        public AudioClip nomnomnom;
        public AudioClip childrenAreDelicious;
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
            WaitForPreyToRun();
        }

        void OnTriggerEnter2D(Collider2D collision) {
            var player = collision.gameObject.GetComponent<PlayerController>();
            var child = collision.gameObject.GetComponent<ChildController>();
            if (player != null)
            {
                Debug.Log("Player hit by witch");
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.witch = this;
            }

            if (child != null){
                Debug.Log("Player hit by witch");
                var ev = Schedule<ChildEnemyCollision>();
                ev.child = child;
                ev.witch = this;
            }
        }

        void Update()
        {
            if (Pause > 0f){
                Pause -= Time.deltaTime;
            }

            Act();
        }

        private void Act()
        {
            if (movementSpeed < MAX_WITCH_SPEED)
            {
                movementSpeed += movementSpeed * Time.deltaTime;
            }
            var targetPositionGameObject = CalculateClosestEdibleChild();

            var directionTowardTarget = CalculateDirectionToTarget(targetPositionGameObject.transform);
            var movementTowardsTarget = directionTowardTarget * (movementSpeed * Time.deltaTime);

            gameObject.transform.position = movementTowardsTarget + gameObject.transform.position;
        }

        public void ResetMovementSpeed(){
            movementSpeed = .5f;
        }

        public void WaitForPreyToRun(){
            Pause = WITCH_PAUSE_TIME;
        }

        private Vector3 CalculateDirectionToTarget(Transform targetTransform){
            return (targetTransform.position - gameObject.transform.position).normalized;
        }

        private GameObject CalculateClosestEdibleChild(){
            var childrenGameObjects = GameObject.FindGameObjectsWithTag("Child");
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");

            var lowestXValue = playerGameObject.transform.position.x;
            var lowestXValueObject = playerGameObject;

            foreach (var child in childrenGameObjects)
            {
                var childX = child.transform.position.x;
                if(childX < lowestXValue){
                    lowestXValue = childX;
                    lowestXValueObject = child;
                }
            }

            return lowestXValueObject;
        }
    }
}