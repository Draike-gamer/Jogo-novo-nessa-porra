using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semente : MonoBehaviour
{
    public GameObject sacosemente;
    public GameObject holder;

    public bool itemdois = false;

    private bool playerInRange = false;

    // Função chamada quando o jogador entra na área de trigger
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
        }
    }

    // Função chamada quando o jogador sai da área de trigger
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
        }
    }

    public void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) {
            sacosemente.SetActive(false);
            holder.SetActive(true);
            itemdois = true;
        }
    }
}
