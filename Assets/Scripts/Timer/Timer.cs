using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timeTXT;
    private float timer = 0.0f;
    [SerializeField] private bool isTimerON = false;


    // Start is called before the first frame update
    void Awake()
    {
        timeTXT = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        DisplayTimer();

        if (isTimerON)
        {
            timer += Time.deltaTime;
        }
    }

    private void DisplayTimer()
    {
        int minute = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minute * 60.0f);
        timeTXT.text = string.Format("{0:00}:{1:00}", minute, seconds);

    }

    public void StartTimer()
    {
        isTimerON = true;
    }
    
    public void StopTimer()
    {
        isTimerON = false;
    }

    public void ResetTimer()
    {
        timer = 0.00f;
    }
}
