using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Método para mudar para uma cena específica
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("Mapa");
    }
}