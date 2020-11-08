using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooter Configuration")]
    [SerializeField] GameObject projectilePrefab, gun;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Cached Reference
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawnerArray)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
