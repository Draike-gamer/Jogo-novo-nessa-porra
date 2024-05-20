using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameStateSaver : MonoBehaviour
{
    public string saveFilePath = "savedGameState.txt";
    public GameObject playerObject;
    public GameObject respawnObject;

    void Start()
    {
        // Certifica-se de que o cursor est� desbloqueado inicialmente
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SaveGameState()
    {
        Debug.Log("Salvando estado da cena...");
        // N�o � mais necess�rio salvar a posi��o do jogador
        Debug.Log("Estado da cena salvo!");
        // Aqui voc� pode incluir qualquer outra l�gica necess�ria para salvar o estado do jogo
    }

    public void RespawnPlayer()
    {
        if (respawnObject != null)
        {
            playerObject.transform.position = respawnObject.transform.position;
        }
        else
        {
            Debug.LogWarning("Objeto de respawn n�o especificado.");
            return;
        }

        // Recarrega a cena atual
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}