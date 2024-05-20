using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public GameObject objetoParaDesativar;
    public GameObject resetPanel;

    void Update()
    {
        // Verifica se o painel de reset está ativo
        if (resetPanel.activeSelf)
        {
            // Se o painel estiver ativo, desativa o objeto
            if (objetoParaDesativar.activeSelf)
            {
                objetoParaDesativar.SetActive(false);
            }
            // Trava o cursor quando o painel de reset está ativo
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Deixa o cursor solto quando o painel de reset não está ativo
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ResetScene()
    {
        // Recarrega a cena atual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
