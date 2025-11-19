using System.Collections.Generic;
using UnityEngine;

public class BotsLocator : MonoBehaviour
{
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _layerMask;

    public List<Bot> Search()
    {
        List<Bot> _bot = new List<Bot>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _searchRadius, _layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Bot bot))
            {
                _bot.Add(bot);
            }
        }

        return _bot;
    }
}
