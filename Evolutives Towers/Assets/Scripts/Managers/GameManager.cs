using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject completeLevelUI;

    //[SerializeField] private string nextLevel = "Level02";
    //[SerializeField] private int levelToUnlock = 2;

    //public SceneFader fader;
    void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if(PlayerStats.Live <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
