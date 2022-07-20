using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseHandler : MonoBehaviour
{
    public GameObject pauseUI;

    private bool isPaused;

    public void PauseDo()
    {
        if(pauseUI.activeSelf == false)
        {
            pauseUI.SetActive(true);
            isPaused = true;
        }
    }

    private void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        if(pauseUI.activeSelf == true)
        {
            pauseUI.SetActive(false);
            isPaused = false;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
