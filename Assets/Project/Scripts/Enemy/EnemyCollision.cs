using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool collisionDetected;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with: " + collision.gameObject.name);
        collisionDetected = collision.gameObject.GetComponent<IDamageable>() != null;
    }
    // public bool OnCollisionEnter(Collision2D collision2D)
    // {
    //     if (collision2D.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Enemy collided with Player");
    //         collisionDetected = collision2D.gameObject.name;
    //     }
    //     else
    //     {
    //         Debug.Log("Enemy collided with: " + collision2D.gameObject.name);
    //         collisionDetected = false;
    //     }
    //     return collisionDetected;
    // }
}
