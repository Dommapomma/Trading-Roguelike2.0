using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Define a delegate type for the attack functions
    protected delegate void AttackFunction();
    // Create an array of attack functions
    protected AttackFunction[] attackFunctions;


    // Declare your attack functions
    private void Attack1()
    {
        Debug.Log("Attack #1");
    }
    private void Attack2()
    {
        Debug.Log("Attack #2");
    }
    private void Start()
    {
        InitializeAttacks();
    }
    protected virtual void InitializeAttacks()
    {
        attackFunctions = new AttackFunction[] { Attack1, Attack2 };
    }

    public void RandomAttack()
    {
        // Choose a random index from the array
        int randomIndex = Random.Range(0, attackFunctions.Length);
        // Invoke the selected attack function
        attackFunctions[randomIndex]();
    }
}
