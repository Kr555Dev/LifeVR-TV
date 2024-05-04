
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
