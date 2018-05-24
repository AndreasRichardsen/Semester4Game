using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Vector3 PassageLocation { get; set; }
    public Passage passage;
    public Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();

        PassageLocation = new Vector3(passage.GetComponentInChildren<Transform>().GetChild(0).transform.position.x, passage.GetComponentInChildren<Transform>().GetChild(0).transform.position.y, passage.GetComponentInChildren<Transform>().GetChild(0).transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = PassageLocation;
        }
    }
}
