using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerAttack : MonoBehaviour
{
    public GameObject LightHitbox;
    private GameObject currentAttack;

    public float damage = 0.5f;

    float currentAttackDestroyDelay;
    float currentAttackSpawnDelay;

    float attackSpawnDelay = 0.2f;
    float attackDestroyDelay = 0.1f;

    public bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentAttackSpawnDelay = attackSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !pressed)
        {
            pressed = true;
            HeavyPlayerAttack heavy = GetComponent<HeavyPlayerAttack>();
            heavy.pressed = false;
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
            currentAttack = Instantiate(LightHitbox, new Vector2(transform.position.x + 1.45f * -1, transform.position.y + 0.5f), Quaternion.identity);

        }
        else
        {
            currentAttack = Instantiate(LightHitbox, new Vector2(transform.position.x + 1.45f, transform.position.y + 0.5f), Quaternion.identity);
        }

        currentAttack.transform.SetParent(transform);

        HitboxScript hitbox = currentAttack.AddComponent<HitboxScript>();
        hitbox.damage = damage;
    }
}
