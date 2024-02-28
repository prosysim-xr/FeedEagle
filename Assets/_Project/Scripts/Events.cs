using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static event Action OnPlayerReposition;
    public static void PlayerReposition() {
        OnPlayerReposition?.Invoke();
    }
    public static event Action OnPlayerMoveLeft;
    public static void InvokePlayerMoveLeft() => OnPlayerMoveLeft?.Invoke();

    public static event Action OnPlayerMoveRight;
    public static void InvokePlayerMoveRight() => OnPlayerMoveRight?.Invoke();
}
