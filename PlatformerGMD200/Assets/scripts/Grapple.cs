using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public LayerMask hitLayer;
    //code aquired from: https://www.youtube.com/watch?v=P-UscoFwaE4
    //edited by: Josh Scalia to make it stop on colliding with an object
    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.positionCount = 2;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //raycast
            //theres a raycast that will take a bool and set that as true or false depending on the hit
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.right, 10.0f, hitLayer);// LayerMask.NameToLayer("Ground"));
            if (rayHit.collider != null)
            {
                Debug.Log("hit wall");
                _lineRenderer.SetPosition(0, rayHit.collider.transform.position);
                _lineRenderer.SetPosition(1, transform.position);
                _distanceJoint.connectedAnchor = rayHit.collider.transform.position;
            }
            else
            {
                Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _lineRenderer.SetPosition(0, mousePos);
                _lineRenderer.SetPosition(1, transform.position);
                _distanceJoint.connectedAnchor = mousePos;
            }
            //conditional check, true value, false value
            Vector3 endPoint = (rayHit.collider != null) ? rayHit.point : transform.position + transform.right * 10.0f;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }
}
