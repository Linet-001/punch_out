using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND_PARAMETER, defend);
    }

    public void Attack_1()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIG_1);
    }

    public void Attack_2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_2_TRIG);
    }
   // void Freeze()
   // {
   //     anim.speed = 0f;
   // }
   // public void Unfreeze()
   // {
    //    anim.speed = 1f;
   // }

}