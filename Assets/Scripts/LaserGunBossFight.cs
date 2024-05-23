using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class LaserGunBossFight : MonoBehaviour
{
    [SerializeField] private float defDistanceRayBoss = 100;
    public Transform laserFirePointBoss;
    private LineRenderer b_lineRenderer;
    public TriggerDeath triggerDeathBoss;
    Transform b_transform;
    [SerializeField] private float shootCharge;
    [SerializeField] private float shootDuration;

    public ParticleSystem FX_ChargeLaser1;
    public ParticleSystem FX_ChargeLaser2;

    public bool isShooting;
    public bool canShoot;


    private void Awake()
    {

        b_lineRenderer = GetComponent<LineRenderer>();
        b_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (isShooting)
        {
            float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, dir);
            Draw2DRayBoss(laserFirePointBoss.position, _hit.point);
            if (_hit.transform.CompareTag("Player"))
            {
                triggerDeathBoss.Death();
            }
        }

    }

    public IEnumerator ShootLaserBoss()
    {
        canShoot = false;
        
        b_lineRenderer.enabled = false;
        Debug.Log("On rentre dans la coco");
        yield return new WaitForSeconds(shootCharge);
        b_lineRenderer.enabled = false;
        isShooting = true;
        FX_ChargeLaser1.Stop();
        FX_ChargeLaser2.Stop();

        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        Physics2D.queriesHitTriggers = false;
        //Physics2D.Raycast(b_transform.position, dir, defDistanceRayBoss);
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, dir);
        Draw2DRayBoss(laserFirePointBoss.position, _hit.point);
        //if (_hit.transform.CompareTag("Player"))
        //{
        //    triggerDeathBoss.Death();
        //}
        yield return new WaitForSeconds(shootDuration);
        if (_hit.transform.CompareTag("Player"))
        {
            triggerDeathBoss.Death();
        }
        canShoot = true;
        b_lineRenderer.enabled = false;
        isShooting = false;
        Debug.Log("On sort de la coco");
    }


    void Draw2DRayBoss(Vector2 startPos, Vector2 endPos)
    {
        b_lineRenderer.enabled = true;
        b_lineRenderer.SetPosition(0, startPos);
        b_lineRenderer.SetPosition(1, endPos);

    }

    public void CanShoot()
    {
        StartCoroutine(ShootLaserBoss());

    }

    public void CantShoot()
    {
        StopCoroutine(ShootLaserBoss());
    }

}
