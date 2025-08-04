using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool isTransitionAllowed;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player");
            isTransitionAllowed = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("collision Stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("collision Exit");
        isTransitionAllowed = false;
    }
}
