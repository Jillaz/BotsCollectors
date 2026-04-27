using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private BotsList _botsList;
    [SerializeField] private Counter _counter;
    [SerializeField] private BuildingOptions _buildingOptions;
    [SerializeField] private BotsTaskManager _botsTaskManager;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private PlayerInputController _playerInputController;
    [SerializeField] private Flag _buildFlag;
    private bool _isBuildBase = false;
    private bool _isSelected = false;
    private int _minBotsNumberToBuildBase = 2;
    private Vector3 _buildLocation;

    private void Start()
    {
        _counter.ValueChanged += Build;
        _playerInputController.MouseClicked += MouseClicked;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= Build;
        _playerInputController.MouseClicked -= MouseClicked;
    }

    private void SelectBase()
    {
        _isSelected = true;
        _particleSystem.Play();
    }

    private void DeselectBase()
    {
        _isSelected = false;
        _particleSystem.Stop();
    }

    private void MouseClicked(RaycastHit hit)
    {
        float defaultY = 1f;

        if (hit.collider.gameObject == this.gameObject)
        {
            SelectBase();
        }
        else if (hit.collider.GetComponent<Builder>())
        {
            DeselectBase();
        }
        else if (_isSelected)
        {
            _buildLocation = new Vector3(hit.point.x, defaultY, hit.point.z);
            _isBuildBase = true;
            PlaceBuildFlag();
        }
    }

    private void Build(int value)
    {
        if (_isBuildBase && _botsList.Count() >= _minBotsNumberToBuildBase)
        {
            if (value >= _buildingOptions.GetBasePrice())
            {
                _botsTaskManager.BuildBase(_buildLocation, _buildingOptions.GetBase());
                _counter.ReduceValue(value);
                _isBuildBase = false;
                DeselectBase();
                ReturnBuildFlag();
            }
        }
        else
        {
            if (value >= _buildingOptions.GetBotPrice())
            {
                Bot bot = Instantiate(_buildingOptions.GetBot(), _spawnPosition.position, Quaternion.identity);
                _botsList.Add(bot);
                _counter.ReduceValue(value);
            }
        }
    }

    private void PlaceBuildFlag()
    {
        _buildFlag.gameObject.SetActive(true);
        _buildFlag.transform.position = _buildLocation;
    }

    private void ReturnBuildFlag()
    {
        _buildFlag.gameObject.SetActive(false);
        _buildFlag.transform.position = transform.position;
    }
}
