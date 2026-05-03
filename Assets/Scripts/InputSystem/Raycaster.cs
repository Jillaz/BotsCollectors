using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Raycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;
    private float _distance = 1000f;

    public event Action<RaycastHit> MouseClicked;

    public void OnLeftMouseClick()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
        {
            MouseClicked?.Invoke(hit);
        }
    }
}
