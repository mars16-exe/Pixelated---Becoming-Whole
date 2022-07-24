using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseHandler : MonoBehaviour
{
    public GameObject pauseUI;

    public void PauseDo()
    {
        if(pauseUI.activeSelf == false)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if(pauseUI.activeSelf == true)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
