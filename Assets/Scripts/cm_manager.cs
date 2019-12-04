using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cm_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        script.m_Follow= GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CinemachineVirtualCamera script;
}
