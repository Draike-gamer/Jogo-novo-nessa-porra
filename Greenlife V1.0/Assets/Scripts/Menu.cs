using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public AudioClip hoverSound; // Som a ser reproduzido quando o mouse passar por cima dos bot�es
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hoverSound;
    }

    public void PlayGame()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Mapa");
    }

    public void OpenOptions()
    {
        // Implemente o c�digo para abrir o menu de op��es
        Debug.Log("Abrindo op��es...");
    }

    public void ExitGame()
    {
        // Fecha o jogo
        Application.Quit();
    }

    // M�todo chamado quando o mouse passa por cima de um bot�o
    public void OnMouseEnterButton()
    {
        audioSource.Play(); // Reproduz o som
    }
}