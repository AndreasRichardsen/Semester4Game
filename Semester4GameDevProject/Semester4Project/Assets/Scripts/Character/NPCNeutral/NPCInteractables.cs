using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractables : MonoBehaviour, IInteractables
{
    public static bool interacting = false;
    public string npcName;
    public string[] dialogue;

    public GameObject canvasPause;
    public GameObject dialogueUI;
    public ThirdPersonCamera thirdPersonCamera;
    //public PlayerMovement playerMovement;
    public Player player;


    void Start()
    {
        if(canvasPause == null) canvasPause = GameObject.Find("CanvasPause");
        if(thirdPersonCamera == null) thirdPersonCamera = GameObject.Find("MainCamera").GetComponent<ThirdPersonCamera>();
        if(player == null) player = GameObject.Find("Player").GetComponent<Player>();

        Cursor.visible = true;
        dialogueUI.SetActive(false);
    }

    public void StartInteraction()
    {
        thirdPersonCamera.enabled = false;
        //playerMovement.enabled = false;
        player.enabled = false;
        canvasPause.SetActive(false);

        dialogueUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        interacting = true;

        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);
    }

    public void EndInteraction()
    {
        thirdPersonCamera.enabled = true;
        //playerMovement.enabled = true;
        player.enabled = true;
        canvasPause.SetActive(true);

        dialogueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interacting = false;
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(GameManager.GM.interact))
            {
                if (!interacting)
                {
                    StartInteraction();
                }
                else
                {
                    EndInteraction();
                }
            }
        }
    }

}