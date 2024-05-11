using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObjeto : MonoBehaviour
{
    public float velocidadeHorizontal = 5f;
    public float velocidadeVertical = 3f; // Velocidade de subida/descida

    void Update()
    {
        // Obtém a entrada do eixo horizontal e vertical
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula o movimento horizontal
        Vector3 movimentoHorizontalVector = transform.right * movimentoHorizontal * velocidadeHorizontal * Time.deltaTime;

        // Calcula o movimento vertical
        Vector3 movimentoVerticalVector = transform.forward * movimentoVertical * velocidadeHorizontal * Time.deltaTime;

        // Calcula o movimento vertical adicional com base nas teclas pressionadas
        float movimentoAdicionalVertical = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            movimentoAdicionalVertical = velocidadeVertical * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            movimentoAdicionalVertical = -velocidadeVertical * Time.deltaTime;
        }

        // Move o objeto na direção calculada
        transform.position += movimentoHorizontalVector + movimentoVerticalVector + transform.up * movimentoAdicionalVertical;
    }
}