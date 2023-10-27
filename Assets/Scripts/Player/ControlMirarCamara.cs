using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMirarCamara : MonoBehaviour
{
    Vector2 mouseMirar; //�ngulo al que mira la c�mara para los ejes X e Y
    Vector2 suavidadV; //Suaviza el movimiento

    public float sensibilidad = 3.0f; //Sensibilidad
    public float suavizado = 2.0f; //Coeficiente de suavizado para la interpolaci�n lineal

    bool active;

    GameObject jugador;
    void Start()
    {
        active = true;
        jugador = this.transform.parent.gameObject; //Emparentar al jugador con la c�mara
    }
    void Update()
    {   //Cambio de movimiento desde el ultimo Update()
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado); //Interpolaci��n lineal:
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado); //Se obtienen valores intermedios entre dos valores

        mouseMirar += suavidadV;
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f); //Clamp hace que un valor est� dentro de un intervalo
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right); //Rota la c�mara arriba/abajo
        jugador.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, jugador.transform.up); //Rota al jugador (Y c�mara) izq/der

    }
}