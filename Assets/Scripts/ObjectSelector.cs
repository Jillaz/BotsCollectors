using TMPro;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] Flag _flag;
    private Builder _builder = null;

    private void OnEnable()
    {
        _raycaster.MouseClicked += MouseClicked;
    }

    private void OnDisable()
    {
        _raycaster.MouseClicked -= MouseClicked;
        _particleSystem.Stop();
    }

    private void Start()
    {
        _flag.gameObject.SetActive(false);
    }

    private void MouseClicked(RaycastHit hit)
    {
        if (hit.collider.GetComponent<Builder>())
        {
            _builder = hit.collider.GetComponent<Builder>();
            Select();
        }
        else if (_builder != null)
        {
            SetBuildLocation(hit);
        }
    }

    private void Select()
    {
        _particleSystem.transform.position = _builder.transform.position;
        _particleSystem.Play();

        _flag.transform.position = _builder.GetBuildLocation;
        _flag.gameObject.SetActive(_builder.IsBuildBase);
    }

    private void SetBuildLocation(RaycastHit hit)
    {
        float defaultY = 1f;

        _flag.transform.position = new Vector3(hit.point.x, defaultY, hit.point.z);
        _builder.SetBuildPosition(_flag.transform.position);
        _flag.gameObject.SetActive(_builder.IsBuildBase);
    }
}