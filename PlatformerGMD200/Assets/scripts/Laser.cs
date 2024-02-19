using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Camera cam;
    public LayerMask hitLayer;
    public Transform player;
    public Rigidbody2D rotPoint;
    private Vector2 mousePos;
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = new Vector2(mousePos.x - player.position.x, mousePos.y - player.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rotPoint.rotation = angle;
        //raycast
        //theres a raycast that will take a bool and set that as true or false depending on the hit
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.right, 10.0f, hitLayer);// LayerMask.NameToLayer("Ground"));
        if (rayHit.collider != null)
        {
            Debug.Log("hit wall");
        }
        //conditional check, true value, false value
        Vector3 endPoint = (rayHit.collider != null) ? rayHit.point : transform.position + transform.right * 10.0f;
        //set line renderer positions, positioncount is number of positions it checks

        lineRenderer.positionCount = 2;
        //lineRenderer.SetPositions(new Vector3[] { transform.position, endPoint });


    }
}
