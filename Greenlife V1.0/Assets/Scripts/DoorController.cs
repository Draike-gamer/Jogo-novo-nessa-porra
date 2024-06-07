using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject key;
    public float raycastDistance = 2.0f;
    public KeyCode interactionKey = KeyCode.E;
    public Text interactionText; // Texto de intera��o na UI
    public Animator doorAnimator; // Refer�ncia ao Animator da porta

    private void Start()
    {
        if (interactionText != null)
        {
            interactionText.text = "";
            interactionText.enabled = false;
        }
    }

    private void Update()
    {
        RaycastHit hit;
        // Cria o Raycast a partir da posi��o do jogador
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            // Verifica se o Raycast atingiu a porta
            if (hit.collider.gameObject == door)
            {
                // Exibir o texto de intera��o se a chave estiver desativada
                if (!key.activeInHierarchy)
                {
                    if (interactionText != null)
                    {
                        interactionText.text = "Open";
                        interactionText.enabled = true;
                    }

                    // Detecta a tecla "E" pressionada
                    if (Input.GetKeyDown(interactionKey))
                    {
                        OpenDoor();
                    }
                }
            }
            else
            {
                if (interactionText != null)
                {
                    interactionText.enabled = false;
                }
            }
        }
        else
        {
            if (interactionText != null)
            {
                interactionText.enabled = false;
            }
        }
    }

    private void OpenDoor()
    {
        // Define o par�metro "abrir" no Animator para iniciar a anima��o
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("abrir", true);
        }

        Debug.Log("Porta aberta!");

        // Incrementar o contador de portas abertas
        GlobalManager.Instance.IncrementarPortasAbertas();

        // Desativar o texto de intera��o
        if (interactionText != null)
        {
            interactionText.enabled = false;
        }
    }
}