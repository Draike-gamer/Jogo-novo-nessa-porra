using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour
{
    public float sensibilidadeMouse = 2f;
    public Transform objetoAlvo;
    public Vector2 limiteVertical = new Vector2(-60, 60);

    private float rotacaoX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloqueia o cursor no centro da tela
    }

    void Update()
    {
        // Obtém o movimento do mouse
        float movimentoHorizontal = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float movimentoVertical = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // Rotaciona o objeto alvo (normalmente a câmera) horizontalmente
        objetoAlvo.Rotate(Vector3.up * movimentoHorizontal);

        // Rotaciona a câmera verticalmente
        rotacaoX -= movimentoVertical;
        rotacaoX = Mathf.Clamp(rotacaoX, limiteVertical.x, limiteVertical.y);

        // Aplica a rotação à câmera
        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
    }
}
