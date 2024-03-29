using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace sks.IO {
    public class InputManager : MonoBehaviour {
        void Start() {
            ControlActions controlActions = new ControlActions();
            controlActions.Enable();
            controlActions.Player.Left.performed += MoveLeft;
            controlActions.Player.Right.performed += MoveRight;
        }
        void MoveLeft(InputAction.CallbackContext obj) {
            Events.InvokePlayerMoveLeft();
        }
        void MoveRight(InputAction.CallbackContext obj) {
            Events.InvokePlayerMoveRight();
        }
    }
}


