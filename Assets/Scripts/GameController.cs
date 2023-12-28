using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float maxdistance;
    public float max;
    public LayerMask player;
    public LayerMask moveplayer;
    RaycastHit2D hitplayer;
    RaycastHit2D hitmoveplayer;
    Vector2 targetplayer;
    Vector2 targetmoveplayer;
    Vector2 directionPlayer;
    public bool hit = false;
    public float speed;
    public GameObject selectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Movetarget()
    {
        selectedPlayer.transform.position = Vector2.Lerp(selectedPlayer.transform.position, targetplayer, speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, targetplayer) < 0.1f)
        {
            hit = false;
        }
    }
    public void RayCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                selectedPlayer = hit.collider.gameObject;
            }
            else
            {
                selectedPlayer = null;
            }
        }

       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }
        if (Input.GetMouseButtonDown(1))
        {
            hit = true;
            targetplayer = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (hit)
        {
            Movetarget();
        }
    }
}
