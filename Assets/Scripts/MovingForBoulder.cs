using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForBoulder : MonoBehaviour
{
    private Rigidbody rb;
    private StickToPlayer otherScript;
    private Vector3 ForwardMovement;
    private Vector3 BackwardMovement;
    public float Angle;
    private bool activated = false;
    private const float pi = 3.14f;
    public float speed;

    private void RecalculateMovementVectors()
    {
        ForwardMovement  = new Vector3(Mathf.Cos(pi / 180 * Angle + pi) * speed/2, 0f, Mathf.Sin(pi / 180 * Angle + pi) * speed/2);
        BackwardMovement = new Vector3(Mathf.Cos(pi / 180 * Angle)      * speed/2, 0f, Mathf.Sin(pi / 180 * Angle)      * speed/2);

    }
    public void Activate()
    {
        activated = true;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activated)
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(ForwardMovement*speed);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(BackwardMovement * speed);
            }
        }
    }
}
