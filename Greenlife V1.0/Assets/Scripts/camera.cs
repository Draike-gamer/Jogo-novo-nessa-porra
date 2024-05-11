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
        // Obt�m o movimento do mouse
        float movimentoHorizontal = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float movimentoVertical = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // Rotaciona o objeto alvo (normalmente a c�mera) horizontalmente
        objetoAlvo.Rotate(Vector3.up * movimentoHorizontal);

        // Rotaciona a c�mera verticalmente
        rotacaoX -= movimentoVertical;
        rotacaoX = Mathf.Clamp(rotacaoX, limiteVertical.x, limiteVertical.y);

        // Aplica a rota��o � c�mera
        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
    }
}
