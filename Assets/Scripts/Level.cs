using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject gameCanvas;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        startCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(currentSceneIndex);
    }

    public void ActivateLoseCanvas()
    {
        Time.timeScale = 0f;
        loseCanvas.SetActive(true);
    }


    public void ActivateWinCanvas()
    {
        Time.timeScale = 0f;
        winCanvas.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void LoadNextScene()
    {
        if (currentSceneIndex == 2)
        {
            SceneManager.LoadScene(0);
        }

        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

}
