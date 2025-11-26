using System.Collections.Generic;
using UnityEngine;

public class Bots : MonoBehaviour
{
    [SerializeField] private List<Bot> _bots;
    [SerializeField] private Base _base;

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

    private void SetBasePosition()
    {
        foreach (var bot in _bots)
        {
            bot.SetBasePosition(_base);
        }
    }
}
