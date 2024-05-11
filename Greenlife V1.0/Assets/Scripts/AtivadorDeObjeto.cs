using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarDeObjeto : MonoBehaviour
{
    public GameObject objetoParaAtivar;

    private bool ativarObjeto = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ativarObjeto = !ativarObjeto;

            if (ativarObjeto)
            {
                objetoParaAtivar.SetActive(true);
            }
            else
            {
                objetoParaAtivar.SetActive(false);
            }
        }
    }
}