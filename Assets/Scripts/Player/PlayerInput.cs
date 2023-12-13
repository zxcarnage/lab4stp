using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _movingDirection;

    public Vector3 MovingDirection => _movingDirection;
    
    public event Action ShootButtonClicked;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleMoveInput();
        HandleShootInput();
    }

    private void HandleMoveInput()
    {
        var vertical = Input.GetAxis("Vertical");
        _movingDirection = new Vector3(0, vertical, 0) * Time.deltaTime;
    }

    private void HandleShootInput()
    {
        if(Input.GetMouseButtonDown(0))
            ShootButtonClicked?.Invoke();
    }
}