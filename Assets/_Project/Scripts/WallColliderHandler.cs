using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sks {
public class WallColliderHandler : MonoBehaviour
    {
        void OnTriggerEnter(Collider other) {
            if (other.transform.parent.GetComponent<FlyEagles>()) {
                Debug.Log("Player collided with wall");
                //Reset player position
                Events.PlayerReposition();
            }
        }
    }
}