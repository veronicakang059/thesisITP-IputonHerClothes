using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class loadSceneAFterVideoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;
    public int currentScene;
    
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        video = GetComponent<VideoPlayer>();
        //video.Play();
        video.loopPointReached += CheckOver;
    }

   
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene+1);
    }
}
