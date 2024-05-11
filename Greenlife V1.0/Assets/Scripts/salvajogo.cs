using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
    // Refer�ncia ao temporizador
    public GameObject timerObject;

    // Refer�ncia ao collider do tripwire
    private Collider tripwireCollider;

    // Flag para verificar se o tripwire j� foi ativado
    private bool tripwireActivated = false;

    // Inicializa��o
    private void Start()
    {
        // Obt�m o componente Collider do tripwire
        tripwireCollider = GetComponent<Collider>();
    }

    // Fun��o chamada quando outro Collider entra em contato com o Collider do tripwire
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu � o jogador e se o tripwire j� n�o foi ativado
        if (other.CompareTag("Player") && !tripwireActivated)
        {
            // Ativa o temporizador
            timerObject.SetActive(true);

            // Desativa o collider do tripwire para evitar colis�es adicionais
            tripwireCollider.enabled = false;

            // Define a flag do tripwire como ativada
            tripwireActivated = true;
        }
    }

    // Fun��o chamada quando o temporizador chega a zero
    public void TimerZeroReached()
    {
        // Desativa o tripwire ap�s o temporizador chegar a zero
        gameObject.SetActive(false);
    }
}