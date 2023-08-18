using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private SceneFader fader;
    [SerializeField] private string menuScene = "MainMenu";

    [SerializeField] private string nextLevel = "Level02";
    [SerializeField] private int levelToUnlock = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReach", levelToUnlock);

        fader.FadeTo(nextLevel);
    }

    public void GoToMenu()
    {
        fader.FadeTo(menuScene);
    }
    public void RetryLvl()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }
}

