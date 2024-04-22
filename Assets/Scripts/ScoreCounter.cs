using System;
using System.Collections;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float _score = 0f;
    private float _delay = 0.5f;
    private float _scorePerTime = 1f;
    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    public event Action<float> ScoreChanged;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(nameof(IncreaseScore));
            }
            else if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator IncreaseScore()
    {
        while (enabled)
        {
            _score += _scorePerTime;
            ScoreChanged?.Invoke(_score);

            yield return _wait;
        }
    }
}
