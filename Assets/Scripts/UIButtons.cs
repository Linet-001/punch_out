using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public void Restart()
    {
        SceneManager.LoadScene("Round_One");
    }


    public void Pause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}

