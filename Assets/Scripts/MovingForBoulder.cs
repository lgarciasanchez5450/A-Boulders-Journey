using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForBoulder : MonoBehaviour
{
    private Rigidbody rb;
    private StickToPlayer otherScript;
    private Vector3 ForwardMovement;
    private Vector3 BackwardMovement;
    public Camera camera;
    public float Angle;
    private const float pi = 3.14f;
    public float speed;
    public float CameraHeight;
    public float CameraDist;
    private Vector3 CameraOffset;
    private Vector3 CameraRotation;
    public GameObject Player;
    private Moving playerController;
    private Vector3 playerOffset;

    private void RecalculateMovementVectors()
    {
        ForwardMovement  = new Vector3(Mathf.Cos(pi / 180 * Angle + pi) * speed/2, 0f, Mathf.Sin(pi / 180 * Angle + pi) * speed/2);
        BackwardMovement = new Vector3(Mathf.Cos(pi / 180 * Angle)      * speed/2, 0f, Mathf.Sin(pi / 180 * Angle)      * speed/2);
        playerOffset = new Vector3(Mathf.Cos(pi / 180 * Angle), 0f, Mathf.Sin(pi / 180 * Angle));
  
    }
    
    void RecalculateCamera()
    {
        CameraOffset = new Vector3(CameraDist * Mathf.Cos(pi / 180 * Angle), CameraHeight, CameraDist * Mathf.Sin(pi / 180 * Angle));
        CameraRotation = new Vector3(180 * Mathf.Atan(CameraHeight / CameraDist) / pi, -Angle - 90, 0f);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerController = Player.GetComponent<Moving>();
        otherScript = GetComponent<StickToPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        RecalculateMovementVectors();
        RecalculateCamera();
        playerOffset = new Vector3(Mathf.Cos(pi / 180 * Angle), 0f, Mathf.Sin(pi / 180 * Angle));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
             rb.AddForce(ForwardMovement*speed);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(BackwardMovement * speed);
        }
        if (Input.GetKey("a"))
        {
            Angle++;
            RecalculateMovementVectors();
            RecalculateCamera();
        }
        if (Input.GetKey("d"))
        {
            Angle--;
            RecalculateMovementVectors();
            RecalculateCamera();
        }
        if (Input.GetKeyDown("g"))
        {
            Debug.Log("Trying To Set Down!");
            playerController.CameraAngle = Angle % 360;
            otherScript.SetDown();


        }
    }
    void LateUpdate()
    {
        //Set Camera transform
        camera.transform.position = transform.position + CameraOffset;
        camera.transform.rotation = Quaternion.Euler(CameraRotation);
        //Set Player transform
        Player.transform.position = transform.position + playerOffset;
    }
}
