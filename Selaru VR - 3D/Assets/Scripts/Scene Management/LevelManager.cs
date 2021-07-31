using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
    [SerializeField] private bool usingTimer;
    [SerializeField] private float timer = 7f;
    [SerializeField] private string nextSceneName; // next scene if using timer

    private void Start()
    {
        if (usingTimer)
        {
            StartCoroutine(NextSceneByTimer());
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void LoadUsingTimer()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator NextSceneByTimer()
    {
        yield return new WaitForSeconds(timer);
        LoadUsingTimer();
    }
}
