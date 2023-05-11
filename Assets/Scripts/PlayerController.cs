using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour,IEntity
{
    //instances
    private BasicMovement movement;
    private BasicJump jump;
    [SerializeField] private Transform proSpawnPos;
    [SerializeField]private GameResultManager results;
    //fields
    private float inpH;
    private Vector2 _direction;
    private List<IAttack> attacks = new List<IAttack>();//list of all attacks
    private int currentAttack;
   
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
        currentAttack = 0;
    }
    public void FAttackAquirred()//when firebook gets picked up
    {
        attacks.Insert(0,GetComponent<FireAttack>());
    }
    public void IAttackAquirred()//when ice book gets picked up
    {
        attacks.Insert(1,GetComponent<IceAttack>());
    }
    public void NAttackAquirred()//when nature book gets picked up
    {
        attacks.Insert(2,GetComponent<NatureAttack>());
    }
    private void FixedUpdate()//calls scripts that should be updated
    {
        Walking();
    }
    private void Update()
    {
        Jumping();
        //Attack();
        //ChangeBook();
        ToLow();
    }
    private void ChangeBook()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            currentAttack+=1;
            //Debug.Log(currentAttack);
            currentAttack %= 3;//sets attackCount to 0 when value goes to 3 (never can exceed 2)
        }
    }
    private void Walking()
    {
        inpH = Input.GetAxis("Horizontal");//gets the horizontal input
        _direction = new Vector2(inpH, 0);//gets direction
        //gives direction and calls Move. The second argument is the speed
        movement.Move(_direction,1f);
    }
    private void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //calls jump function and gives the jump force as argument
            jump.Jump(2.8f);
        }
    }
    //private void Attack()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        try
    //        {
    //            attacks[currentAttack].Attack();//calls attack of the active attack
    //        }
    //        catch
    //        {
    //            Debug.Log("you don't have a spell book");
    //        }
    //    }
    //}
    //private void ToLow()
    //{
    //    if (transform.position.y < -4.1)
    //    {
    //        results.GameOver();
    //        gameObject.SetActive(false);
    //    }
    //}
}
