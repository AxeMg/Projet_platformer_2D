using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class Turret : MonoBehaviour
{
    private float dist;
    [SerializeField] private float howClose = 10f;
    [SerializeField] private float bulletSpeed = 100f;
    public float fireRate, nextFire;
    public Transform head,barrel,sprite;
    public GameObject _projectile;
    private LineRenderer lineRenderer;
    private ParticleSystem _particleSystem;
    Transform _Player;

    [SerializeField] private AudioClip shootAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
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
            lineRenderer.enabled = true;
            head.LookAt(_Player);
            SpriteRotation();
            RaycastHit2D _hit = Physics2D.Raycast(_Player.position, transform.right);
            Draw2DRay(head.position, _hit.point);
            if(Time.time >= nextFire ) 
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();

            }
            
        }
        else
        {
            lineRenderer.enabled = false; 
        }
    }

    void Shoot()
    {
        SoundFXManager.instance.PlaySoundEffectClip(shootAudioClip, transform, 1f);
        _particleSystem.Play();
        GameObject clone = Instantiate(_projectile, barrel.position, transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);       
        Destroy(clone, 3);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    void SpriteRotation()
    {
        Vector3 diff = (_Player.position - sprite.transform.position);
        float angle = Mathf.Atan2(diff.y, diff.x);
        sprite.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }

}
