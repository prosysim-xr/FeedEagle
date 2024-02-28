using sks.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sks {

    public class FlyEagles : MonoBehaviour {
        /// <summary>
        /// This Script is used to make the eagles fly.
        /// It moves the eagle in the forward direction.
        /// Users can use arrow keys to change the direction of the eagle.
        /// </summary>
        
        public GameObject eagle;

        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;

        Vector3 originalEaglePos;

        Coroutine moveRightCoroutine;
        Coroutine moveLeftCoroutine;
        Quaternion target;

        // Start is called before the first frame update
        void Start() {
            eagle = gameObject;
            originalEaglePos = eagle.transform.position;
            Events.OnPlayerReposition += OnPlayerReposition;
            Events.OnPlayerMoveLeft += OnPlayerMoveLeft;
            Events.OnPlayerMoveRight += OnPlayerMoveRight;
        }

        // Update is called once per frame
        void Update() {
            eagle.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
        }
        void OnDestroy() {
            Events.OnPlayerReposition -= OnPlayerReposition;
            Events.OnPlayerMoveLeft -= OnPlayerMoveLeft;
            Events.OnPlayerMoveRight -= OnPlayerMoveRight;
        }

        void OnPlayerReposition() {
            eagle.transform.position = originalEaglePos;
        }
        private void OnPlayerMoveRight() {
            Debug.Log("Move Right called from fly eagles");

            if (moveRightCoroutine != null) {
                eagle.transform.rotation = Quaternion.Slerp(eagle.transform.rotation, target, 1);
                StopCoroutine(moveRightCoroutine);
                moveRightCoroutine = null;
            }
            moveRightCoroutine = StartCoroutine(CoroutineMoveRightSmoothly());
        }

        private void OnPlayerMoveLeft() {
            Debug.Log("Move Left called from fly eagles");

            if (moveLeftCoroutine != null) {
                eagle.transform.rotation = Quaternion.Slerp(eagle.transform.rotation, target, 1);
                StopCoroutine(moveLeftCoroutine);
                moveLeftCoroutine = null;
            }
            moveLeftCoroutine = StartCoroutine(CoroutineMoveLeftSmoothly());
        }

        
        IEnumerator CoroutineMoveRightSmoothly() {
            target = Quaternion.Euler(0, 90f, 0) * eagle.transform.rotation;
            float t = 0;
            while (t <= 1f) {
                yield return null;
                t += Time.deltaTime;
                Debug.Log("Move right coroutine");
                eagle.transform.rotation = Quaternion.Slerp(eagle.transform.rotation, target, t);
            }
        }
        IEnumerator CoroutineMoveLeftSmoothly() {
            target = Quaternion.Euler(0, -90f, 0) * eagle.transform.rotation;
            float t = 0;
            while (t <= 1f) {
                yield return null;
                t += Time.deltaTime;
                Debug.Log("Move right coroutine");
                eagle.transform.rotation = Quaternion.Slerp(eagle.transform.rotation, target, t);
            }
        }

    }
}
