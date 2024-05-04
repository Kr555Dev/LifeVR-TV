using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public List<VideoPlayer> othervideoPlayers = new List<VideoPlayer>();

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        // Disable the video player initially
        videoPlayer.gameObject.SetActive(false);
    }

    public void PlayVideo()
    {
        // Enable the video player and start playback
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();

        foreach (VideoPlayer player in othervideoPlayers)
        {
            if (player.isPlaying)
            {
                player.Stop();
            }

            player.gameObject.SetActive(false);
        }


    }


    
}
