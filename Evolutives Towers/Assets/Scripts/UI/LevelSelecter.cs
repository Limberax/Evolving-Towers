using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour
{
    [SerializeField] private SceneFader fader;

    [SerializeField] private Button[] levelButtons;
    void Start()
    {
        int levelReach = PlayerPrefs.GetInt("levelReach", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReach)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        Debug.Log(levelName);
        fader.FadeTo(levelName);
    }
}
