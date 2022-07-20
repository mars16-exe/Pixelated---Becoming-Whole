using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class minswipedistance : MonoBehaviour
{
    public swipeDetection swipeDetector;
    public TMP_InputField inputField;
    public Slider slider;

    public float minSwipeDis;
    // Start is called before the first frame update
    private void Start()
    {
        minSwipeDis = swipeDetector.MIN_SWIPE_DISTANCE;
        slider.value = minSwipeDis;
        inputField.text = "" + slider.value;
    }

    public void Change()
    {
        minSwipeDis = slider.value;
        swipeDetector.MIN_SWIPE_DISTANCE = minSwipeDis;
        inputField.text = "" + slider.value;
    }
}
