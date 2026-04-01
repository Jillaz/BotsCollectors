using System.Collections.Generic;
using UnityEngine;

public class BotsList : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private BotsLocator _botsLocator;
    private List<Bot> _bots;

    private void Start()
    {
        SetBasePosition();
    }

    public Bot GetFreeBot()
    {
        foreach (var bot in _bots)
        {
            if (bot.IsBusy == false)
            {
                return bot;
            }
        }

        return null;
    }

    public void Add(Bot bot)
    {
        _bots.Add(bot);
        bot.SetBasePosition(_base);
    }

    public void Remove(Bot bot)
    {
        _bots.Remove(bot);
    }

    private void SetBasePosition()
    {
        _bots = _botsLocator.Search();

        foreach (var bot in _bots)
        {
            bot.SetBasePosition(_base);
        }
    }
}
