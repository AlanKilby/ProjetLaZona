using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseCanvas;

    private bool isPaused;

    private float timeScaleHolder;

    private void Start()
    {
        pauseCanvas.SetActive(false);
        isPaused = false;
        timeScaleHolder = Time.timeScale;
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            Pause();
            isPaused = true;
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            UnPause();
            isPaused = false;
        }

        if(isPaused && Input.GetButtonDown("Quit"))
        {
            Quit();
        }

    }

    public void Resume()
    {

        if (isPaused)
        {
            Time.timeScale = timeScaleHolder;
            pauseCanvas.SetActive(false);
            isPaused = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = timeScaleHolder;
        pauseCanvas.SetActive(false);
    }
}
