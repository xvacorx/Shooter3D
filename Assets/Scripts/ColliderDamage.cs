using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDamage : MonoBehaviour
{
    public float damage = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
