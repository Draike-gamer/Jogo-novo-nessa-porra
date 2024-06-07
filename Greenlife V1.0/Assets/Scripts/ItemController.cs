using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject tanque;
    public ParticleSystem waterJetParticleSystem;
    public ParticleSystem destroyParticleSystem;

    public GameObject ativadorItem1;
    public GameObject ativadorItem2;
    public GameObject ativadorItem3;

    public Text interactionText;
    private GameObject currentHole;

    private GameObject itemAtivo;

    void Start()
    {
        waterJetParticleSystem.Stop();
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Verifica se a tecla 1 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha1) && !ativadorItem1.activeSelf)
        {
            AtivarItem(item1);
            waterJetParticleSystem.Stop();
            tanque.SetActive(true);
        }

        // Verifica se a tecla 2 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha2) && !ativadorItem2.activeSelf)
        {
            AtivarItem(item2);
            tanque.SetActive(false);
        }

        // Verifica se a tecla 3 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha3) && !ativadorItem3.activeSelf)
        {
            AtivarItem(item3);
            destroyParticleSystem.Stop();
            tanque.SetActive(false);
        }

        // Se o item2 estiver ativo, verifica o Raycast
        if (itemAtivo == item2)
        {
            VerificarInteracaoBuraco();
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void AtivarItem(GameObject novoItem)
    {
        if (itemAtivo != null)
        {
            itemAtivo.SetActive(false);
        }

        novoItem.SetActive(true);
        itemAtivo = novoItem;
    }

    void VerificarInteracaoBuraco()
    {
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