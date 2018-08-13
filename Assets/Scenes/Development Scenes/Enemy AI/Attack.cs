using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Behaviour", menuName = "NPC AI/Behaviors/Attack", order = 1)]
public class Attack : NPCBehaviour
{

    [SerializeField] int strength; //The damage done by the attack.
    [SerializeField] float warmup; //The before the first attack.
    [SerializeField] float attackRate; //The time interval (in seconds between attacks).

    bool warmedUp = false; //Whether the npc has performed its first attack since it was initialsed.
    double intervalTime; //The time since the last attack, or the behavior was initialsed.

    public override void Plan(NPCAI npc, Scannable target)
    {
        warmedUp = false;
        intervalTime = 0;
    }

    public override void Adjust(NPCAI npc, Scannable target)
    {
        //NA
    }

    public override void Act(NPCAI npc, Scannable target)
    {

        //Debug.Log("Attacking");

        if((!warmedUp && intervalTime >= warmup) || (warmedUp && intervalTime >= attackRate))
        {
            warmedUp = true;
            target.GetComponent<PlayerStat>().TakeDamage(strength);
            intervalTime = 0;
        }

        intervalTime += Time.deltaTime;
    }
}
