using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoComVida : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;
    public Text textoVida;
    public GameObject[] objetosParaDestruir;
    public GameObject grupoParaDesativar;
    public GameObject objetoParaAtivar;

    private int objetosDestruidos = 0;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarTextoVida();
    }

    public void AplicarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            DestruirGrupoDeObjetos();
        }

        AtualizarTextoVida();
    }

    private void DestruirGrupoDeObjetos()
    {
        foreach (GameObject obj in objetosParaDestruir)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
                objetosDestruidos++;

                if (objetosDestruidos >= 3)
                {
                    grupoParaDesativar.SetActive(false);
                    objetoParaAtivar.SetActive(true);
                }
            }
        }
    }

    private void AtualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vidaAtual.ToString();
        }
        else
        {
            Debug.LogError("O componente de texto não está atribuído ao objeto.");
        }
    }
}