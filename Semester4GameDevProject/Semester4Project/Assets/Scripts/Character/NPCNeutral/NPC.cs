using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractables
{
    public static bool interacting = false;
    public string npcName;
    public string[] dialogue1;
    public string[] dialogue2;
    public bool onlyPlayFirstDialogue;
    public bool playSecondDialogue;

    public GameObject canvasPause;
    public GameObject dialogueUI;
    public ThirdPersonCamera thirdPersonCamera;
    public Player player;


    void Start()
    {        
        if(canvasPause == null) canvasPause = GameObject.Find("CanvasPause");
        if(thirdPersonCamera == null) thirdPersonCamera = GameObject.Find("MainCamera").GetComponent<ThirdPersonCamera>();
        if(player == null) player = GameObject.Find("Player").GetComponent<Player>();

        playSecondDialogue = false;
        Cursor.visible = true;
        dialogueUI.SetActive(false);
    }

    public virtual void StartInteraction()
    {
        PrepareStartInteraction();
        if (!playSecondDialogue || onlyPlayFirstDialogue)
        {
            DialogueSystem.Instance.AddNewDialogue(dialogue1, npcName);
            playSecondDialogue = true;
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(dialogue2, npcName);
        }
        
    }

    public void PrepareStartInteraction()
    {
        thirdPersonCamera.enabled = false;
        player.enabled = false;
        canvasPause.SetActive(false);
        Time.timeScale = 0f;

        dialogueUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        interacting = true;
    }

    public virtual void EndInteraction()
    {
        thirdPersonCamera.enabled = true;
        player.enabled = true;
        canvasPause.SetActive(true);
        Time.timeScale = 1f;

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