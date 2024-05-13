using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public bool canMove;

    [SerializeField] private float speed;
    [SerializeField] private int startPoint;
    [SerializeField] Transform[] points;
    public GameObject engrenage1;
    public GameObject engrenage2;

    private int i;
    private bool reverse;

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

            if(i == points.Length - 1)
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
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}
