using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Vector3[] spawnPosition;

    bool spawnerActive = true;

    [SerializeField] float delay;

    private void Start()
    {
        delay = 10f;

        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        while (spawnerActive)
        {
            spawn();
            if (delay >= 3)
            {
                yield return new WaitForSeconds(delay);
                reduceDelay(0.5f);
            }
            else { yield return new WaitForSeconds(3f); }
        }
    } //Tiempo de spawneo

    void spawn()
    {
        int randomQuantity = Random.Range(1, 3);

        for (int i = 0; i < randomQuantity; i++)
        {
            int randomIndex = Random.Range(0, enemy.Length);
            int randomPosition = Random.Range(0, spawnPosition.Length);

            GameObject randomEnemy = enemy[randomIndex];

            Instantiate(randomEnemy, spawnPosition[randomPosition], randomEnemy.transform.rotation);
        }
    } //Spawneo aleatorio de enemigos

    public void reduceDelay(float reduction)
    {
        delay -= reduction;
    } //Disminuir tiempo de spawn

    public void addDelay(float add)
    {
        delay += add;
    } //Aumentar tiempo de spawn
}
