using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Transform rotOrigin, rotPoint;
    public GameObject turner;
    // Update is called once per frame
    void Update()
    {
        turner.transform.RotateAround(rotPoint.position, Vector3.forward, 20 * Time.deltaTime);
    }
}
