using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlayerAttack : MonoBehaviour
{
    public GameObject HeavyHitbox;
    private GameObject currentAttack;

    public float damage = 2;

    float currentAttackDestroyDelay;
    float currentAttackSpawnDelay;

    public float attackSpawnDelay = 0.5f;
    public float attackDestroyDelay = 0.3f;

    public bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentAttackSpawnDelay = attackSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !pressed)
        {
            pressed = true;
            LightPlayerAttack light = GetComponent<LightPlayerAttack>();
            light.pressed = false;
            MediumPlayerAttack medium = GetComponent<MediumPlayerAttack>();
            medium.pressed = false;
        }

        if (pressed == true)
        {
            currentAttackSpawnDelay -= Time.deltaTime;

            if (currentAttackSpawnDelay <= 0 && currentAttack == null)
            {
                Attack();
                currentAttackSpawnDelay = attackSpawnDelay;
            }
        }
        else
        {
            currentAttackSpawnDelay = attackSpawnDelay;
        }

        if (currentAttack != null)
        {
            currentAttackDestroyDelay -= Time.deltaTime;

            if (currentAttackDestroyDelay <= attackDestroyDelay/2)
            {
                HitboxScript hitbox = currentAttack.GetComponent<HitboxScript>();
                hitbox.attack = false;
            }

            if (currentAttackDestroyDelay <= 0)
            {
                DestroyAttack();
                pressed = false;
            }
        }

    }
    void DestroyAttack()
    {
        Destroy(currentAttack);
        currentAttack = null;
    }


    void Attack()
    {
        currentAttackDestroyDelay = attackDestroyDelay;

        playerMovement movement = GetComponent<playerMovement>();
        if (!movement.facingRight)
        {
            currentAttack = Instantiate(HeavyHitbox, new Vector2(transform.position.x + 1.45f * -1, transform.position.y + 0.5f), Quaternion.identity);

        }
        else
        {
            currentAttack = Instantiate(HeavyHitbox, new Vector2(transform.position.x + 1.45f, transform.position.y + 0.5f), Quaternion.identity);
        }
        currentAttack.transform.SetParent(transform);

        HitboxScript hitbox = currentAttack.AddComponent<HitboxScript>();
        hitbox.damage = damage;
    }
}
