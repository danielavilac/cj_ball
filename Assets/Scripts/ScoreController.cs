using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private Text score;
    private int count;

    void Awake ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    private void SetCountText ()
    {
        score.text = "Score: " + count;
    }

    public void Increase ()
    {
        count++;
        SetCountText();
    }

    public void Reset ()
    {
        count = 0;
        SetCountText();
    }
}
