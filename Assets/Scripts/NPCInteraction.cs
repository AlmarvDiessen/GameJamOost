using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPCInteraction : MonoBehaviour
{
    [Header("Gets auto assinged")]
    [SerializeField] private GameObject player;
    [Header("")]
    [SerializeField] private float distance = 1;
    [SerializeField] private GameObject interactMenu;
    [Header("fill in a number that has not been used yet")]
    [SerializeField] int DebuffNO;
    PlayerController playerCon;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerCon = GameObject.Find("player").GetComponent<PlayerController>();
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - gameObject.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
        if (CheckDistance(hit) && hit.collider.transform.name == player.transform.name && !interactMenu.activeSelf)
        {
            interactMenu.SetActive(true);
        }
        else if (!CheckDistance(hit) && interactMenu.activeSelf)
        {
            interactMenu.SetActive(false);
        }
    }

    public bool CheckDistance(RaycastHit2D ray)
    {
        if (ray.distance <= distance && ray.distance != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BurdenTaken()
    {
        switch (DebuffNO)
        {
            case 1: playerCon.RandomJump();
                break;
            case 2:
                cam.GetComponent<SightSickness>().enabled = true;
                break;
            case 3:
                playerCon.Speed = -20;
                break;
            case 4:
                cam.GetComponent<ScreenShake>().enabled = true;
                break;
        }
    } 
    public void BurdenNotTaken()
    {

    }
}
