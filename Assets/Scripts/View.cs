using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private Counter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += Show;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= Show;
    }

    private void Show(float score)
    {
        _score.text = score.ToString();
    }
}
