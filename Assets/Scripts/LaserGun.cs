using Unity.Burst.CompilerServices;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    public TriggerDeath triggerDeath;
    Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();

        
    }

    void ShootLaser()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        /*
        if (Physics2D.Raycast(m_transform.position, dir, defDistanceRay))
        {
            //RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.right);
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, dir, defDistanceRay);
            //Draw2DRay(laserFirePoint.position, _hit.point);

            if ( _hit.transform.CompareTag("Player"))
            {
                triggerDeath.Death();
            }
        }

        
        else
        {
            //Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
            //Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right);
            Draw2DRay(laserFirePoint.position, dir);
        }
        */
        Physics2D.queriesHitTriggers = false;
        Physics2D.Raycast(m_transform.position, dir, defDistanceRay);
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, dir);
        Draw2DRay(laserFirePoint.position, _hit.point);
        if (_hit.transform.CompareTag("Player"))
        {
            triggerDeath.Death();
        }

    }
    
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
