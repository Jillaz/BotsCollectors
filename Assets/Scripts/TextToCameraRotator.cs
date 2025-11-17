using UnityEngine;

public class TextToCameraRotator : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
