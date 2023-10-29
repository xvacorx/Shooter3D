using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    float rotationSpeed = 50.0f;

    void Update()
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }

    [SerializeField] TimeAndScore score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score.coinScore += 10;
            Destroy(gameObject);
        }
    }
}
