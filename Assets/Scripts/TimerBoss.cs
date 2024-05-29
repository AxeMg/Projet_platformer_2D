using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerBoss : MonoBehaviour
{

    private TMP_Text _timerText;
    enum TimerType { Countdown, Stopwatch }
    [SerializeField] private TimerType timerType;

    [SerializeField] private float timeToDisplay = 0f;

    [SerializeField] private bool _isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
        _isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning) return;
        if (timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            EventManager.OnTimerStop();
            return;
        }
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isRunning = false;
    }
}
