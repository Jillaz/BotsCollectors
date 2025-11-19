using System.Collections.Generic;
using UnityEngine;

public class BotsTaskManager : MonoBehaviour
{
    [SerializeField] private BotsLocator _botsLocator;
    [SerializeField] private PerlLocator _perlLocator;
    [SerializeField] private Base _base;
    private List<Bot> _bots = new List<Bot>();
    private List<Perl> _perl = new List<Perl>();

    public void UpdateStatus()
    {
        _perl = _perlLocator.Search();
        SetTask();
    }

    private void Start()
    {
        _bots = _botsLocator.Search();
        UpdateStatus();
    }

    private void Update()
    {
        UpdateStatus();
    }    

    private void SetTask()
    {
        foreach (Bot bot in _bots) 
        {
            bot.SetBasePosition(_base);

            if (bot.IsBusy == false)
            {
                bot.GetPerl(GetFreeResource());
            }
        }
    }

    private Perl GetFreeResource()
    {
        foreach (Perl perl in _perl)
        {
            if (perl.IsBusy == false)
            {
                perl.Busy();
                return perl;
            }       
        }

        return null;
    }
}
