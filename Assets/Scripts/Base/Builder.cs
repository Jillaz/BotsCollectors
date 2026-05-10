using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private BotsList _botsList;
    [SerializeField] private Counter _counter;
    [SerializeField] private BuildingOptions _buildingOptions;
    [SerializeField] private BotsTaskManager _botsTaskManager;
    private int _minBotsNumberToBuildBase = 2;
    private Vector3 _buildLocation;

    public bool IsBuildBase { get; private set; } = false;
    public Vector3 GetBuildLocation => _buildLocation;

    private void Start()
    {
        _counter.ValueChanged += Build;
        _buildLocation = transform.position;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= Build;
    }

    public void SetBuildPosition(Vector3 buildLocation)
    {
        _buildLocation = buildLocation;
        IsBuildBase = true;
    }


    private void Build(int value)
    {
        if (IsBuildBase && _botsList.Count() >= _minBotsNumberToBuildBase)
        {
            if (value >= _buildingOptions.GetBasePrice())
            {
                _botsTaskManager.BuildBase(_buildLocation, _buildingOptions.GetBase());
                _counter.ReduceValue(value);
                IsBuildBase = false;
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
