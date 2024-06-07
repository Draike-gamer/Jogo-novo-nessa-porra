using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClosed = true;
    public GameObject door;
    public GameObject key;
    public float raycastDistance = 2.0f;
    public KeyCode interactionKey = KeyCode.E;

    private void Update()
    {
        // Detecta a tecla "E" pressionada
        if (Input.GetKeyDown(interactionKey))
        {
            RaycastHit hit;
            // Cria o Raycast a partir da posição do jogador
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                // Verifica se o Raycast atingiu a chave correta
                if (hit.collider.gameObject == key)
                {
                    OpenDoor();
                }
            }
        }
    }

    private void OpenDoor()
    {
        if (isClosed)
        {
            isOpen = true;
            isClosed = false;
            // Aqui você pode adicionar a animação ou lógica para abrir a porta
            door.SetActive(false); // Exemplo de desativar a porta para simular a abertura
            Debug.Log("Porta aberta!");

            // Incrementar o contador de portas abertas
            GlobalManager.Instance.IncrementarPortasAbertas();
        }
    }
}