//using UnityEngine;
//using UnityEngine.Video;
//using UnityEngine.UI;

//public class SeekVideoScript : MonoBehaviour
//{
//    private VideoPlayer videoPlayer;
//    public Slider seekSlider;
//    public float seekStep = 5f; // Amount to seek forward/backward in seconds

//    private bool isSeeking = false;
//    public PauseActiveVideo pps;

//    void Start()
//    {
//        videoPlayer = pps.helper();

//        // Set up seek slider
//        seekSlider.minValue = 0;
//        seekSlider.maxValue = (float)videoPlayer.length;

//    }

//    void Update()
//    {

//        // Update seek slider value while not seeking
//        if (!isSeeking && !Input.GetMouseButton(0))
//        {
//            seekSlider.value = (float)videoPlayer.time;
//        }

//        if(videoPlayer)

//        seekSlider.onValueChanged.AddListener(OnSeekSliderChanged);
//    }

//    public void SeekForward()
//    {
//        isSeeking = true;
//        float newTime = (float)videoPlayer.time + seekStep;
//        if (newTime > videoPlayer.length)
//        {
//            newTime = (float)videoPlayer.length;
//        }
//        videoPlayer.time = newTime;
//        isSeeking = false;
//    }

//    public void SeekBackward()
//    {
//        isSeeking = true;
//        float newTime = (float)videoPlayer.time - seekStep;
//        if (newTime < 0)
//        {
//            newTime = 0;
//        }
//        videoPlayer.time = newTime;
//        isSeeking = false;
//    }

//    public void OnSeekSliderChanged(float value)
//    {
//        videoPlayer.time = value;
//    }
//}


using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections.Generic;

public class SeekVideoScript : MonoBehaviour
{
    public List<VideoPlayer> videoPlayers;
    public Slider seekSlider;

    private VideoPlayer activeVideoPlayer;
    private bool isSeeking = false;

    void Start()
    {
        // Set up seek slider
        seekSlider.minValue = 0;
        seekSlider.maxValue = 1; // Slider value will be normalized
        seekSlider.onValueChanged.AddListener(OnSeekSliderChanged);

        // Set the active video player to the first one in the list by default
        activeVideoPlayer = videoPlayers[0];
        seekSlider.value = 0;
    }

    void Update()
    {
        // Update seek slider value while not seeking
        if (!isSeeking && !Input.GetMouseButton(0)) // Check if mouse button is not being held down to prevent interference
        {
            seekSlider.value = (float)activeVideoPlayer.time / (float)activeVideoPlayer.length;
        }
    }

    public void OnSeekSliderChanged(float value)
    {
        isSeeking = true;
        activeVideoPlayer.time = value * activeVideoPlayer.length;
        isSeeking = false;
    }

    public void SetActiveVideoPlayer(int index)
    {
        if (index >= 0 && index < videoPlayers.Count)
        {
            activeVideoPlayer = videoPlayers[index];
            seekSlider.value = 0;
        }
    }
}
