using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownStick : MonoBehaviour
{
    public PlayMove player;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints.None;
    }
}
