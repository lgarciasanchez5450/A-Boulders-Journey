using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    private Moving playerContoller;
    public GameObject Player;
    public bool IsHeld;
    private Vector3 PosOffset;
    private Rigidbody rb;
    public bool PickUpAble;
    void Awake()
    {
        playerContoller = Player.GetComponent<Moving>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsHeld = false;
        PosOffset = new Vector3(0f, 0f, 1f);
        PickUpAble = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHeld)
        {
            transform.position = Player.transform.position + PosOffset;
        }
    }
    //Called once upon being picked Up
    public void StartPickUp()
    {
        IsHeld = true;
        rb.isKinematic = true;

    }
    public void SetDown()
    {
        IsHeld = false;
        rb.isKinematic = false;
    }
}
