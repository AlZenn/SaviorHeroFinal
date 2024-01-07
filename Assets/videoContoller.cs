using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoContoller : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Video bitiminde olaya abone ol
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Video bittiðinde çaðrýlýr
        // Sahneyi deðiþtir
        SceneManager.LoadScene("Main");
    }
}
