using UnityEngine;
using TMPro;
using System;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.TimerChanged += DisplayTimer;
    }

    private void OnDisable()
    {
        _counter.TimerChanged -= DisplayTimer;
    }

    private void DisplayTimer()
    {
        int amount = _counter.Score;
        _text.text = amount.ToString();
    }
}
