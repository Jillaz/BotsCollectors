using System.Collections.Generic;
using UnityEngine;

public class BotsList : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private BotsLocator _botsLocator;
    private List<Bot> _bots;
    private Bot _removeBot = null;

    private void Start()
    {
        SetBasePosition();
    }

    public Bot GetFreeBot()
    {
        if (_removeBot == null)
        {
            foreach (var bot in _bots)
            {
                if (bot.IsBusy == false)
                {
                    return bot;
                }
            }
        }
        else
        {
            _bots.Remove(_removeBot);
            _removeBot = null;
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
        _removeBot = bot;
    }

    public int Count()
    {
        return _bots.Count;
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
