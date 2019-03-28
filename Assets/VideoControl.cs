using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControl : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.GameObject cameraRR;

    private UnityEngine.Video.VideoPlayer videoPlayerEdge;
    private UnityEngine.Video.VideoPlayer videoPlayerMain;
    private UnityEngine.Video.VideoPlayer videoPlayerLand;
    public UnityEngine.GameObject shpereEdge;
    public UnityEngine.GameObject shpereLand;
    public UnityEngine.GameObject shpereMain;



    [SerializeField]
    private AudioSource audioSource;



    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayerEdge = shpereEdge.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayerLand = shpereLand.GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayerMain = shpereMain.GetComponent<UnityEngine.Video.VideoPlayer>();


        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {


    }

    public void playOrPuse()
    {
        //Play or pause the video.
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }

        else
            videoPlayer.Play();
        audioSource.Play();

    }

    public void restarnMainVideo()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
    }

    public void goToMain()
    {
        videoPlayer.Stop();
        cameraRR.transform.position = new Vector3(0f, 0f, 0f);

        shpereMain.GetComponent<VideoControl>().restarnMainVideo();
    }

    public void goToBranch1()
    {
        videoPlayer.Stop();
        cameraRR.transform.position = new Vector3(20f, 20f, 20f);

        shpereEdge.GetComponent<VideoControl>().restarnMainVideo();

    }

    public void goToBranch2()
    {

        videoPlayer.Stop();
        cameraRR.transform.position = new Vector3(-20f, -20f, -20f);

        shpereLand.GetComponent<VideoControl>().restarnMainVideo();

    }

}