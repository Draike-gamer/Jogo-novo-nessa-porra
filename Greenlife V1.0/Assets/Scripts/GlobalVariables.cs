using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }
    public int ObjetosDestruidos = 0;
    public int mudasAtivadas = 0; // Contador de mudas ativadas
    public int larvasDestruidas = 0; // Contador de larvas destruídas
    public GameObject larvas; // Objeto das larvas que será ativado ao atingir 12 mudas
    public GameObject painelLarvas; // Painel a ser ativado quando 12 larvas forem destruídas
    public GameObject tempo;
    public GameObject resetPanel;
    public GameObject objetoParaDesativar;
    public GameObject painelPortasAbertas; // Painel a ser ativado quando todas as portas forem abertas
    private ResetGame resetGame;
    private int portasAbertas = 0; // Contador de portas abertas

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional, se você quiser que este objeto persista entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        resetGame = FindObjectOfType<ResetGame>();
        if (larvas != null)
        {
            larvas.SetActive(false); // Certifique-se de que as larvas estão desativadas no início
        }
        if (painelLarvas != null)
        {
            painelLarvas.SetActive(false); // Certifique-se de que o painel está desativado no início
        }
        if (painelPortasAbertas != null)
        {
            painelPortasAbertas.SetActive(false); // Certifique-se de que o painel está desativado no início
        }
    }

    public void IncrementarPortasAbertas()
    {
        portasAbertas++;
        if (portasAbertas >= 3)
        {
            AtivarPainelPortasAbertas();
        }
    }

    private void AtivarPainelPortasAbertas()
    {
        if (painelPortasAbertas != null)
        {
            painelPortasAbertas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AtivarObjetos(GameObject[] objetosParaAtivar)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        tempo.SetActive(false);
        foreach (GameObject obj in objetosParaAtivar)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    public void AtivarPainelDeReset()
    {
        resetPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnResetButtonPressed()
    {
        // Desativa o painel de reset e reseta a cena através do ResetGame
        resetPanel.SetActive(false);
        Time.timeScale = 1f; // Retoma o tempo normal
        resetGame.ResetScene();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IncrementarMudasAtivadas()
    {
        mudasAtivadas++;
        if (mudasAtivadas >= 12)
        {
            AtivarLarvas();
        }
    }

    private void AtivarLarvas()
    {
        if (larvas != null)
        {
            larvas.SetActive(true);
        }
    }

    public void IncrementarLarvasDestruidas()
    {
        larvasDestruidas++;
        if (larvasDestruidas >= 12)
        {
            AtivarPainelLarvas();
        }
    }

    private void AtivarPainelLarvas()
    {
        if (painelLarvas != null)
        {
            painelLarvas.SetActive(true);
        }
    }
}