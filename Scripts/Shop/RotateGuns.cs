using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGuns : MonoBehaviour
{
    

    void Update()
    {
        transform.Rotate(0,30f * Time.deltaTime,0);
    }
}
