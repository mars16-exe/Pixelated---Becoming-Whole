using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioClip pickupSFX;

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
    }
}
