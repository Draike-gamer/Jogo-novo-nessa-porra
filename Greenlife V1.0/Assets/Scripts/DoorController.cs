using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public GameObject requiredKey; // Chave necessária para abrir esta porta
    public Text interactionText;
    public KeyCode interactKey = KeyCode.E;

    private Animator animator;
    private bool hasKey = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckInteraction();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasKey)
        {
            Open();
        }
    }

    void CheckInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Door"))
        {
            if (hasKey)
            {
                interactionText.text = "Open";
            }
            else
            {
                interactionText.text = "Locked";
            }

            interactionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(interactKey))
            {
                if (!hasKey)
                {
                    Debug.Log("You need a key to open this door.");
                    return;
                }

                Open();
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Open()
    {
        animator.SetTrigger("abrir");
    }

    public void CollectKey()
    {
        hasKey = true;
        requiredKey.SetActive(false); // Desativa a chave ao coletá-la
        Debug.Log("Key collected: " + requiredKey.name);

        // Atualiza o texto para "Open" ao coletar a chave
        interactionText.text = "Open";
    }
}
