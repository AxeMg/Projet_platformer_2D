using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    private float dist;
    [SerializeField] private float howClose = 10f;
    [SerializeField] private float bulletSpeed = 100f;
    public float fireRate, nextFire;
    public Transform head,barrel;
    public GameObject _projectile;
    Transform _Player;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookTarget();
        
    }

    void LookTarget()
    {
        dist = Vector2.Distance(_Player.position, transform.position);
        if (dist <= howClose ) 
        {
            head.LookAt(_Player);
            if(Time.time >= nextFire ) 
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();

            }
            
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(_projectile, barrel.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);
        Destroy(clone, 3);
    }
}
