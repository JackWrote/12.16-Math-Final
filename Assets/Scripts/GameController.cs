using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject dontDestroy;
    public GameObject dontDestroy1;
    private void Start()
    {
        DontDestroyOnLoad(dontDestroy);
        DontDestroyOnLoad(dontDestroy1);
    }
    void Update()
    {
        float s = Score.score;
        if(s >= 100 && s <= 101) 
        {
            Debug.Log("hi");
        }
    }
}
