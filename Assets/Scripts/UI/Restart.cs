using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public string nombreDeEscenaACargar = "Level";

    public void CambiarEscenaOnClick()
    {
        SceneManager.LoadScene(nombreDeEscenaACargar);
    }
}
