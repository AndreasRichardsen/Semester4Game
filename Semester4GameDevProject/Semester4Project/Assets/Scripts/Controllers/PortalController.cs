using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    Button button;
    Portal[] portals;
    Player player;
    GameObject panel;

    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = transform.Find("PortalUI").gameObject;
    }

    public void ActivatePortal(Portal[] portals)
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(true);
        for(int i = 0; i < portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<Text>().text = portals[i].npcName;
            int x = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(x, portals[x]); });
        }
    }

    void OnPortalButtonClick(int portalIndex, Portal portal)
    {
        player.transform.position = portal.TeleportLocation;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }
}
