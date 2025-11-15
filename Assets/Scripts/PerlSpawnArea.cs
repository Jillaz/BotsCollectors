using UnityEngine;

public class PerlSpawnArea : MonoBehaviour
{
    public Vector3 GetSpawnPosition()
    {
        float scaleFactorX;
        float scaleFactorZ;
        float minPositionX;
        float maxPositionX;
        float postitionX;
        float minPositionZ;
        float maxPositionZ;
        float postitionZ;
        float postitionY;

        scaleFactorX = transform.localScale.x / 2;
        scaleFactorZ = transform.localScale.z / 2;

        minPositionX = transform.position.x - scaleFactorX;
        maxPositionX = transform.position.x + scaleFactorX;

        minPositionZ = transform.position.z - scaleFactorZ;
        maxPositionZ = transform.position.z + scaleFactorZ;

        postitionX = UnityEngine.Random.Range(minPositionX, maxPositionX);
        postitionZ = UnityEngine.Random.Range(minPositionZ, maxPositionZ);
        postitionY = transform.position.y;

        return new Vector3(postitionX, postitionY, postitionZ);
    }
}
