using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SCN_CinématiqueIntro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FullscreenTog()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("FULLSCREEN");
    }
}
