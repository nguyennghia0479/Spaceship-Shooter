using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem inputSystem;

    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 moveDir = inputSystem.Movement.Move.ReadValue<Vector2>();
        
        return moveDir.normalized;
    }
}
