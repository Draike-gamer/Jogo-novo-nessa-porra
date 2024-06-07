using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtivadorController : MonoBehaviour
{
    public GameObject ativadorItem1;
    public GameObject ativadorItem2;
    public GameObject ativadorItem3;
    public Text interactionText;

    private GameObject currentAtivador; // Armazena o ativador atualmente mirado
    private bool isAtivadorAtivo = false;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Ativador"))
            {
                currentAtivador = hit.collider.gameObject;
                interactionText.text = "Take";
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    DesativarAtivador(currentAtivador);
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
                currentAtivador = null;
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            currentAtivador = null;
        }
    }

    void DesativarAtivador(GameObject ativador)
    {
        ativador.SetActive(false);
        interactionText.gameObject.SetActive(false);
        Debug.Log("Ativador desativado: " + ativador.name);
    }
}