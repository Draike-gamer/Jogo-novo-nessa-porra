using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // M�todo para mudar para uma cena espec�fica
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("Mapa");
    }
}