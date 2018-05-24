using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    void Start()
    {
        QuestName = "" +
            "Ghost Slayer";
        Description = "Kill 5 ghosts";
        ItemReward = ItemDatabase.Instance.GetItem("BottleOfUnicornBlood");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this, 1, Description, false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
}
