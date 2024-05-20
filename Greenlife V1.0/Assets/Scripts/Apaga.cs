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
    public GameObject[] objetosParaAtivar;
    private bool ativarObjetoJogador = false;

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
            GlobalManager.Instance.ObjetosDestruidos += DestruirGrupoDeObjetos();
        }

        AtualizarTextoVida();

        if (GlobalManager.Instance.ObjetosDestruidos >= 3 && !ativarObjetoJogador)
        {
            ativarObjetoJogador = true;
            GlobalManager.Instance.AtivarObjetos(objetosParaAtivar);
        }
    }

    private int DestruirGrupoDeObjetos()
    {
        int objetosDestruidosLocal = 0;

        foreach (GameObject obj in objetosParaDestruir)
        {
            if (obj != null)
            {
                Destroy(obj);
                objetosDestruidosLocal++;
            }
        }

        return objetosDestruidosLocal;
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