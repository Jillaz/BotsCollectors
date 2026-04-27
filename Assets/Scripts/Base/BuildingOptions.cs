using UnityEngine;

public class BuildingOptions : MonoBehaviour
{
    [SerializeField] private Bot _botPrefab;
    [SerializeField] private BotsList _basePrefab;
    [SerializeField] private int _botPrice;
    [SerializeField] private int _basePrice;

    public int GetBotPrice()
    {
        return _botPrice;
    }

    public Bot GetBot()
    {
        return _botPrefab;
    }

    public int GetBasePrice()
    {
        return _basePrice;
    }

    public BotsList GetBase()
    {
        return _basePrefab;
    }
}
