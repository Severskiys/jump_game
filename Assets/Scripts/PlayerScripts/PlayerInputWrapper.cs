using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerInputWrapper : MonoBehaviour
{
    private PlayerInput _playerInput;

    private float _inputMoveDirection;

    public event UnityAction<float> IsMoved;
    public event UnityAction IsJump, 
                             IsFire;

    public event UnityAction IsNextMessegeSelected;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
    }

    private void OnEnable()
    {
        _playerInput.Player.Jump.started += OnJumpStarted;
        _playerInput.Player.Fire.started += OnFireStarted;
        _playerInput.Player.Move.started += OnMoveStartedCancled;
        _playerInput.Player.Move.canceled += OnMoveStartedCancled;
    }

    private void OnDisable()
    {
        _playerInput.Player.Jump.started -= OnJumpStarted;
        _playerInput.Player.Fire.started -= OnFireStarted;
        _playerInput.Player.Move.started -= OnMoveStartedCancled;
        _playerInput.Player.Move.canceled -= OnMoveStartedCancled;
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        IsJump?.Invoke();
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        IsFire?.Invoke();
    }

    private void OnMoveStartedCancled(InputAction.CallbackContext context)
    {
        _inputMoveDirection = context.ReadValue<float>();
        IsMoved?.Invoke(_inputMoveDirection);
    }

    public void SwitchInputSchemaToCutscenes()
    {
        _playerInput.Player.Disable();
        _playerInput.Cutscenes.Enable();
        _playerInput.Cutscenes.NextMessage.started += OnNextMessege;
    }

    public void SwitchInputSchemaToPlayer()
    {
        _playerInput.Player.Enable();
        _playerInput.Cutscenes.Disable();
        _playerInput.Cutscenes.NextMessage.started -= OnNextMessege;
    }

    private void OnNextMessege(InputAction.CallbackContext context)
    {
        IsNextMessegeSelected?.Invoke();
    }

    public void DisableInput()
    {
        _playerInput.Player.Disable();
    }
}
