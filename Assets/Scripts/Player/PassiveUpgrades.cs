using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PossibleUpgrades 
{
  None,
  AttackUp,
  HealthUp,
  SpeedUp,
  AttackSpeedUp
}
public class PassiveUpgrades 
{
    public List<PossibleUpgrades> Upgrades;
    public PassiveUpgrades()
    {
        Upgrades = new List<PossibleUpgrades>();
        Upgrades.Add(PossibleUpgrades.AttackUp);
    
    }
}
