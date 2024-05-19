using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private bool isGameRunning;

    private float timer;


    private void Start()
    {
        DontDestroyOnLoad(canvas);
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "" + timer;
        }
    }

    public void stopTimer()
    {
        isGameRunning = false;
    }

}
