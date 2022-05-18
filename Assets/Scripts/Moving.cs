using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [Range(0,1)]
    public float speed = 0.5f;

    [Range(0,1)]
    public float frictionValue = 0.9f;

    private Rigidbody rb;
    private Vector3 jumpMovement = new Vector3(0f, 200.0f, 0f);
    private float movementX;
    private float movementY;
    private float movementZ;
    private int score = 0;
    public Transform CameraTransform;
    public float CameraRotation;
    //public float CameraAngle;
    private float pi = 3.14f;
    private float mods = 1;
    public float CameraAngle;
    public Camera CameraObject;
    private int FovTarget;
    private float CameraFOV;
    private Transform OwnTransform;
    private Vector3 CameraOffset = new Vector3(20,20,20);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OwnTransform = GetComponent<Transform>();
    }

    private void GradualFOVChange()
    {
        //if (CameraObject.fieldOfView > FovTarget)
        //{
        //    CameraObject.fieldOfView --;
        //}
        //else if (CameraObject.fieldOfView < FovTarget)
        //{
        //   CameraObject.fieldOfView++;
        //}
        //else
        //{
        ///    CameraObject.fieldOfView = FovTarget;
        //}
        CameraObject.fieldOfView += (FovTarget - CameraObject.fieldOfView ) / 2;
        CameraFOV = CameraObject.fieldOfView;
    }

    private void Move()
    {
        if (Input.GetKey("w"))
        {
            movementX += Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
            movementY += Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
        }
        if (Input.GetKey("a"))
        {
            movementX -= Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
            movementY += Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
        }
        if (Input.GetKey("s"))
        {
            movementX -= Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
            movementY -= Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
        }
        if (Input.GetKey("d"))
        {
            movementX += Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
            movementY -= Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed * mods;
        }
    }
    private void Friction()
    {
        movementX *= frictionValue;
        movementY *= frictionValue;
    }
    private void Update()
    {
      FovTarget = 70;
      GradualFOVChange();
    }
    private void FixedUpdate()
    {
        Move();
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        OwnTransform.position += movement * speed;
        //if (Input.GetKeyDown(KeyCode.Space) && TargetObject.position.y < .6)
        //{
        //    rb.AddForce(jumpMovement);
        //}
        Friction();
        //CameraObject.transform.rotation.eulerAngles = CameraAngle;
      }
    public void LateUpdate()
    {
      //Make the camera follow the Player

      CameraObject.transform.position = OwnTransform.position + CameraOffset;
      //Make Camera Point To Player
      CameraRotation = CameraTransform.rotation.eulerAngles.y;
      CameraObject.transform.rotation.eulerAngles = CameraRotation;


    }


}
