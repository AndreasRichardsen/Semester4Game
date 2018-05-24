using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectForMax : Quest
{
    void Start()
    {
        QuestName = "" +
            "Search for Death's Fruit for Max";
        Description = "Give Max a Death's fruit.";
        ItemReward = ItemDatabase.Instance.GetItem("GoblinAxe");
        ExperienceReward = 100;

        Goals.Add(new CollectGoal(this, "DeathsFruit", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
