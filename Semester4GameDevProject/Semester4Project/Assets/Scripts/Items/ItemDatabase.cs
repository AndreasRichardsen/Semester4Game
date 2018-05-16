using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();
    }

    void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
    }

    public Item GetItem(string itemSlug)
    {
        foreach(Item item in Items)
        {
            if (item.ObjectSlug.Equals(itemSlug))
            return item;
        }
        return null;
    }

}
