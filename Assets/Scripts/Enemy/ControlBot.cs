using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int hp;
    private GameObject jugador;
    public float rapidez = 2.5f;
    [SerializeField] private Rigidbody rb;

    public GameObject particle;

    public GameObject Enemy;


    void Start()
    {
        hp = 100;
        jugador = GameObject.Find("Jugador");
    }

    private void Update()
    {
        transform.LookAt(jugador.transform);
        transform.Translate(rapidez * Vector3.forward * Time.deltaTime);

        if (transform.position.y <= 0.25f)
        {
            rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            recibirDaño();
        }
    }

    public void recibirDaño()
    {
        hp = hp - 25;

        if (hp <= 0)
        {
            this.desaparecer();
        }
    }
    private void desaparecer()
    {
        GameObject par;
        par = Instantiate(particle, Enemy.transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(par,2.5f);
    }
}