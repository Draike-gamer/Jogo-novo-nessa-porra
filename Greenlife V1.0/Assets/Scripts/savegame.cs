using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameStateSaver : MonoBehaviour
{
    public string saveFilePath = "savedGameState.txt";
    public GameObject playerObject;
    public GameObject resetPanel;
    public Button resetButton;
    public GameObject respawnObject; // Adicione uma refer�ncia ao objeto de respawn

    void Start()
    {
        resetButton.onClick.AddListener(OnResetButtonPressed);
        resetPanel.SetActive(false);
    }

    public void SaveGameState()
    {
        Debug.Log("Salvando estado da cena...");
        // N�o � mais necess�rio salvar a posi��o do jogador
        Debug.Log("Estado da cena salvo!");
        ResetScene();
    }

    public void ResetScene()
    {
        // Ativa o painel de reset
        resetPanel.SetActive(true);

        // Pausa a cena
        Time.timeScale = 0f;

        // Libera o cursor do mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnResetButtonPressed()
    {
        // Volta ao tempo normal
        Time.timeScale = 1f;
        // Coloca o jogador no objeto de respawn
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        if (respawnObject != null)
        {
            playerObject.transform.position = respawnObject.transform.position;
        }
        else
        {
            Debug.LogWarning("Objeto de respawn n�o especificado.");
            return; // Retorna caso o objeto de respawn n�o esteja especificado para evitar erros adicionais
        }
        // Recarrega a cena atual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}