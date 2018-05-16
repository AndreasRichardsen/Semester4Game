using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    void Start()
    {
        QuestName = "Ultimate Slayer";
        Description = "KILL KILL KILL!!!";
        ItemReward = ItemDatabase.Instance.GetItem("GoblinAxe");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this, 0, "Kill 5 slimes", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
}
