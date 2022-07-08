using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ammo;
    public int force = 4;

    public bool spawnAmmo()
    {
        int probability = Mathf.RoundToInt(Random.Range(0f, 1.0f) + 0.4f); // 0.4f is loot value

        if(probability == 1)            //whether enemy has potention to drop loot
        {
            Debug.Log("should spawn ammo");
            int luck = Random.Range(0, 5);   // not 5, 2*. upgradeable to 3, 4, 5

            for (int i = 0; i < luck; i++)
            {
                Instantiate(ammo, transform.position, Quaternion.Euler(0,0, Random.Range(-180, 180)));
                Rigidbody2D ammoBody = ammo.GetComponent<Rigidbody2D>();

                //pushing spawn bullets in multiple directions
                ammoBody.velocity = new Vector2(0, force);
            }

        }
        else if(probability == 0)
        {
            Debug.Log("no ammo");
            //do nothing
        }
        return true;
    }

}
