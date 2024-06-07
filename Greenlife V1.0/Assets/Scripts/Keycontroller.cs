using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject keyUI; // Referência ao objeto UI que representa a chave no inventário

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        // Desativa a chave na cena
        gameObject.SetActive(false);

        // Ativa a chave no inventário (UI)
        if (keyUI != null)
        {
            keyUI.SetActive(true);
        }

        // Notifica o DoorController que a chave foi coletada
        DoorController.KeyCollected(gameObject);
    }
}