using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LiveUI : MonoBehaviour
{
    [SerializeField] private TMP_Text liveText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = PlayerStats.Live.ToString();
    }
}
