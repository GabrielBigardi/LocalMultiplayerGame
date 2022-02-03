using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInputActions _playerInputActions;
    public InputAction _movement;

    public Vector2 mov;
    public bool shoot;
    public bool jump;

    public bool holdingSpace;
    public bool holdingRun;

    private void Awake()
    {
        //_playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        //_movement = _playerInputActions.Player.Movement;
        //_movement.Enable();

        //_playerInputActions.Player.Shoot.performed += ctx => shoot = true;
        //_playerInputActions.Player.Shoot.canceled += ctx => shoot = false;
        //
        ////_playerInputActions.Player.Join.performed += OnJoin;
        //
        //_playerInputActions.Player.Shoot.Enable();
        //_playerInputActions.Player.Jump.Enable();
        //_playerInputActions.Player.Join.Enable();
    }

    private void OnDisable()
    {
        //_movement.Disable();
        //_playerInputActions.Player.Shoot.Disable();
    }

    private void Update()
    {
        //mov = _movement.ReadValue<Vector2>();
    }

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
}
