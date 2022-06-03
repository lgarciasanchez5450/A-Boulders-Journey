using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    public GameObject FallenTrunk;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        FallenTrunk.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    public void Press()
    {
        MakeItFall();
    }
    public void MakeItFall()
    {
        gameObject.SetActive(false);
        FallenTrunk.gameObject.SetActive(true);
    }
}
