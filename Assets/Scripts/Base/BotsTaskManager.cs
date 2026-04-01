using UnityEngine;

public class BotsTaskManager : MonoBehaviour
{
    [SerializeField] private BotsList _bots;
    [SerializeField] private ObjectList _list;

    private void Update()
    {
        SetTask();
    }

    public void BuildBase(Vector3 buildPlace, Base basePrefab)
    {
        Bot bot = _bots.GetFreeBot();

        if (bot != null)
        {
            bot.StartBuilding(buildPlace, basePrefab);
        }
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
