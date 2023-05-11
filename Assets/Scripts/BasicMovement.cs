using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 _direction;
    //properties
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public Rigidbody2D RB
    {
        get { return rb; }
    }
    //methods
    void Start()
    {
        //gets rigidbody from the object that has this script
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 direction,float speed)//needs direction
    {
        //makes _direction equal to the direction received. this is used for the property "Direction"
        _direction = direction;
        //float that has the current value of the Y velocity
        float currentYVelocity = rb.velocity.y;
        //calculates movement
        //NOTE Time.deltaTime is already called here by unity itself in this line
        Vector2 newVelocity = direction * speed;
        //sets y value to current y value
        newVelocity.y = currentYVelocity;
        //updates so that it actually will move
        rb.velocity = newVelocity;
    }
}
