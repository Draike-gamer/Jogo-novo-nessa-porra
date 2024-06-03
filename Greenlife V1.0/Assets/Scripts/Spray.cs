using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    public GameObject spray;
    public GameObject holder;

    public bool itemtres = false;

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
            spray.SetActive(false);
            holder.SetActive(true);
            itemtres = true;
        }
    }
}