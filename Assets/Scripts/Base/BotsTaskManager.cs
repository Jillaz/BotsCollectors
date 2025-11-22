using System.Collections.Generic;
using UnityEngine;

public class BotsTaskManager : MonoBehaviour
{
    [SerializeField] private BotsLocator _botsLocator;
    [SerializeField] private Base _base;
    [SerializeField] private ObjectList _list;
    private List<Bot> _bots = new List<Bot>();

    private void Start()
    {
        _bots = _botsLocator.Search();
    }

    private void Update()
    {
        SetTask();
    }    

    private void SetTask()
    {
        foreach (Bot bot in _bots) 
        {
            bot.SetBasePosition(_base);

            if (bot.IsBusy == false)
            {                
                bot.SetPerl(_list.Get());
            }
        }
    }
}
