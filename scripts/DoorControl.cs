using UnityEngine;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{

    public GameObject openDoor;
    public GameObject unlockDoor;
    public Door door;
    public bool doorInSightU = false;
    public bool doorInSightO = false;

    

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "RayCast")
        {
            if (door.Opened == false)
            {
                doorInSightU = true;
                unlockDoor.SetActive(true);
            }
            else
            {
                doorInSightO = true;
                openDoor.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "RayCast")
        {
            if (door.Opened == false)
            {
                doorInSightU = false;
                unlockDoor.SetActive(false);
            }
            else
            {
                doorInSightO = false;
                openDoor.SetActive(false);
            }
        }
    }

}