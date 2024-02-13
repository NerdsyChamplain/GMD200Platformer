using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool faceRight = true;
    public Animator animator;
    public PlayMove playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(faceRight && rb.velocity.x < -0.1)
        {
            Flip();
        }
        else if(!faceRight && rb.velocity.x > 0.1)
        {
            Flip();
        }
        animator.SetFloat("MoveSpeedX", Mathf.Abs(rb.velocity.x) / playerMovement.speed);
        animator.SetBool("isGround", playerMovement.isGrounded);
    }
    private void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
