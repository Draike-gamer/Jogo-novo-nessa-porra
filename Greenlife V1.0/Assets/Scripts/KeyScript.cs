using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public AudioClip collectSound; // Som de coleta da chave, opcional

    private bool isCollected = false; // Flag para verificar se a chave foi coletada

    // Método chamado quando o jogador coleta a chave
    public void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            DoorController doorController = GetComponentInParent<DoorController>();
            if (doorController != null)
            {
                doorController.CollectKey();
            }
            else
            {
                Debug.LogError("KeyScript: DoorController not found in parent hierarchy.");
            }

            isCollected = true; // Marca a chave como coletada
            gameObject.SetActive(false); // Desativa a chave no cenário

            // Executa algum efeito sonoro ou visual, se necessário
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Debug.Log("Key collected: " + gameObject.name);
        }
    }
}