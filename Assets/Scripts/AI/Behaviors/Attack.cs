using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Behaviour", menuName = "NPC AI/Behaviors/Attack", order = 1)]
public class Attack : NPCBehaviour
{

    [Header("Attack Stats")]
    [SerializeField] int strength; //The damage done by the attack.
    [SerializeField] float warmup; //The before the first attack.
    [SerializeField] float attackRate; //The time interval (in seconds between attacks).
    [SerializeField] float preImpactDelay; //The time after the attack starts
    [SerializeField] float attackDuration; //The total time of the attack.

    [Header("Animations Used")]
    [SerializeField] string idleAnimationName;
    [SerializeField] string attackAnimationName;

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

        if((!warmedUp && intervalTime >= warmup) || (warmedUp && intervalTime >= attackRate))
        {
            warmedUp = true;

            npc.StartCoroutine(attackCooroutine(npc, target));            

            intervalTime = 0;
        }
        
        intervalTime += Time.deltaTime;
    }


    private IEnumerator attackCooroutine(NPCAI npc, Scannable target)
    {

        npc.npcAnimator.Animation = attackAnimationName;
        yield return new WaitForSeconds(preImpactDelay);

        DamageReciever[] damageRecievers = target.GetComponents<DamageReciever>();
        new List<DamageReciever>(damageRecievers).ForEach(r => r.ApplyDamage(strength, npc.transform.position));

        yield return new WaitForSeconds(attackDuration - preImpactDelay);
        npc.npcAnimator.Animation = idleAnimationName;

    }

    public override void Cease(NPCAI npc, Scannable target)
    {
        //
    }
}
