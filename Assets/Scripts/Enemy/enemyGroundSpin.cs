using UnityEngine;

public class enemyGroundSpin : enemyGround
{
    void LateUpdate()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
