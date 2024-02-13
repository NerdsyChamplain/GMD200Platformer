using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject turHead;
    public Transform rotPoint;
    public PlayMove player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //rotPoint.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        turHead.transform.RotateAround(rotPoint.position, Vector3.forward, angle);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hazard"))
        {
            Destroy(gameObject);
        }
    }
}
