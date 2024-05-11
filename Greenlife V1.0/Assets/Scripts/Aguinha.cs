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
        if (Input.GetMouseButton(0) && currentWaterAmount > 0)
        {
            if (!isWaterJetActive)
            {
                ActivateWaterJet();
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                foreach (ObjetoComVida objetoComVida in objetosComVida)
                {
                    if (hit.collider.gameObject == objetoComVida.gameObject)
                    {
                        objetoComVida.AplicarDano(10);
                    }
                }

                if (hit.collider.gameObject == objetoDeRecarga) // Verifica se colidiu com o objeto de recarga
                {
                    RecarregarAgua(); // Se sim, recarrega a água
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