using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurrent : Enemy
{
    // Update is called once per frame
    void Update()
    {
        if(playerWithinRange())
        {
            if(this.transform.rotation.z < 90 && this.transform.rotation.z > -90)
            {
                transform.LookAt(PlayerShoot.Instance.gameObject.transform.position);
                Attack();
            }

        }
    }

    private void Attack()
    {
        Debug.Log("pew Pew");
    }
}
