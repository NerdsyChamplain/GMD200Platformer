using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    private float force = 500f;
    private bool canBoost = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && canBoost == true)
        {
            Vector3 boostDir = player.transform.localScale;
            boostDir.x = -Mathf.Abs(player.transform.localScale.x);
            boostDir.Normalize();
            boostDir.x *= 20;
            player.GetComponent<Rigidbody2D>().AddForce(boostDir * force);
            canBoost = false;
            StartCoroutine(boostDelay(1.5f));
        }
        else if(Input.GetKeyDown(KeyCode.E) && canBoost == true)
        {
            Vector3 boostDir = player.transform.localScale;
            boostDir.x = Mathf.Abs(player.transform.localScale.x);
            boostDir.Normalize();
            boostDir.x *= 20;
            player.GetComponent<Rigidbody2D>().AddForce(boostDir * force);
            canBoost = false;
            StartCoroutine(boostDelay(1.5f));
        }
    }
    private IEnumerator boostDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canBoost = true;
    }
}
