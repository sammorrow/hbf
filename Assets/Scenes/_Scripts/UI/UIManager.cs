using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameScreen;

    public void StartGame()
    {
        startScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void PauseGame(bool pause)
    {
        pauseScreen.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }

    public void QuitGame()
    {
        startScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(false);
    }

}
