using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class BasicActionsInputs : MonoBehaviour
{
    public Vector2 move;
    public bool shoot;
    public bool switchAmmo;

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnShoot(InputValue value)
    {
        shoot = value.isPressed;
    }

    public void OnSwitchAmmo(InputValue value)
    {
        switchAmmo = value.isPressed;
    }

}
