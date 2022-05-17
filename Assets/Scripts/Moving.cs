using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    private float speed = 0.5f;
    public float frictionValue = 0.9f;
    private Rigidbody rb;
    private Vector3 jumpMovement = new Vector3(0f, 200.0f, 0f);
    private float movementX;
    private float movementY;
    private float movementZ;
    private int score = 0;
    public Transform CameraTransform;
    //public float CameraAngle;
    private float pi = 3.14f;
    private float mods = 1;
    public Camera CameraObject;
    private int FovTarget;
    private float CameraFOV;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.AddForce(movement * speed);
        //if (Input.GetKeyDown(KeyCode.Space) && TargetObject.position.y < .6)
        //{
        //    rb.AddForce(jumpMovement);
        //}
        Friction();
        //CameraAngle = CameraTransform.transform.rotation.eulerAngles[1];
    }


}
