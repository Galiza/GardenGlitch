using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [Header("Damage Configuration")]
    [SerializeField] float damage;

    public float GetDamage()
    {
        return damage;
    }
}
