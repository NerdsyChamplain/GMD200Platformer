using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    public float moveSpeed;
    private int pointIndex = 0;
    private Transform currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.004f;
        pointIndex = 0;
        currentPoint = movePoints[pointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, moveSpeed);
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.01f)
        {
            pointIndex++;
            pointIndex %= movePoints.Length;
            currentPoint = movePoints[pointIndex];
        }
    }
}
