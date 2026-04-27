using System.Collections.Generic;
using UnityEngine;

public class PerlsLocator : MonoBehaviour
{
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _layerMask;

    public HashSet<Perl> Search()
    {
        HashSet<Perl> _perl = new HashSet<Perl>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _searchRadius, _layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Perl perl))
            {
                _perl.Add(perl);
            }
        }

        return _perl;
    }
}
