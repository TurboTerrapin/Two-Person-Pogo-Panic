using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    void Start()
    {
        timer = FindFirstObjectByType<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer.stopTimer();
    }


}
