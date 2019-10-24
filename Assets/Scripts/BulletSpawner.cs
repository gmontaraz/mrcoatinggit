using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator cam_anim;
    private void Start()
    {
        objectpool = objectpool.Instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            cam_anim.SetTrigger("Shake");
            Spawn();
        }
    }
    private void Spawn()
    {
        objectpool.Instance.Spawn("Bullet", transform.position, Quaternion.identity);
    }
    objectpool objectpool;
    [SerializeField] private float cadence;
}
