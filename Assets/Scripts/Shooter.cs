using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, weapon;
    AttackerSpawner myLaneEnemySpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLane();
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
            //Debug.Log("Shoot"); // To do - change animation state to shoot.
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //Debug.Log("idle"); // To do - change animation state to idle.
            animator.SetBool("isAttacking", false);
        }
    }
    private void SetLane()
    {
        AttackerSpawner[] enemySpawners = FindObjectsOfType<AttackerSpawner>();
        //Debug.Log("AttackSpawners in Scene : " + enemySpawners.Length);

        foreach (AttackerSpawner spawn in enemySpawners)
        {
            bool IsCloseEnough =
                (Mathf.Abs(spawn.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneEnemySpawner = spawn;
            }
           /* else
            {
                Debug.Log("isCloseEnough wasn't true");
            }*/
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneEnemySpawner.transform.childCount <= 0) //for the child count
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void Fire()
    {
        GameObject newProjectile =
            Instantiate(projectile, weapon.transform.position, transform.rotation)
            as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
