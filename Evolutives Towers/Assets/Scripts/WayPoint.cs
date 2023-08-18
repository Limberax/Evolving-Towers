using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    public static Transform[] path_0;

    private void Awake()
    {
        path_0 = new Transform[transform.childCount];

        for (int i = 0; i < path_0.Length; i++)
        {
            path_0[i] = transform.GetChild(i);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
