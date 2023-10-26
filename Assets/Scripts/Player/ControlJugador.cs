using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public Camera camaraPrimeraPersona;

    public GameObject proyectil;

    public float rapidezDesplazamiento = 10.0f;
    public float fuerzaSalto = 5f;
    private bool isGrounded;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Desaparece el cursor
    }
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None; //Aparece el cursor
        }

        if (Input.GetKeyDown("e"))
        {
            Cursor.lockState = CursorLockMode.Locked; //desaparece el cursor
        }



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            GameObject pro;
            pro = Instantiate(proyectil, ray.origin, transform.rotation);

            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(camaraPrimeraPersona.transform.forward * 50, ForceMode.Impulse);

            Destroy(pro, 10);
        }
    }
}
