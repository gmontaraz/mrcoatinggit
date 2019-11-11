using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class spider_ai : MonoBehaviour
{
    private void Start()
    {
        line.positionCount = 2;
        aipath.enabled = false;
    }
    private void FixedUpdate()
    {
        line.SetPosition(0, startPos.position);
        line.SetPosition(1, finalPos.position);
        if (goup)
        { 
            web.distance -= Time.deltaTime * 2;
            if (web.distance < 0.5)
            {
                goup = false;
            }
        }
        else if(!goup)
        {
            web.distance += Time.deltaTime * 2;
            if (web.distance > 2)
            {
                goup = true;
            }
        }
    }
    private void Update()
    {
        player_ray = Physics2D.Raycast(this.transform.position, Vector2.down, 3f,player_layer);
        if (player_ray.collider)
        {
            web.enabled = false;
            line.enabled = false;
        }
        if (!web.enabled)
        {
            if(Physics2D.OverlapCircle(feetPos.position, 0.1f, ground_layer))
            {
                aipath.enabled = true;
                aipath.maxSpeed = 2.5f;
            }
            else
            {
                aipath.maxSpeed = 5;
            }
            
        }
    }
    private void a_star() 
    {
        
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
}
