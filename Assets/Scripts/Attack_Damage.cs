using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Attack_Damage : MonoBehaviour
{

    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);        

        if (hits.Length > 0) {

            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);
        }
    }
}
