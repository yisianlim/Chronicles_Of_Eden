using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the animation the NPC is showing.
/// </summary>
public class NPCAnimator : MonoBehaviour {

    const string DIE_KEYWORD = "Die";

    [SerializeField] Animator anim;
    [SerializeField] string[] animationNames;
    [SerializeField] float deathDuration;

    float dyingFor;

    private bool dying = false;

    /// <summary>
    /// Change the current animation of the NPC.
    /// </summary>
    public string Animation
    {
        set
        {

            //Do not change the animation if none is specified.
            if (value.Equals("")) return;

            //Check that the NPC isn't being killed or dying.
            if (value.Equals(DIE_KEYWORD))
            {
                Dies();
                return;
            }
            else if (dying) return;

            anim.SetInteger("Condition", FindAnimationConditionValue(value));

        }
    }

    public void Awake()
    {
        //Ensure the 'Die' is one of the animations listed, as it is treated specially.
        if (!new List<string>(animationNames).Contains(DIE_KEYWORD))
            throw new System.Exception("At least one of the animation names listed should be: " + DIE_KEYWORD);
    }

    /// <summary>
    /// Find the animation condition number associated with the name in the names list, if there is one.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private int FindAnimationConditionValue(string name)
    {

        for (int i = 0; i < animationNames.Length; i++)
            if (animationNames[i].Equals(name)) return i;

        throw new System.Exception("The animation is trying to be set to a value not listed in the animation names.");

    }

    /// <summary>
    /// Have the NPC play the dying animation, and block any other animations from playing during this.
    /// </summary>
    public void Dies()
    {

        //if(dying) return;
        Debug.Log("Dying");

        dying = true;
        anim.SetInteger("Condition", FindAnimationConditionValue(DIE_KEYWORD));

        dyingFor += Time.deltaTime;
        if (dyingFor > deathDuration) FinishDying();

    }

    /// <summary>
    /// An animation event called when the dying animation has completed.
    /// </summary>
    public void FinishDying()
    {
        gameObject.SetActive(false);
    }
}
