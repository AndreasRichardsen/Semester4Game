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
            base.StartInteraction();
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
            foreach(Goal g in Quest.Goals)
            {
                if (g.GetType() == typeof(CollectGoal))
                {
                    foreach (CollectGoal goal in Quest.Goals)
                    {
                        for (int i = 0; i < goal.RequiredAmount; i++)
                        {
                            Item item = ItemDatabase.Instance.GetItem(goal.ItemSlug);
                            InventoryController.Instance.playerItems.Remove(item);
                            UIEventHandler.ItemDeletedFromInventory(item);
                        }
                    }
                    break;
                }
            } 

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
