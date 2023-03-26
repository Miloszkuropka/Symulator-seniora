using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string openDoor = "DoorOpenAnimation";
    [SerializeField] private string closeDoor = "DoorCloseAnimation";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {

                myDoor.Play(openDoor, 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                myDoor.Play(closeDoor, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}