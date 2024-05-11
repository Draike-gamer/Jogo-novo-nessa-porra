using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesativarObjeto : MonoBehaviour
{
    public GameObject objetoParaDesativar;
    public Button botao;

    void Start()
    {
        if (botao != null)
        {
            // Adiciona um listener para o evento de clique do botão
            botao.onClick.AddListener(DesativarObjetoNaTela);
        }
        else
        {
            Debug.LogError("Botão não atribuído no inspetor.");
        }
    }

    void Update()
    {
        // Verifica se o objeto está ativo
        if (objetoParaDesativar.activeSelf)
        {
            // Se estiver ativo, deixa o cursor solto
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Se estiver inativo, trava o cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void DesativarObjetoNaTela()
    {
        // Desativa o objeto
        objetoParaDesativar.SetActive(false);
    }
}