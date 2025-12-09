using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static bool Gameispaused;
    public GameObject PauseMenuUi;

    private void Start()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 0;
        Gameispaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Gameispaused)
            {
                Paused();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Paused()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 1.0f;
        Gameispaused = true;
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 0;
        Gameispaused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
