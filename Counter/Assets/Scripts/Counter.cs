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

    public int Count => _count;

    public event Action CountChanged;

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
            StartCoroutine(nameof(CountTime));
        }
        else
        {
            StopCoroutine(nameof(CountTime));
        }
    }

    private IEnumerator CountTime()
    {
        while (true)
        {
            if (_time >= _delay)
            {
                _count++;
                _time = 0.0f;

                CountChanged?.Invoke();
            }

            _time += Time.deltaTime;

            yield return null;
        }
    }
}
