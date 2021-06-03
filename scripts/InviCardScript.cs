using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InviCardScript : MonoBehaviour
{
    public bool inviCardInsight = false;
    [SerializeField]private GameObject inviCardPrompt;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "RayCast")
        {
            inviCardInsight = true;
            inviCardPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "RayCast")
        {
            inviCardInsight = false;
            inviCardPrompt.SetActive(false);
        }
    }
}
