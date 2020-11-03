using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab, gun;

    public void Fire()
    {
        Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
    }
}
