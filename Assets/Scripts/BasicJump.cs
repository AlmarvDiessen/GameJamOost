using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicJump : MonoBehaviour
{
    //instances
    private Rigidbody2D rb;
    //fields
    private bool onGround;
    private Vector2 origin;
    //properties
    public bool OnGround
    {
        get{ return onGround; }
    }
    //the layermask that needs detection. This is bind in the inspector
    [SerializeField]private LayerMask ground;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//gets rigidbody 
    }
    //fixedupdate is better for most physics related things
    private void FixedUpdate()
    {
        //Debug.Log(onGround);
        //checks if the ground layer is within a certain range
        onGround = (Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.1f),
            new Vector2(0.05f,0.5f),0, ground)!=null);
    }
    public void Jump(float jumpForce)
    {
        if (onGround)
        {//makes sure x velocity stays x velocity and y velocity will reset for better jump feel
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//jump
        }
    }
    //shows the raycast box
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.1f), new Vector2(0.05f, 0.5f));
    }
}

