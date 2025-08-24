using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action TimerChanged;

    private Coroutine _coroutine;
    private float _period = 0.5f;

    public int Score {  get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ToogleCounter();
    }

    private void ToogleCounter()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(StartCounter(_period));
        }
    }

    private IEnumerator StartCounter(float period)
    {
        var wait = new WaitForSeconds(period);

        while (enabled)
        {
            Score++;
            TimerChanged?.Invoke();
            yield return wait;
        }
    }
}
