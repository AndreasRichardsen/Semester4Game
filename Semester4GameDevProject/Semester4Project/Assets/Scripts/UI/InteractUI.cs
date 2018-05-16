using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour {

    public Text interactText;

	// Use this for initialization
	void Start ()
    {
        interactText = GameObject.Find("CanvasPlayerInterface/InteractUI/InteractText").GetComponent<Text>();    
        interactText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void NPCInteract()
    {
        interactText.gameObject.SetActive(true);
        interactText.text = (GameManager.GM.interact.ToString() + "Interact");
    }

    void ItemInteract()
    {
        interactText.gameObject.SetActive(true);
        interactText.text = ("To pick up item press " + GameManager.GM.interact.ToString());
    }

    void EndInteraction()
    {
        interactText.gameObject.SetActive(false);
    }
}
