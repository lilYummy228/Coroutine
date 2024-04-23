using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _score = 0f;
    private float _delay = 0.5f;
    private float _scorePerTime = 1f;
    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private KeyCode _key = KeyCode.Mouse0;

    public event Action<float> ScoreChanged;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(nameof(Increase));
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Increase()
    {
        while (enabled)
        {
            _score += _scorePerTime;
            ScoreChanged?.Invoke(_score);

            yield return _wait;
        }
    }
}
