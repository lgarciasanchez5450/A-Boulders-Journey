using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    [Range(0,10)]
    public float speed = 0.5f;
    public GameObject Boulder;
    public bool PickUp;
    public bool SetDown;
    private StickToPlayer BoulderScript;
    public bool RecalculateMovement = false;
    private Rigidbody rb;
    private Vector3 jumpMovement = new Vector3(0f, 200.0f, 0f);
    private float movementX;
    private float movementY;
    private float movementZ;
    private Vector3 GlideForce;
    public Transform CameraTransform;
    private const float pi = 3.14f;
    [Range(10,30)]
    public float CameraDist;
    private float PrevCameraDist;
    [Range(0,360)]
    public float CameraAngle;
    private float PrevCameraAngle;
    [Range(5, 30)]
    public float CameraHeight;
    private float prevCameraHeight;
    public Camera CameraObject;
    private int FovTarget;
    private float CameraFOV;
    private Transform OwnTransform;
    private Vector3 CameraOffset;
    private Vector3 LeftMovement;
    private Vector3 RightMovement;
    private Vector3 UpMovement;
    private Vector3 DownMovement;
    private Vector3 CameraRotation;
    private double startTime;
    private bool abletoPickUp;
    public TextMeshProUGUI killText;
    public Button respawnButton;
    public Button idkButton;
    public GameObject PhysicalButton;
    public float ButtonDist;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        OwnTransform = GetComponent<Transform>();
        BoulderScript = Boulder.GetComponent<StickToPlayer>();
    }


    public void Start()
    {
        PrevCameraAngle = CameraAngle;
        PrevCameraDist = CameraDist;
        CameraDist = 20;
        CameraHeight = 20;
        CameraOffset = new Vector3(CameraDist * Mathf.Cos(pi/180*CameraAngle), CameraHeight, CameraDist * Mathf.Sin(pi/180*CameraAngle));
        CameraRotation = new Vector3(180*Mathf.Atan(CameraHeight/CameraDist)/pi,  -CameraAngle, 0f);
        LeftMovement  = new Vector3(Mathf.Cos(pi / 180 * CameraAngle - pi/2) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle - pi/2) * speed);
        RightMovement = new Vector3(Mathf.Cos(pi / 180 * CameraAngle + pi/2) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle + pi/2) * speed);
        UpMovement    = new Vector3(Mathf.Cos(pi / 180 * CameraAngle + pi  ) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle + pi  ) * speed);
        DownMovement  = new Vector3(Mathf.Cos(pi / 180 * CameraAngle       ) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle       ) * speed);
        GlideForce = new Vector3(0, 4, 0);

    }
    public void StartCoolDown()
    {
        abletoPickUp = false;
        startTime = Time.time;
    }
    void RecalculateCamera()
    {
        CameraOffset = new Vector3(CameraDist * Mathf.Cos(pi / 180 * CameraAngle), CameraHeight, CameraDist * Mathf.Sin(pi / 180 * CameraAngle));
        CameraRotation = new Vector3(180 * Mathf.Atan(CameraHeight / CameraDist) / pi, -CameraAngle -90, 0f);
    }

    void Update()
    {
           if (RecalculateMovement)
           {
               RecalculateMovementVectors();
               RecalculateMovement = false;
           }
           else if (Input.GetKeyDown("g") && !BoulderScript.IsHeld && abletoPickUp)
           {
               if (BoulderScript.PickUpAble)
               {
                   Debug.Log("Picking Up Boulder:O");
                   BoulderScript.setBoulderAngle(CameraAngle);
                   BoulderScript.StartPickUp();
                   turnOffMovement();
               }
           }
           else if (CameraAngle != PrevCameraAngle)
           {
               RecalculateCamera();
               RecalculateMovementVectors();
               PrevCameraAngle = CameraAngle;
           }
           else if (CameraDist != PrevCameraDist)
           {
               RecalculateCamera();
               PrevCameraDist = CameraDist;
           }
           else if (CameraHeight != prevCameraHeight)
           {
               RecalculateCamera();
               prevCameraHeight = CameraHeight;
           }
           if (!abletoPickUp)
           {
               if (Time.time > startTime + 2f)
               {
                abletoPickUp = true;
               }
           }
        Debug.Log(Vector3.Distance(PhysicalButton.transform.position, OwnTransform.position));
            if (Vector3.Distance(PhysicalButton.transform.position, OwnTransform.position) < ButtonDist)
            {
                if (Input.GetKeyDown("z"))
                {
                    PhysicalButton.GetComponent<FallScript>().Press();
                }
            }
       

    }

    void RecalculateMovementVectors()
    {
        LeftMovement  = new Vector3(Mathf.Cos(pi / 180 * CameraAngle - pi / 2) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle - pi / 2) * speed);
        RightMovement = new Vector3(Mathf.Cos(pi / 180 * CameraAngle + pi / 2) * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle + pi / 2) * speed);
        UpMovement    = new Vector3(Mathf.Cos(pi / 180 * CameraAngle + pi)     * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle + pi)     * speed);
        DownMovement  = new Vector3(Mathf.Cos(pi / 180 * CameraAngle)          * speed, 0f, Mathf.Sin(pi / 180 * CameraAngle)          * speed);
        GlideForce = new Vector3(0, 4, 0);
    }

    public void turnOffMovement()
    {
      LeftMovement = Vector3.zero;
      RightMovement = Vector3.zero;
      UpMovement =  Vector3.zero;
      DownMovement = Vector3.zero;
      GlideForce = Vector3.zero;
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
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(GlideForce);
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
      CameraObject.transform.rotation = Quaternion.Euler(CameraRotation);


    }
    public void MakeUnAlive()
    {
        turnOffMovement();
    }

    public void MagicallyRevive()
    {
        RecalculateMovementVectors();
    }
    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Kill Player")
      {
            MakeUnAlive();
            killText.enabled = true;
            respawnButton.gameObject.SetActive(true);
            idkButton.gameObject.SetActive(true);
        }
    }
}
