using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarAttack : MonoBehaviour
{
    public GameObject MediumHitBox;
    private GameObject currentAttack;

    public float damage = 1;

    float currentAttackDestroyDelay;
    float currentAttackSpawnDelay;

    float attackSpawnDelay = 0.3f;
    float attackDestroyDelay = 0.2f;

    bool pressed = false;
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
        }

        if (pressed == true)
        {
            currentAttackSpawnDelay -= Time.deltaTime;

            if (currentAttackSpawnDelay <= 0 && currentAttack == null)
            {
                Attack();
                currentAttackSpawnDelay = attackSpawnDelay;
                pressed = false;
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
        currentAttack = Instantiate(MediumHitBox, new Vector2(transform.position.x + 1.6f, transform.position.y + 0.5f), Quaternion.identity);
        MedScript medScript = currentAttack.AddComponent<MedScript>();
        medScript.damage = damage;
    }
}
