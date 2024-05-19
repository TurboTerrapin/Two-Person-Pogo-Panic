using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nextLevel;

    [SerializeField]
    private bool resetTimer;

    [SerializeField]
    private Timer timer;

    private void Start()
    {
        timer = FindFirstObjectByType<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void ChangeScene(string sceneName)
    {
        if(resetTimer)
        {
            Destroy(timer.gameObject.transform.parent.gameObject);
        }

        SceneManager.LoadScene(sceneName);
    }
}
