using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttacks : MonoBehaviour
{
    public GameObject LightHitbox;
    public GameObject MediumHitBox;
    public GameObject HeavyHitbox;

    private GameObject currentAttack;

    public float lightDamage = 0.5f;
    public float mediumDamage = 1f;
    public float heavyDamage = 2f;

    float currentLightSpawnDelay;
    float currentMediumSpawnDelay;
    float currentHeavySpawnDelay;

    float currentAttackDestroyDelay;
    float attackDestroyDelay;

    playerMovement movement;

    float lightSpawnDelay = 0.2f;
    float lightDestroyDelay = 0.1f;

    float mediumSpawnDelay = 0.3f;
    float mediumDestroyDelay = 0.2f;

    float heavySpawnDelay = 0.5f;
    float heavyDestroyDelay = 0.3f;

    bool lightAttacking;
    bool mediumAttacking;
    bool heavyAttacking;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<playerMovement>();

        currentLightSpawnDelay = lightSpawnDelay;
        currentMediumSpawnDelay = mediumSpawnDelay;
        currentHeavySpawnDelay = heavySpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !movement.pressed)
        {
            movement.pressed = true;
            lightAttacking = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && !movement.pressed)
        {
            movement.pressed = true;
            mediumAttacking = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && !movement.pressed)
        {
            movement.pressed = true;
            heavyAttacking = true;
        }

        if (movement.pressed)
        {
            if (lightAttacking)
            {
                currentLightSpawnDelay -= Time.deltaTime;

                if (currentLightSpawnDelay <= 0 && currentAttack == null)
                {
                    LightAttack();
                    currentLightSpawnDelay = lightSpawnDelay;
                    lightAttacking = false;
                }
            }
            if (mediumAttacking)
            {
                currentMediumSpawnDelay -= Time.deltaTime;

                if (currentMediumSpawnDelay <= 0 && currentAttack == null)
                {
                    MediumAttack();
                    currentMediumSpawnDelay = mediumSpawnDelay;
                    mediumAttacking = false;
                }
            }
            if (heavyAttacking)
            {
                currentHeavySpawnDelay -= Time.deltaTime;

                if (currentHeavySpawnDelay <= 0 && currentAttack == null)
                {
                    HeavyAttack();
                    currentHeavySpawnDelay = heavySpawnDelay;
                    heavyAttacking = false;
                }
            }
        }
        else
        {
            currentLightSpawnDelay = lightSpawnDelay;
            currentMediumSpawnDelay = mediumSpawnDelay;
            currentHeavySpawnDelay = heavySpawnDelay;
        }

        if (currentAttack != null)
        {
            currentAttackDestroyDelay -= Time.deltaTime;

            if (currentAttackDestroyDelay <= attackDestroyDelay / 2)
            {
                HitboxScript hitbox = currentAttack.GetComponent<HitboxScript>();
                hitbox.attack = false;
            }

            if (currentAttackDestroyDelay <= 0)
            {
                DestroyAttack();
                movement.pressed = false;
            }
        }
    }

    void LightAttack()
    {
        currentAttackDestroyDelay = lightDestroyDelay;
        attackDestroyDelay = lightDestroyDelay;

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
        hitbox.damage = lightDamage;
    }
    void MediumAttack()
    {
        currentAttackDestroyDelay = mediumDestroyDelay;
        attackDestroyDelay = mediumDestroyDelay;

        if (!movement.facingRight)
        {
            currentAttack = Instantiate(MediumHitBox, new Vector2(transform.position.x + 1.65f * -1, transform.position.y + 0.5f), Quaternion.identity);

        }
        else
        {
            currentAttack = Instantiate(MediumHitBox, new Vector2(transform.position.x + 1.65f, transform.position.y + 0.5f), Quaternion.identity);
        }
        currentAttack.transform.SetParent(transform);

        HitboxScript hitbox = currentAttack.AddComponent<HitboxScript>();
        hitbox.damage = mediumDamage;
    }
    void HeavyAttack()
    {
        currentAttackDestroyDelay = heavyDestroyDelay;
        attackDestroyDelay = heavyDestroyDelay;

        if (!movement.facingRight)
        {
            currentAttack = Instantiate(HeavyHitbox, new Vector2(transform.position.x + 1.85f * -1, transform.position.y + 0.5f), Quaternion.identity);

        }
        else
        {
            currentAttack = Instantiate(HeavyHitbox, new Vector2(transform.position.x + 1.85f, transform.position.y + 0.5f), Quaternion.identity);
        }
        currentAttack.transform.SetParent(transform);

        HitboxScript hitbox = currentAttack.AddComponent<HitboxScript>();
        hitbox.damage = heavyDamage;
    }

    void DestroyAttack()
    {
        Destroy(currentAttack);
        currentAttack = null;
    }

}
