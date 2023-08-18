using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image faderImage;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeTo(string scene)
    {
        Debug.Log("Llamada a FadeTo");
        StartCoroutine(FadeOut(scene));

    }


    IEnumerator FadeIn()
    {
        float t = 0f;
        while(t < 1f)
        {
            t -= Time.deltaTime * 1f;
            faderImage.color = new Color(0f,0f,0f,t);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            faderImage.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
