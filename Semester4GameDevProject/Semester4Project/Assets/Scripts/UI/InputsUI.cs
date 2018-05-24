using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputsUI : MonoBehaviour {

    Transform InputsMenu;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;
    int amountOfButtons;

    bool waitingForKey;

	// Use this for initialization
	void Start ()
    {
        InputsMenu = transform.Find("InputsMenu");
        InputsMenu.gameObject.SetActive(false);
        waitingForKey = false;
        amountOfButtons = 10;

        for(int i = 0; i < amountOfButtons; i++)
        {
            if(InputsMenu.GetChild(i).name == "ForwardKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.forward.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "BackwardKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.backward.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "LeftKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.left.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "RightKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.right.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "JumpKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "DashKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.dash.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "CrouchKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.crouch.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "InteractKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.interact.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "InventoryKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.inventory.ToString();
            }
            else if (InputsMenu.GetChild(i).name == "AttackKey")
            {
                InputsMenu.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.attack.ToString();
            }
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator waitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return waitForKey();
        switch (keyName)
        {
            case "forward":
                GameManager.GM.forward = newKey;
                buttonText.text = GameManager.GM.forward.ToString();
                PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString());
                break;
            case "backward":
                GameManager.GM.backward = newKey;
                buttonText.text = GameManager.GM.backward.ToString();
                PlayerPrefs.SetString("backwardKey", GameManager.GM.backward.ToString());
                break;
            case "left":
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString());
                break;
            case "right":
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("RightKey", GameManager.GM.right.ToString());
                break;
            case "jump":
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("JumpKey", GameManager.GM.jump.ToString());
                break;
            case "dash":
                GameManager.GM.dash = newKey;
                buttonText.text = GameManager.GM.dash.ToString();
                PlayerPrefs.SetString("DashKey", GameManager.GM.dash.ToString());
                break;
            case "crouch":
                GameManager.GM.crouch = newKey;
                buttonText.text = GameManager.GM.crouch.ToString();
                PlayerPrefs.SetString("CrouchKey", GameManager.GM.crouch.ToString());
                break;
            case "interact":
                GameManager.GM.interact = newKey;
                buttonText.text = GameManager.GM.interact.ToString();
                PlayerPrefs.SetString("InteractKey", GameManager.GM.interact.ToString());
                break;
            case "inventory":
                GameManager.GM.inventory = newKey;
                buttonText.text = GameManager.GM.inventory.ToString();
                PlayerPrefs.SetString("InventoryKey", GameManager.GM.inventory.ToString());
                break;
            case "attack":
                GameManager.GM.attack = newKey;
                buttonText.text = GameManager.GM.attack.ToString();
                PlayerPrefs.SetString("AttackKey", GameManager.GM.attack.ToString());
                break;
        }
    }

}
