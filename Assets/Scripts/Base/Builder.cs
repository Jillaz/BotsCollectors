using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private BotsList _botsList;
    [SerializeField] private Counter _counter;
    [SerializeField] private BuildingOptions _buildingOptions;
    [SerializeField] private BotsTaskManager _botsTaskManager;
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isBuildBase = false;
    private Vector3 _buildLocation;

    private void Start()
    {
        _counter.ValueChanged += Build;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= Build;
    }

    public void SelectBase()
    {
        _particleSystem.Play();
    }

    public void DeselectBase()
    {
        _particleSystem.Stop();
    }

    public void StartBuildBase(Vector3 location)
    {
        _buildLocation = location;
        _isBuildBase = true;
    }

    private void Build(int value)
    {
        if (_isBuildBase)
        {
            if (value >= _buildingOptions.GetBasePrice())
            {
                _botsTaskManager.BuildBase(_buildLocation, _buildingOptions.GetBase());
                _counter.ReduceValue(value);
                _isBuildBase = false;
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
}
