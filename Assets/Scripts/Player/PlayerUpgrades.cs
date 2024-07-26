using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] public List<PossibleUpgrades> Upgrades;
    //Initializes Upgrade List on Startup
    void Start()
    {
        Upgrades = new List<PossibleUpgrades>();
    }

}
