using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractables : MonoBehaviour, IInteractables
{
    public static bool interacted = false;

    public void EndInteraction()
    {
        throw new NotImplementedException();
    }

    public void StartInteraction()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(GameManager.GM.interact))
            {
                if (!interacted)
                {
                    StartInteraction();
                }
            }
        }
    }
}
