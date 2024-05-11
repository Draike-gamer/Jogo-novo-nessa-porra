using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Referências para os itens que você quer ativar/desativar
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    // Variáveis para rastrear o estado de cada item
    private GameObject itemAtivo;

    void Update()
    {
        // Verifica se a tecla 1 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AtivarItem(item1);
        }

        // Verifica se a tecla 2 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AtivarItem(item2);
        }

        // Verifica se a tecla 3 foi pressionada
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AtivarItem(item3);
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
}
