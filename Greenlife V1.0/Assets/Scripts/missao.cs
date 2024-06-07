using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripwireTrigger : MonoBehaviour
{
    // Referência ao painel que será ativado
    public GameObject triggerPanel;

    // Método chamado quando outro objeto colide com este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Ativa o painel
            triggerPanel.SetActive(true);

            // Destrói o próprio tripwire
            Destroy(gameObject);
        }
    }
}