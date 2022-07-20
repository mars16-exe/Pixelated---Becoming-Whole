using UnityEngine;

/*
 * Swipe Input script for Unity by @fonserbc, free to use wherever
 *
 * Attack to a gameObject, check the static booleans to check if a swipe has been detected this frame
 * Eg: if (SwipeInput.swipedRight) ...
 *
 * 
 */

public class swipeDetection : MonoBehaviour
{
	//my added codes
	private Camera cam;

	// If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 0.7f;

	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public float MIN_SWIPE_DISTANCE = 0.91f;

	//0.91 seemed good for my pixel 2. Howeever, more tests required on other devices//


	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;


	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

	[Header("The Indicator")]
	public SLOWMOindicator indicator;

    private void Awake()
    {
		cam = Camera.main;
	}

	public void Update()
    {
        if(!PlayerShoot.Instance.mouseOnUI)
        {
            Swipe();
        }
    }

    private void Swipe()
    {
        swipedRight = false;
        swipedLeft = false;
        swipedUp = false;
        swipedDown = false;

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = cam.ScreenToWorldPoint(t.position);
                startTime = Time.time;
                indicator.gameObject.SetActive(true);
            }
            if (t.phase == TouchPhase.Ended)
            {
                indicator.gameObject.SetActive(false);

                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                {
                    return;
                }

                Vector2 endPos = cam.ScreenToWorldPoint(t.position);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe|Hence, shoot
                {
                    PlayerShoot.Instance.Shoot();
                    return;
                }

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        swipedRight = true;
                    }
                    else
                    {
                        swipedLeft = true;
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        swipedUp = true;
                    }
                    else
                    {
                        swipedDown = true;
                    }
                }
            }
        }

        if (debugWithArrowKeys)
        {
            swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
            swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
            swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
            swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
        }
    }
}