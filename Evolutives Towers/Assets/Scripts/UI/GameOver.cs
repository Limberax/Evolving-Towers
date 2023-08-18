using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{

    //[SerializeField] private TMP_Text roundsText;

    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string menuScene = "MainMenu";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    */

    public void RetryLvl()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        sceneFader.FadeTo(menuScene);
    }
}
