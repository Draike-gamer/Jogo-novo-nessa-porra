using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Certifique-se de que você está usando este namespace para manipular UI

public class ItemController : MonoBehaviour
{
    // Referências para os itens que você quer ativar/desativar
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject tanque;
    public ParticleSystem waterJetParticleSystem;

    // Referências para UI e o objeto sementes
    public Text interactionText; // Adicione uma referência ao texto de interação
    private GameObject currentHole; // Armazena o buraco atual que está sendo mirado

    // Variáveis para rastrear o estado de cada item
    private GameObject itemAtivo;

    void Start()
    {
        waterJetParticleSystem.Stop();
        interactionText.gameObject.SetActive(false); // Certifique-se de que o texto está desativado no início
    }

    void Update()
    {
        // Verifica se a tecla 1 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AtivarItem(item1);
            waterJetParticleSystem.Stop();
            tanque.SetActive(true);
        }

        // Verifica se a tecla 2 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AtivarItem(item2);
            tanque.SetActive(false);
        }

        // Verifica se a tecla 3 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AtivarItem(item3);
            tanque.SetActive(false);
        }

        // Se o item2 estiver ativo, verifica o Raycast
        if (itemAtivo == item2)
        {
            VerificarInteracaoBuraco();
        }
        else
        {
            interactionText.gameObject.SetActive(false); // Esconde o texto se o item2 não estiver ativo
        }
    }

    void AtivarItem(GameObject novoItem)
    {
        // Desativa o item atual, se houver
        if (itemAtivo != null)
        {
            itemAtivo.SetActive(false);
        }

        // Ativa o novo item
        novoItem.SetActive(true);
        // Define o novo item como o item ativo
        itemAtivo = novoItem;
    }

    void VerificarInteracaoBuraco()
    {
        // Realiza um Raycast a partir da câmera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Buraco"))
            {
                currentHole = hit.collider.gameObject;
                interactionText.text = "Plantar";
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Transform sementes = currentHole.transform.Find("Sementes");
                    if (sementes != null)
                    {
                        sementes.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
                currentHole = null;
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            currentHole = null;
        }
    }
}