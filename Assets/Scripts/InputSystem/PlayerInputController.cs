using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Camera _camera;
    [SerializeField] GameObject _marker;
    private Vector3 _position;
    private float _distance = 1000f;
    private Builder _builder = null;

    public void OnLeftMouseClick()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
        {
            if (hit.collider.GetComponent<Builder>())
            {
                _builder = hit.collider.GetComponent<Builder>();
                _builder.SelectBase();
            }
            else
            {
                if (_builder != null)
                {
                    float defaultY = 1f;

                    _position = new Vector3(hit.point.x, defaultY, hit.point.z);
                    _builder.StartBuildBase(_position);
                    _builder.DeselectBase();
                    _builder = null;
                    Debug.Log(_position);
                    Instantiate(_marker, _position, Quaternion.identity);
                }
            }
        }
    }
}
