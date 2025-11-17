using TMPro;
using UnityEngine;

public class CountDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += DisplayText;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= DisplayText;        
    }

    private void DisplayText(int value)
    {
        _text.text = value.ToString();
    }
}
