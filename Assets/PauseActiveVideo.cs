using UnityEngine;
using UnityEngine.Video;

public class PauseActiveVideo : MonoBehaviour
{
    public GameObject activeChild;

    void Start()
    {
        activeChild = GetActiveChild();
    }

    public VideoPlayer helper()
    {
        activeChild = GetActiveChild();
        VideoPlayer pp = activeChild.GetComponent<VideoPlayer>();
        return pp;

    }

    void Update()
    {
        // Example: You can update the active child during runtime if needed
        activeChild = GetActiveChild();
    }

    public void PauseVideo()
    {
        VideoPlayer pp = activeChild.GetComponent<VideoPlayer>();
        if (pp != null)
        {
            pp.Pause();
        }
    }

    public void ResumeVideo()
    {
        VideoPlayer pp = activeChild.GetComponent<VideoPlayer>();
        if (pp != null)
        {
            pp.Play();
        }
    }

    public void StopVideo()
    {
        // Stop video playback and disable the video player
        VideoPlayer pp = activeChild.GetComponent<VideoPlayer>();
        pp.Stop();
        pp.gameObject.SetActive(false);
    }

    GameObject GetActiveChild()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                return child.gameObject;
            }
        }

        return null;
    }
}
