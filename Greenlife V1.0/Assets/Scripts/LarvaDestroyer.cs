using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaDestroyer : MonoBehaviour
{
    public ParticleSystem destroyParticleSystem;
    public LayerMask larvaLayer; // Layer específica para as larvas
    public GameObject painelAtivado;

    private bool isDestroyParticleSystemActive = false;

    void Start()
    {
        destroyParticleSystem.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isDestroyParticleSystemActive)
            {
                ActivateDestroyParticleSystem();
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f, larvaLayer)) // Alcance de 50 unidades
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
                
                if (hit.collider.CompareTag("Larva"))
                {
                    Debug.Log("Larva detected and destroyed: " + hit.collider.name);
                    Destroy(hit.collider.gameObject);
                    GlobalManager.Instance.IncrementarLarvasDestruidas(); // Incrementa o contador no GlobalManager
                }
                else
                {
                    Debug.Log("Hit an object, but it's not a larva: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object in the larva layer.");
            }
        }
        else
        {
            if (isDestroyParticleSystemActive)
            {
                DeactivateDestroyParticleSystem();
            }
        }
    }

    void ActivateDestroyParticleSystem()
    {
        destroyParticleSystem.Play();
        isDestroyParticleSystemActive = true;
    }

    void DeactivateDestroyParticleSystem()
    {
        destroyParticleSystem.Stop();
        isDestroyParticleSystemActive = false;
    }
}
