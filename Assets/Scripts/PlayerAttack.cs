using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    public GameObject attackPoint;

    private Playerblock shield;

    private CharacterSoundFX soundFX;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<Playerblock>();

        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        //defend when pressed G
        if (Input.GetKeyDown(KeyCode.G))   {

            playerAnimation.Defend(true);

            shield.ActivateShield(true);
        }


        if (Input.GetKeyUp(KeyCode.G))
        {
           // playerAnimation.UnFreezeAnimation();

            playerAnimation.Defend(false);

            shield.ActivateShield(false);

        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
                soundFX.Attack_1();
            } else {
                playerAnimation.Attack_2();
                soundFX.Attack_2();
            }
        }

    }

    void Activate_AttackPoint() {
        attackPoint.SetActive(true);
    }


    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
