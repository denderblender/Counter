using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private InputReader _inputReader;

    private bool _isRunning;
    private int _count;
    private float _time;

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
        _time = 0;
    }

    private void Switch()
    {
        _isRunning = !_isRunning;

        if (_isRunning == true)
        {
            _countTime = StartCoroutine(CountTime(_delay));
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
