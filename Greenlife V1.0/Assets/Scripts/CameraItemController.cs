using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItemController : MonoBehaviour
{
    // Referência para o GameObject que contém os itens
    public Transform itemHolder;

    void Update()
    {
        // Garante que o itemHolder sempre esteja na mesma posição e rotação da câmera
        itemHolder.position = transform.position;
        itemHolder.rotation = transform.rotation;
    }
}
