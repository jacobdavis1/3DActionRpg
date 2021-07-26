using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

/*
public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    HealthComponent healthComponent;
    PlayerParticles playerParticles;
    StatesComponent states;

    Vector2 input;
    float attackAnimationTimer, attackIndex, attackTypeCount = 2;

    enum EquipmentType { Unarmed, SwordShield }; 
    EquipmentType currentEquipment = EquipmentType.SwordShield;

    GameObject leftWeapon, rightWeapon;

    // Start is called before the first frame update
    void Start()
    {
        states = GetComponent<StatesComponent>();

        if (GetComponent<NetworkObject>().IsLocalPlayer)
        {
            Camera.main.GetComponent<MouseLookCamera>().target = transform.root.gameObject;
        }

        animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();
        playerParticles = GetComponent<PlayerParticles>();

        leftWeapon = GameObject.FindGameObjectWithTag("LeftWeapon");
        rightWeapon = GameObject.FindGameObjectWithTag("RightWeapon");

        SheatheWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<NetworkObject>().IsLocalPlayer)
        {
            transform.position = states.Position;
            transform.rotation = states.Rotation;
            return;
        }

        if (!healthComponent.Alive)
            return;

        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("velx", input.x);
        animator.SetFloat("vely", input.y);

        states.Move = (input.x != 0 || input.y != 0);

        animator.SetBool("move", states.Move);
        animator.SetBool("run", states.Run);
        animator.SetBool("block", states.Block);
        animator.SetBool("attacking", states.Attacking);
        animator.SetBool("combat", states.Combat);

        ManageState();
        Attack();

        states.UpdateTransformServerRpc(transform.position, transform.rotation);
    }

    private void FixedUpdate()
    {
        if (!GetComponent<NetworkObject>().IsLocalPlayer)
            return;

        if (!healthComponent.Alive) 
            return;

        // Face forward when moving or blocking
        if (states.Move || states.Block)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        GetComponent<Rigidbody>().MovePosition(transform.position);
    }

    private void ManageState()
    {
        // Draw or sheathe weapon
        if (Input.GetKeyDown(KeyCode.R))
        {
            SheatheUnsheatheWeapon();
        }

        // Sprint
        states.UpdateRunServerRpc(Input.GetKey(KeyCode.LeftShift));

        states.UpdateBlockServerRpc(Input.GetKey(KeyCode.Mouse1) && states.Combat);
    }

    private void Attack()
    {
        if (states.Attacking)
        {
            if (attackAnimationTimer <= 0)
            {
                states.UpdateAttackingServerRpc(false);
            }

            else
            {
                attackAnimationTimer -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (states.Combat && !states.Attacking)
            {
                if (states.Block)
                {
                    animator.CrossFadeInFixedTime("ShieldBash", 0.1f);
                    states.UpdateAttackingServerRpc(true);
                    attackAnimationTimer = animator.GetCurrentAnimatorStateInfo(0).length * 0.8f;
                }
                else
                {
                    // Cycles through 2 different attack animations
                    attackIndex = animator.GetFloat("attackIndex") + 1;
                    if (attackIndex > attackTypeCount)
                        attackIndex = 1;

                    switch (attackIndex)
                    {
                        case 1:
                            rightWeapon.GetComponentInChildren<MeshCollider>().enabled = true;
                            break;

                        case 2:
                            leftWeapon.GetComponentInChildren<MeshCollider>().enabled = true;
                            break;
                    }

                    animator.SetFloat("attackIndex", attackIndex);
                    animator.CrossFadeInFixedTime("Attack", 0.1f);
                    states.UpdateAttackingServerRpc(true);
                    attackAnimationTimer = animator.GetCurrentAnimatorStateInfo(0).length * 0.8f;
                }
            }
        }
    }

    private void SheatheUnsheatheWeapon()
    {
        if (currentEquipment == EquipmentType.Unarmed)
            return;

        if (states.Combat)
        {
            //sheathe
            animator.CrossFadeInFixedTime("Unequip", 0.1f);
        }
        else
        {
            // Unsheathing is done via animation event
            animator.CrossFadeInFixedTime("Equip", 0.1f);
        }
    }

    public void PlayEquipParticles()
    {
        leftWeapon.GetComponent<ParticleSystem>().Play();
        rightWeapon.GetComponent<ParticleSystem>().Play();
    }

    public void UnsheatheWeapons()
    {
        states.UpdateCombatServerRpc(true);

        leftWeapon.SetActive(true);
        rightWeapon.SetActive(true);

        PlayEquipParticles();
    }

    public void SheatheWeapons()
    {
        leftWeapon.SetActive(false);
        rightWeapon.SetActive(false);

        playerParticles.PlayUnequipParticles();

        states.UpdateCombatServerRpc(false);
    }

    public void AttackStart()
    {
        states.UpdateAttackingServerRpc(true);
    }

    public void AttackStop()
    {
        states.UpdateAttackingServerRpc(false);

        leftWeapon.GetComponentInChildren<MeshCollider>().enabled = false;
        rightWeapon.GetComponentInChildren<MeshCollider>().enabled = false;
    }
}*/
