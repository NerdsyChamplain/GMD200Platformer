using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public float jumpForce;
    private float xMoveIn;
    private bool canJump;
    public float speed;
    private Rigidbody2D rb;
    private float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isCol, sideCol1, sideCol2;
    public Transform sideStick1, sideStick2;
    public bool isGrounded, isMoving;
    public Transform checkPoint;
    public SceneChange sceneChanger;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        jumpForce = 400f;
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        xMoveIn = Input.GetAxis("Horizontal") * speed;
        if(xMoveIn < 0.001)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        isGrounded = isCol;
    }
    private void FixedUpdate()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        Collider2D wallCol = Physics2D.OverlapCircle(sideStick1.position, groundCheckRadius, groundLayer);
        Collider2D wallCol2 = Physics2D.OverlapCircle(sideStick2.position, groundCheckRadius, groundLayer);

        isCol = col != null;
        sideCol1 = wallCol != null;
        sideCol2 = wallCol2 != null;
        rb.velocity = new Vector2(xMoveIn, rb.velocity.y);
        if(canJump)
        {
            if(isCol || sideCol1 || sideCol2)
            {
                rb.AddForce(Vector2.up * jumpForce);
                canJump = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("movingPlat"))
        {
            transform.SetParent(other.transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("movingPlat"))
        {
            transform.SetParent(null, true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("hazard"))
        {
            Respawn();
        }
        else if(other.gameObject.CompareTag("checkpoint"))
        {
            checkPoint = other.transform;
        }
        if(other.gameObject.CompareTag("goal"))
        {
            //change the scene
            sceneChanger.SwitchScene();
        }
    }
    private void Respawn()
    {
        transform.position = checkPoint.position;
    }
}
