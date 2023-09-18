using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationary : MonoBehaviour
{

    public float RotateSP;
    public float LOS;
    public float angle = 45.0f;
    public LineRenderer LineOfSight;
    public Gradient redC;
    public Gradient greenC;
    // Start is called before the first frame update


    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * RotateSP * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, LOS);
        if (hitInfo.collider != null)
        {

            if (hitInfo.collider.isTrigger) //detect to see if Ray Cast detected dark zone. If so don't kill player.
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                LineOfSight.SetPosition(1, hitInfo.point);
                LineOfSight.colorGradient = redC;
            }
            else
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                LineOfSight.SetPosition(1, hitInfo.point);
                LineOfSight.colorGradient = redC;
            }
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * LOS, Color.green);
            LineOfSight.SetPosition(1, transform.position + transform.right * LOS);
            LineOfSight.colorGradient = greenC;
        }

        LineOfSight.SetPosition(0, transform.position);
    }
}
