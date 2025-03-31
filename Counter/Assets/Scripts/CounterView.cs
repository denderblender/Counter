using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CountChanged += Method;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= Method;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Method()
    {
        _text.text = _counter.Count.ToString();
    }
}
