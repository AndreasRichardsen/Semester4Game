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
        PassageLocation = new Vector3(passage.transform.position.x, passage.transform.position.y + 1, passage.transform.position.z + 3);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = PassageLocation;
        }
    }
}
