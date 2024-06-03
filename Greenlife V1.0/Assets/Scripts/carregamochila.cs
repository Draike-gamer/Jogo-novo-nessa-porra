using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carregamochila : MonoBehaviour {
    public GameObject mochila;
    public GameObject holder;

    public bool itemum = false;

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
            mochila.SetActive(false);
            holder.SetActive(true);
            itemum = true;
        }
    }
}
