using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class spider_ai : MonoBehaviour
{
    private void Start()
    {
        search_web = true;
        aipath.enabled = true;
        destination.target = web_start;
        line.positionCount = 2;
        
        web.enabled = false;
        line.enabled = false;
    }
    private void FixedUpdate()
    {
        line.SetPosition(0, startPos.position);
        line.SetPosition(1, finalPos.position);
        /*
        if (goup)
        { 
            web.distance -= Time.deltaTime * 1;
            if (web.distance < 0.5)
            {
                goup = false;
            }
        }
        else if(!goup)
        {
            web.distance += Time.deltaTime * 2;
            if (web.distance > 1f)
            {
                goup = true;
            }
        }
        */
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
            destination.target = web_start;
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
    public Transform web_start;
    public Transform player;
    private bool search_web;
}
