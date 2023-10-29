using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int hp;
    private GameObject jugador;
    public float rapidez = 3f;
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
        {
            transform.LookAt(jugador.transform);
            transform.Translate(rapidez * Vector3.forward * Time.deltaTime);

            if (transform.position.y <= 0.25f)
            {
                rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
            }
        } //Seguimiento de jugador y salto

        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            recibirDaño(25);
        }
        if (collision.gameObject.CompareTag("Cactus"))
        {
            recibirDaño(10);
        }
    } //Daños

    public void recibirDaño(int daño)
    {
        hp = hp - daño;

        if (hp <= 0)
        {
            this.desaparecer();
        }
    } //Daño recibido
    private void desaparecer()
    {
        GameObject par;
        par = Instantiate(particle, Enemy.transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(par,2.5f);
    } //Muerte del enemigo
}