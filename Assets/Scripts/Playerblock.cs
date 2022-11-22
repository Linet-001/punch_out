using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerblock : MonoBehaviour
{

    private HealthScript healthscript;


    void Awake()
    {
        healthscript = GetComponent<HealthScript>();
    }

    public void ActivateShield(bool shieldActive)  {
        healthscript.shieldActivated = shieldActive;

    }
}
