using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sementes : MonoBehaviour
{
    public GameObject mudaDeArvore;
    public float tempoParaCrescer = 5f; // Tempo necessário para as sementes se transformarem em uma muda
    private float tempoAguado = 0f;

    void Start()
    {
        if (mudaDeArvore != null)
        {
            mudaDeArvore.SetActive(false);
        }
    }

    void Update()
    {
        if (tempoAguado >= tempoParaCrescer)
        {
            Crescer();
        }
    }

    public void Aguar(float tempo)
    {
        tempoAguado += tempo;
    }

    private void Crescer()
    {
        this.gameObject.SetActive(false); // Desativa as sementes
        if (mudaDeArvore != null)
        {
            mudaDeArvore.SetActive(true); // Ativa a muda de árvore
        }
    }
}