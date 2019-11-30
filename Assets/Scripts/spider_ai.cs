using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class spider_ai : MonoBehaviour
{
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        search_web = true;
        bool found=false;
        foreach(GameObject swing_point in swing_points)
        {
            if (!swing_point.GetComponent<swing_manager>().occupied && !found)
            {
                web_start = swing_point;
                web.connectedBody = swing_point.transform.parent.GetComponent<Rigidbody2D>();
                finalPos = swing_point.transform.parent;
                found = true;
                swing_point.GetComponent<swing_manager>().occupied = true;
            }
        }
        if (!found)
        {
            Destroy(this.gameObject);
        }
        
        destination.target = web_start.transform;
        aipath.enabled = true;
        line.positionCount = 2;
        
        web.enabled = false;
        line.enabled = false;
    }
    private void FixedUpdate()
    {
        line.SetPosition(0, startPos.position);
        line.SetPosition(1, finalPos.position);

    }
    private void Update()
    {

        if (!search_web) { 
            player_ray = Physics2D.Raycast(this.transform.position, Vector2.down, 3f, player_layer);
            if (player_ray.collider)
            {
                web.enabled = false;
                line.enabled = false;
            }
            if (!web.enabled)
            {
                if (Physics2D.OverlapCircle(feetPos.position, 0.1f, ground_layer))
                {
                    aipath.enabled = true;
                    aipath.maxSpeed = 5f;
                }
                else
                {
                    aipath.maxSpeed = 4f;
                }

            }
        }
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            search_web = true;
            aipath.maxSpeed = 4f;
            destination.target = web_start.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("web_start")&&search_web)
        {
            aipath.enabled = false;
            destination.target = player;
            search_web = false;       
            web.enabled = true;
            line.enabled = true;
            
        }
    }

    public SpringJoint2D web;
    private bool goup=true;
    public LineRenderer line;
    public Transform startPos;
    public Transform finalPos;
    private RaycastHit2D player_ray;
    public LayerMask player_layer;
    public LayerMask ground_layer;
    public Transform feetPos;
    public AIPath aipath;
    public AIDestinationSetter destination;
    public GameObject web_start;
    private Transform player;
    private bool search_web;

    public GameObject[] swing_points;
}
