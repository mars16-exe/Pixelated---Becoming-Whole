using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focalPoint : MonoBehaviour
{
    public GameObject aim;

    // Update is called once per frame
    void Update()
    {
     transform.LookAt(aim.transform);
    }
}
