using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public AudioClip hoverSound; // Som a ser reproduzido quando o mouse passar por cima dos botões
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
        // Implemente o código para abrir o menu de opções
        Debug.Log("Abrindo opções...");
    }

    public void ExitGame()
    {
        // Fecha o jogo
        Application.Quit();
    }

    // Método chamado quando o mouse passa por cima de um botão
    public void OnMouseEnterButton()
    {
        audioSource.Play(); // Reproduz o som
    }
}