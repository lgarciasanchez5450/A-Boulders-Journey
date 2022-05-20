using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckForAttach : MonoBehaviour
{
    public Transform PlayerTransform;
    public TextMeshProUGUI text;
    private Vector3 OwnPos;
    private float DistToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //OwnPos = GetComponent<Transform>();
         OwnPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "Attach To The Boulder!!!";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "";    
        }
    }
}
