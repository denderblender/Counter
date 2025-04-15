using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CountChanged += ChangeText;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangeText;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void ChangeText()
    {
        _text.text = _counter.Count.ToString();
    }
}
