using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : NPC
{
    public Vector3 TeleportLocation { get; set; }
    [SerializeField]
    Portal[] linkedPortals;
    PortalController PortalController { get; set; }

    void Start()
    {
        PortalController = FindObjectOfType<PortalController>();
        TeleportLocation = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
    }

    public override void StartInteraction()
    {
        PortalController.ActivatePortal(linkedPortals);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
