using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarDeObjeto : MonoBehaviour
{
    public GameObject objetoParaAtivar;
    public GameObject outroObjetoParaAtivar;

    private bool ativarObjeto = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ativarObjeto = !ativarObjeto;

            if (ativarObjeto)
            {
                objetoParaAtivar.SetActive(true);
                if (outroObjetoParaAtivar != null)
                    outroObjetoParaAtivar.SetActive(false);
            }
            else
            {
                objetoParaAtivar.SetActive(false);
                if (outroObjetoParaAtivar != null)
                    outroObjetoParaAtivar.SetActive(true);
            }
        }
    }
}