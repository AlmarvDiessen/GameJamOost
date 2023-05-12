using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //instances
    private BasicMovement movement;
    private BasicJump jump;
    //fields
    private float speed = 1.5f, jumpF = 2.8f;
    private float inpH;
    private Vector2 _direction;
    //lists
    private List<Disease> diseases = new List<Disease>();
    [SerializeField] private Animator animation;

    //properties
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    //METHODS
    void Start()
    {
        movement = GetComponent<BasicMovement>();
        jump = GetComponent<BasicJump>();
        Disease disease = new SightSickness(2f, 2f);
        diseases.Add(disease);
    }
 
    private void FixedUpdate()//calls scripts that should be updated
    {
        Walking();
    }
    private void Update()
    {
        Jumping();
        ToLow();
        foreach (Disease disease in diseases)
        {
            disease.ApplyEffect();
        }
        float movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            animation.SetBool("Animator", true); ;
            gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
            sr.flipX = false;
        }
        if (movement < 0)
        {
            animation.SetBool("Animator", true);
            gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr);
            sr.flipX = true;
        }
        if (movement == 0)
        {
            animation.SetBool("Animator", false);
        }
    }
  
    private void Walking()
    {
        inpH = Input.GetAxis("Horizontal");//gets the horizontal input
        _direction = new Vector2(inpH, 0);//gets direction
        //gives direction and calls Move. The second argument is the speed
        movement.Move(_direction,speed);
    }
    private void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //calls jump function and gives the jump force as argument
            jump.Jump(jumpF);
        }
    }
    
    private void ToLow()
    {
        if (transform.position.y < -4.1)
        {
            //results.GameOver();
            gameObject.SetActive(false);
        }
    }
}
