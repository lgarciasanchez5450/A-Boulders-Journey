using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StickToPlayer : MonoBehaviour
{
    private Moving playerController;
    private MovingForBoulder otherOwnController;
    public GameObject Player;
    public bool IsHeld;
    private Rigidbody rb;
    private SphereCollider collider;
    public bool PickUpAble;
    [Range(1, 4)]
    public float Weight;
    public TextMeshProUGUI text;
    public TextMeshProUGUI killText;
    public Button respawnButton;
    public Button idkButton;
    private Collider playerCollider;
    void Awake()
    {
        playerController = Player.GetComponent<Moving>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        otherOwnController = GetComponent<MovingForBoulder>();
        playerCollider = Player.GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        respawnButton.gameObject.SetActive(false);
        idkButton.gameObject.SetActive(false);
        killText.enabled = false;
        IsHeld = false;
        PickUpAble = false;
        Weight = 3f;
        rb.mass = Weight;
        otherOwnController.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }
 
    //Called once upon being picked Up
    public void setBoulderAngle(float newAngle)
    {
        otherOwnController.Angle = newAngle;
    }

    public void StartPickUp()
    {
        if (PickUpAble)
        {
            IsHeld = true;
            otherOwnController.enabled = true;
            text.text = "";
            playerController.enabled = false;
            playerCollider.enabled = false;
        }
    }

    public void SetDown()
    {
        playerController.StartCoolDown();
        playerCollider.enabled = true;
        otherOwnController.enabled = false;
        playerController.enabled = true;
        IsHeld = false;


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelTrigger")
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y + 1);
        }
        else if (other.gameObject.tag == "Kill")
        {
            playerController.MakeUnAlive();
            killText.enabled = true;
            respawnButton.gameObject.SetActive(true);
            idkButton.gameObject.SetActive(true);

        }
    }
}
