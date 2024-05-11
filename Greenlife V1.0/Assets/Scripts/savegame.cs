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
    public GameObject respawnObject; // Adicione uma referência ao objeto de respawn

    void Start()
    {
        // Adiciona um listener para detectar quando o jogador clica na tela
        Cursor.visible = true; // Certifica-se de que o cursor é visível inicialmente
        Cursor.lockState = CursorLockMode.None; // Garante que o cursor está desbloqueado inicialmente
        Input.simulateMouseWithTouches = false; // Evita que o cursor seja travado em dispositivos de toque
        Cursor.visible = false; // Oculta o cursor novamente
        Cursor.lockState = CursorLockMode.Locked; // Bloqueia o cursor novamente
        resetButton.onClick.AddListener(OnResetButtonPressed);
        resetPanel.SetActive(false);
    }

    public void SaveGameState()
    {
        Debug.Log("Salvando estado da cena...");
        // Não é mais necessário salvar a posição do jogador
        Debug.Log("Estado da cena salvo!");
        ResetScene();
    }

    public void ResetScene()
    {
        // Ativa o painel de reset
        resetPanel.SetActive(true);

        // Pausa a cena
        Time.timeScale = 0f;

        // Desbloqueia o cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnResetButtonPressed()
    {
        // Coloca o jogador no objeto de respawn
        RespawnPlayer();

        // Desativa o painel de reset
        resetPanel.SetActive(false);

        // Volta ao tempo normal
        Time.timeScale = 1f;

        // Esconde o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void RespawnPlayer()
    {
        if (respawnObject != null)
        {
            playerObject.transform.position = respawnObject.transform.position;
        }
        else
        {
            Debug.LogWarning("Objeto de respawn não especificado.");
            return; // Retorna caso o objeto de respawn não esteja especificado para evitar erros adicionais
        }
        // Recarrega a cena atual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}