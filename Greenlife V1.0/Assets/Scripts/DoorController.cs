using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClosed = true;
    public GameObject door;
    public GameObject key;
    public float raycastDistance = 2.0f;
    public KeyCode interactionKey = KeyCode.E;
    public Text interactionText; // Texto de intera��o na UI

    // Mapeamento de portas e chaves
    private static Dictionary<GameObject, GameObject> doorKeyMap = new Dictionary<GameObject, GameObject>();

    private void Awake()
    {
        // Adiciona a porta e a chave ao mapeamento
        if (door != null && key != null)
        {
            doorKeyMap[door] = key;
        }

        // Inicializa o texto de intera��o
        if (interactionText != null)
        {
            interactionText.text = "";
            interactionText.enabled = false;
        }
    }

    private void Update()
    {
        // Detecta a tecla "E" pressionada
        if (Input.GetKeyDown(interactionKey))
        {
            RaycastHit hit;
            // Cria o Raycast a partir da posi��o do jogador
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                // Verifica se o Raycast atingiu uma chave
                if (doorKeyMap.ContainsValue(hit.collider.gameObject))
                {
                    // Verifica se a chave atingida corresponde a esta porta
                    if (doorKeyMap[door] == hit.collider.gameObject)
                    {
                        OpenDoor();
                    }
                }
            }
        }

        // Atualiza o texto de intera��o
        UpdateInteractionText();
    }

    private void OpenDoor()
    {
        if (isClosed)
        {
            isOpen = true;
            isClosed = false;
            // Aqui voc� pode adicionar a anima��o ou l�gica para abrir a porta
            door.SetActive(false); // Exemplo de desativar a porta para simular a abertura
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

    private void UpdateInteractionText()
    {
        RaycastHit hit;
        // Cria o Raycast a partir da posi��o do jogador
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            // Verifica se o Raycast atingiu uma porta
            if (hit.collider.gameObject == door)
            {
                // Verifica se a chave correspondente foi destru�da
                if (doorKeyMap.ContainsKey(door) && doorKeyMap[door] == null)
                {
                    // Exibir o texto de intera��o
                    if (interactionText != null)
                    {
                        interactionText.text = "Open";
                        interactionText.enabled = true;
                    }
                }
            }
        }
        else
        {
            // Ocultar o texto de intera��o se n�o estiver olhando para a porta
            if (interactionText != null)
            {
                interactionText.enabled = false;
            }
        }
    }
}