using UnityEngine;

public class baseAmmo : MonoBehaviour
{
    public int value;
    public float rank = 0f;

    public AudioClip pickupSFX;

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
    }
}
