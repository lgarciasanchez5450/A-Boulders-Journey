using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    private Moving playerController;
    private Rigidbody PlayerRB;
    public GameObject Boulder;
    private StickToPlayer boulderController;
    private Rigidbody BoulderRB;
    private Vector3 PlayerStartPos;
    private Vector3 BoulderStartPos;

    void Awake()
    {
        playerController = Player.GetComponent<Moving>();
        boulderController = Boulder.GetComponent<StickToPlayer>();
        PlayerRB = Player.GetComponent<Rigidbody>();
        BoulderRB = Boulder.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerStartPos = Player.transform.position;
        BoulderStartPos = Boulder.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void respawn()
    {
        Player.transform.position = PlayerStartPos;
        Boulder.transform.position = BoulderStartPos;
        playerController.MagicallyRevive();
        boulderController.Start();
        PlayerRB.velocity = Vector3.zero;
        BoulderRB.velocity = Vector3.zero;
    }
}
