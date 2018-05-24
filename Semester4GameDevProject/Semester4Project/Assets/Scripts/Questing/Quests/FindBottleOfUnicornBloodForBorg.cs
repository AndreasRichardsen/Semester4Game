using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBottleOfUnicornBloodForBorg : Quest
{
    void Start()
    {
        QuestName = "" +
            "Get a Bottle of unicorn blood for Borg.";
        Description = "Borg desires a Bottle of unicorn blood, give him one.";
        ItemReward = ItemDatabase.Instance.GetItem("DeathsFruit");
        ExperienceReward = 100;

        Goals.Add(new CollectGoal(this, "BottleOfUnicornBlood", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
