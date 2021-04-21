using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;
using Vuforia;

public class virtualPlayerButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject virtualButton1;
    public VideoPlayer video1;
    public int currentScene;
    public TextMesh tapText;
    //public bool isButtonThere = false;
    
    void Start()
    {
        virtualButton1 = GameObject.Find("Tap");
        virtualButton1.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed);
        video1 = GetComponent<VideoPlayer>();
        virtualButton1.SetActive(true);
        //tapText = GetComponent<TextMesh>();
        tapText.text = "";
    }
    

    private void Awake()
    {
        video1.loopPointReached += VideoEnded;
    }

    void VideoEnded(UnityEngine.Video.VideoPlayer vp)
    {
        virtualButton1.SetActive(true);
        Debug.Log("button Active");
        //isButtonThere = true;
        tapText.text = "Tap";


    }
    

    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene+1);
        Debug.Log("pressed");
    }
    
}
