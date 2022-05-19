using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [Range(0,10)]
    public float speed = 0.5f;

    [Range(0,1)]
    public float frictionValue = 0.9f;
    public bool RecalculateMovement = false;
    private Rigidbody rb;
    private Vector3 jumpMovement = new Vector3(0f, 200.0f, 0f);
    private float movementX;
    private float movementY;
    private float movementZ;
    private int score = 0;
    public Transform CameraTransform;
    public float CameraRotation;
    //public float CameraAngle;
    private const float pi = 3.14f;
    public float CameraAngle;
    public Camera CameraObject;
    private int FovTarget;
    private float CameraFOV;
    private Transform OwnTransform;
    private Vector3 CameraOffset = new Vector3(20,20,20);
    private Vector3 LeftMovement;
    private Vector3 RightMovement;
    private Vector3 UpMovement;
    private Vector3 DownMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OwnTransform = GetComponent<Transform>();
        LeftMovement = new Vector3(-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles.y * pi / 180) * speed,0f,Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
        RightMovement = new Vector3(Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,-Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
        UpMovement = new Vector3(Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
        DownMovement = new Vector3(-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
    }
    void  Update() {
      if (RecalculateMovement) {
        RecalculateMovementVectors();
        RecalculateMovement = false;
      }
      return;
    }

    void RecalculateMovementVectors()
    {
      LeftMovement = new Vector3(-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles.y * pi / 180) * speed,0f,Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
      RightMovement = new Vector3(Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,-Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
      UpMovement = new Vector3(Mathf.Sin(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);
      DownMovement = new Vector3(-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed,0f,-Mathf.Cos(CameraTransform.transform.rotation.eulerAngles[1] * pi / 180) * speed);

    }


    private void FixedUpdate()
    {
      if (Input.GetKey("w"))
      {
          rb.AddForce(UpMovement * speed);

      }
      if (Input.GetKey("a"))
      {
          rb.AddForce(LeftMovement * speed);
      }
      if (Input.GetKey("s"))
      {
          rb.AddForce(DownMovement * speed);
      }
      if (Input.GetKey("d"))
      {
          rb.AddForce(RightMovement * speed);
      }
        //if (Input.GetKeyDown(KeyCode.Space) && TargetObject.position.y < .6)
        //{
        //    rb.AddForce(jumpMovement);
        //}
        //CameraObject.transform.rotation.eulerAngles = CameraAngle;
      }
    public void LateUpdate()
    {
      //Make the camera follow the Player

      CameraObject.transform.position = OwnTransform.position + CameraOffset;
      //Make Camera Point To Player
      //CameraObject.transform.rotation = Quaternion.Euler(new Vector3(34f,CameraRotation,0f));


    }


}
