using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameScreen;

    public void StartGame()
    {
        startScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void PauseGame(bool pause)
    {
        pauseScreen.SetActive(pause);
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

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            PauseGame(true);
        else
            PauseGame(false);
    }
}
