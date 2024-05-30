using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public bool canMove;

    [SerializeField] private float speed;
    [SerializeField] private int startPoint;
    [SerializeField] Transform[] points;

    [SerializeField] private float rotateSpeed;
    public GameObject engrenage1;
    public GameObject engrenage2;

    private int i;
    private bool reverse;

    [SerializeField] private AudioSource elevatorClip;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Elevator();
    }

    private void Elevator()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;
            elevatorClip.Stop();
            if (i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }

            else if (i == 0)
            {
                reverse = false;
                i++;
                return;
            }

            if(reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if(canMove)
        {
            engrenage1.transform.Rotate(0, 0, -0.5f);
            engrenage2.transform.Rotate(0, 0, 0.5f);
            elevatorClip.Play();

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

        
    }
}
