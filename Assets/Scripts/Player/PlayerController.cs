using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem inputSystem;
    private bool isOpenSetting;

    public event Action<bool> OnToogleSetting;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Player.Setting.performed += Setting_performed;
    }

    private void OnDestroy()
    {
        if (inputSystem != null)
        {
            inputSystem.Dispose();
        }
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 moveDir = inputSystem.Player.Move.ReadValue<Vector2>();
        
        return moveDir.normalized;
    }

    private void Setting_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        ToogleSetting();
    }

    public void ToogleSetting()
    {
        isOpenSetting = !isOpenSetting;
        OnToogleSetting?.Invoke(isOpenSetting);
    }
}
