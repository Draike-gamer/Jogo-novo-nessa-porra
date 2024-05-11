using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
    // Referência ao temporizador
    public GameObject timerObject;

    // Referência ao collider do tripwire
    private Collider tripwireCollider;

    // Flag para verificar se o tripwire já foi ativado
    private bool tripwireActivated = false;

    // Inicialização
    private void Start()
    {
        // Obtém o componente Collider do tripwire
        tripwireCollider = GetComponent<Collider>();
    }

    // Função chamada quando outro Collider entra em contato com o Collider do tripwire
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador e se o tripwire já não foi ativado
        if (other.CompareTag("Player") && !tripwireActivated)
        {
            // Ativa o temporizador
            timerObject.SetActive(true);

            // Desativa o collider do tripwire para evitar colisões adicionais
            tripwireCollider.enabled = false;

            // Define a flag do tripwire como ativada
            tripwireActivated = true;
        }
    }

    // Função chamada quando o temporizador chega a zero
    public void TimerZeroReached()
    {
        // Desativa o tripwire após o temporizador chegar a zero
        gameObject.SetActive(false);
    }
}