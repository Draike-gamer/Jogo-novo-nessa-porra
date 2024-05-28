using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterJetController : MonoBehaviour
{
    public ParticleSystem waterJetParticleSystem;
    public ObjetoComVida[] objetosComVida;
    public Slider waterSlider;
    public GameObject objetoDeRecarga;

    public float maxWaterAmount = 100f;
    public float currentWaterAmount = 100f;

    private bool isWaterJetActive = false;

    void Start()
    {
        waterJetParticleSystem.Stop();
        currentWaterAmount = Mathf.Clamp(currentWaterAmount, 0f, maxWaterAmount);
        waterSlider.maxValue = maxWaterAmount;
        waterSlider.value = currentWaterAmount;
    }

    void Update()
    {
        // Verifica a colisão com o objeto de recarga com um Raycast de alcance menor
        Ray recargaRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit recargaHit;

        if (Physics.Raycast(recargaRay, out recargaHit, 1f)) // Alcance de 1 unidade
        {
            if (recargaHit.collider.gameObject == objetoDeRecarga)
            {
                RecarregarAgua();
            }
        }

        // Lógica de uso do jato de água
        if (Input.GetMouseButton(0) && currentWaterAmount > 10)
        {
            if (!isWaterJetActive)
            {
                ActivateWaterJet();
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 15f)) // Alcance de 15 unidades
            {
                // Lógica para aplicar dano em objetos com vida
                foreach (ObjetoComVida objetoComVida in objetosComVida)
                {
                    if (hit.collider.gameObject == objetoComVida.gameObject)
                    {
                        objetoComVida.AplicarDano(10);
                    }
                }

                // Lógica para transformar sementes em mudas de árvore
                Sementes sementes = hit.collider.GetComponent<Sementes>();
                if (sementes != null)
                {
                    sementes.Aguar(Time.deltaTime);
                }
            }

            currentWaterAmount -= Time.deltaTime * 10f;
            waterSlider.value = currentWaterAmount;
        }
        else
        {
            if (isWaterJetActive)
            {
                DeactivateWaterJet();
            }
        }
    }

    void ActivateWaterJet()
    {
        waterJetParticleSystem.Play();
        isWaterJetActive = true;
    }

    void DeactivateWaterJet()
    {
        waterJetParticleSystem.Stop();
        isWaterJetActive = false;
    }

    public void RecarregarAgua()
    {
        currentWaterAmount = maxWaterAmount;
        waterSlider.value = currentWaterAmount;
    }
}