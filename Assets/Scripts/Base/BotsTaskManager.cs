using UnityEngine;

public class BotsTaskManager : MonoBehaviour
{
    [SerializeField] private BotsList _bots;
    [SerializeField] private ObjectList _list;
    private Bot _botBuilder = null;

    private void Update()
    {
        SetTask();
    }

    public void BuildBase(Vector3 buildPlace, BotsList basePrefab)
    {
        if (_botBuilder == null)
        {
            _botBuilder = _bots.GetFreeBot();
            _botBuilder.BuildComplite += ReleaseBotBuilder;
        }

        _botBuilder.StartBuild(buildPlace, basePrefab);
    }

    private void SetTask()
    {
        Bot bot = _bots.GetFreeBot();

        if (bot != null)
        {
            bot.SetPerl(_list.Get());
        }
    }

    private void ReleaseBotBuilder(BotsList newBase)
    {
        _botBuilder.BuildComplite -= ReleaseBotBuilder;
        _bots.Remove(_botBuilder);
        _botBuilder = null;
    }
}
