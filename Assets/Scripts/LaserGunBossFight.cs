using System.Collections;
using Unity.Burst.CompilerServices;
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

    private bool isShooting = false;


    private void Awake()
    {
        isShooting = false;
        StopCoroutine(ShootLaserBoss());
        b_lineRenderer.enabled = false;
        b_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        StartCoroutine(ShootLaserBoss());
    }

    IEnumerator ShootLaserBoss()
    {
        b_lineRenderer.enabled = true;
        yield return new WaitForSeconds(shootCharge);
        FX_ChargeLaser1.Stop();
        FX_ChargeLaser2.Stop();
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        Physics2D.queriesHitTriggers = false;
        Physics2D.Raycast(b_transform.position, dir, defDistanceRayBoss);
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, dir);
        Draw2DRayBoss(laserFirePointBoss.position, _hit.point);
        if (_hit.transform.CompareTag("Player"))
        {
            triggerDeathBoss.Death();
        }
        yield return new WaitForSeconds(shootDuration);


    }


    void Draw2DRayBoss(Vector2 startPos, Vector2 endPos)
    {
        
        isShooting = true;
        b_lineRenderer.SetPosition(0, startPos);
        b_lineRenderer.SetPosition(1, endPos);

    }


}
