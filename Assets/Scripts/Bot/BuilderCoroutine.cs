using System.Collections;
using UnityEngine;

public class BuilderCoroutine : MonoBehaviour
{
    [SerializeField] private float _buildTime;

    public IEnumerator Build(BotsList basePrefab, Transform buildPosition)
    {
        Debug.Log("Start building");
        yield return new WaitForSeconds(_buildTime);

        BotsList newBase = Instantiate(basePrefab,buildPosition);
        newBase.Add(GetComponent<Bot>());

        Debug.Log("Building complete!");
    }
}