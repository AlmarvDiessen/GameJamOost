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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - gameObject.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
        if (hit.collider != null && CheckDistance(hit) && hit.collider.transform.name == "Player" && !interactMenu.activeSelf)
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
}
