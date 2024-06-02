using System.Collections;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class LaserGunBossFight : MonoBehaviour
{
    [SerializeField] private float defDistanceRayBoss = 100;
    public Transform laserFirePointBoss;
    public LineRenderer b_lineRenderer;
    public TriggerDeath triggerDeathBoss;
    Transform b_transform;
    [SerializeField] private float shootCharge;
    [SerializeField] private float shootDuration;

    public ParticleSystem FX_ChargeLaser1;
    public ParticleSystem FX_ChargeLaser2;

    public bool isShooting;
    public Animator bossAnimator;

    private void Start()
    {

        b_lineRenderer = GetComponent<LineRenderer>();
        b_transform = GetComponent<Transform>();
    }

    public void OnEnable()
    {
        isShooting = false;
        b_lineRenderer.enabled = false;
    }

    private void Update()
    {
        Shoot();

    }

    private void Shoot()
    {
        if (isShooting)
        {
            
            float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, dir);
            Draw2DRayBoss(laserFirePointBoss.position, _hit.point);
            if (_hit.transform.CompareTag("Player"))
            {
                //isShooting = false;
                //b_lineRenderer.enabled = false;
                triggerDeathBoss.isDead = true;
                //StopCoroutine(ShootLaserBoss());
            }
        }
    }

    public IEnumerator ShootLaserBoss()
    {
        //Debug.Log("On rentre dans la coco");
        yield return new WaitForSeconds(shootCharge);
        FX_ChargeLaser1.Stop();
        FX_ChargeLaser2.Stop();
        isShooting = true;
        bossAnimator.SetBool("Attack", true);
        yield return new WaitForSeconds(shootDuration);
        bossAnimator.SetBool("Attack", false);
        b_lineRenderer.enabled = false;
        isShooting = false;
        StopCoroutine(ShootLaserBoss());
        
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

    public void ResetVar()
    {
        b_lineRenderer.enabled = false;
        isShooting = false;
    }



}
