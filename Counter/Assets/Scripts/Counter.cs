using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float Delay = 0.5f;

    [SerializeField] private InputReader _inputReader;

    private bool _isRunning;
    private int _count;

    public event Action CountChanged;

    private Coroutine _countTime;

    public int Count => _count;

    private void OnEnable()
    {
        _inputReader.MouseClick += Switch;
    }

    private void OnDisable()
    {
        _inputReader.MouseClick -= Switch;
    }

    private void Start()
    {
        _isRunning = false;
        _count = 0;
    }

    private void Switch()
    {
        _isRunning = !_isRunning;

        if (_isRunning == true)
        {
            _countTime = StartCoroutine(CountTime(Delay));
        }
        else
        {
            if (_countTime != null)
            {
                StopCoroutine(_countTime);
            }
        }
    }

    private IEnumerator CountTime(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            _count++;

            CountChanged?.Invoke();
        }
    }
}
