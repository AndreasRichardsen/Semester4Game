using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    public Quest Quest { get; set; }

    public GameObject quests;
    public string questType;

    public override void StartInteraction()
    {
        if(!AssignedQuest && !Helped)
        {
            base.StartInteraction();
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            PrepareStartInteraction();
            CheckQuest();
        }
        else
        {
            PrepareStartInteraction();
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for the help" }, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for the help" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Do the job or no reward!!!" }, name);
        }
    }
}
