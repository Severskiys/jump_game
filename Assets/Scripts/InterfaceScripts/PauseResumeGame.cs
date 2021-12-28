using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeGame : MonoBehaviour
{
    public void PauseButtonPressed()
    {
        Time.timeScale = 0f;
    }
    public void ResumeButtonPressed()
    {
        Time.timeScale = 1f;
    }
}

