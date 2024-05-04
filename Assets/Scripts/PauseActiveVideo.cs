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

    }

    public void PauseVideo()
    {
        VideoPlayer pp = helper();
        if (pp != null)
        {
            pp.Pause();
        }
    }

    public void ResumeVideo()
    {
        VideoPlayer pp = helper();
        if (pp != null)
        {
            pp.Play();
        }
    }

    public void StopVideo()
    {
        // Stop video playback and disable the video player
        VideoPlayer pp = helper();
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
