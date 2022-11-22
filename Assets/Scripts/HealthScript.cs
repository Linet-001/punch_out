using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private float x_death = -90f;
    private float death_smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerdied;

    public bool isPlayer;

    [SerializeField]
    private Image health_UI;

    [HideInInspector]
    public bool shieldActivated;

    private CharacterSoundFX soundFX;

    void Awake()
    {
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Update () {
        if(playerdied) {
            RotateAfterDeath();
        }

    }

    public void ApplyDamage(float damage)
    {
        if (shieldActivated)
        {
            return;
        }

        health -= damage;

        if (health_UI != null) {
            health_UI.fillAmount = health / 100f;

        }

        //when you die
        if (health <= 0) {

            soundFX.Die();

            GetComponent<Animator>().enabled = false;

            StartCoroutine(AllowRotate());

            if(isPlayer)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;

                //player isnt parent gameobject for camera anymore
                Camera.main.transform.SetParent(null);

                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG)
                          .GetComponent<EnemyController>().enabled = false;  

            } else {

                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }

        }
    }

    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, x_death, Time.deltaTime * death_smooth),
            transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate()
    {
        playerdied = true;
        yield return new WaitForSeconds(rotate_Time);

        playerdied = false;
    }
} //class
