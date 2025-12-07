using UnityEngine;

public class BotsTaskManager : MonoBehaviour
{
    [SerializeField] private BotsList _bots;
    [SerializeField] private ObjectList _list;

    private void Update()
    {
        SetTask();
    }

    private void SetTask()
    {
        Bot bot = _bots.GetFreeBot();

        if (bot != null)
        {
            bot.SetPerl(_list.Get());
        }
    }
}
