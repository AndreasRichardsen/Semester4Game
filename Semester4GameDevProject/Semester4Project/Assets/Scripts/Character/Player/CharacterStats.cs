using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int attackDmg, int armour, int attackSpeed, int crit)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.AttackDamage, attackDmg, "Atk Dmg"),
            new BaseStat(BaseStat.BaseStatType.Armour, armour, "Armour"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "Atk Spd"),
            new BaseStat(BaseStat.BaseStatType.Crit, crit, "Crit")
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
