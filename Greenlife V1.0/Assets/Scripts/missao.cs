using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripwireTrigger : MonoBehaviour
{
    // Refer�ncia ao painel que ser� ativado
    public GameObject triggerPanel;

    // M�todo chamado quando outro objeto colide com este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Ativa o painel
            triggerPanel.SetActive(true);

            // Destr�i o pr�prio tripwire
            Destroy(gameObject);
        }
    }
}