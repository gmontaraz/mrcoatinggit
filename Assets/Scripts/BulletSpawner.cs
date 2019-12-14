using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator cam_anim;
    private void Start()
    {
        ActivateWeapon();
    }
    public void ActivateWeapon()
    {
        objectpool = objectpool.Instance;
        
        activated = true;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A)&&activated &&cadence<=0)
        {
            cam_anim = GameObject.Find("Main Camera").GetComponent<Animator>();
            cam_anim.SetTrigger("Shake");
            Spawn();
            cadence = 0.2f;
        }
        if (cadence > 0)
        {
            cadence -= Time.deltaTime;
        }
    }
    private void Spawn()
    {
        objectpool.Instance.Spawn("Bullet", transform.position, transform.rotation);
    }
    objectpool objectpool;
    private bool activated = false;
    [SerializeField] private float cadence;
}
