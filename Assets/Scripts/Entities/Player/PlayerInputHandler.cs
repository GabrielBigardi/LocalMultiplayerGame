using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 mov;
    public bool shoot;
    public bool jump;

    public bool holdingSpace;
    public bool holdingRun;

    public void OnMovement(InputAction.CallbackContext ctx)
    {
        mov = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            jump = true;
            holdingSpace = true;
        }

        if (ctx.canceled)
        {
            holdingSpace = false;
        }
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            shoot = true;
        }

        if (ctx.canceled)
        {
            shoot = false;
        }
    }

    public void OnRun(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            holdingRun = true;
        }

        if (ctx.canceled)
        {
            holdingRun = false;
        }
    }

    public void TestInput(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>().x);
    }
}
