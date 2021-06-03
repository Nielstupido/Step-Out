using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallingCardScript : MonoBehaviour
{
    
    public bool cardInsight = false;
    public GameObject cardPrompt;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "RayCast")
        {
            cardInsight = true;
            cardPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "RayCast")
        {
            cardInsight = false;
            cardPrompt.SetActive(false);
        }
    }
}
