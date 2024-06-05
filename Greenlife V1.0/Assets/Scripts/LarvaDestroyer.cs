using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaDestroyer : MonoBehaviour
{
    public ParticleSystem destroyParticleSystem;
    public GameObject painelAtivado;

    public bool isDestroyParticleSystemActive = false;

    void Start()
    {
        destroyParticleSystem.Stop();
        isDestroyParticleSystemActive = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivateDestroyParticleSystem();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DeactivateDestroyParticleSystem();
        }

        if (isDestroyParticleSystemActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f)) // Alcance de 50 unidades
            {
                if (hit.collider.CompareTag("Larva"))
                {
                    Debug.Log("Larva detected and destroyed: " + hit.collider.name);
                    Destroy(hit.collider.gameObject);
                    GlobalManager.Instance.IncrementarLarvasDestruidas(); // Incrementa o contador no GlobalManager
                }
            }
        }
    }

    void ActivateDestroyParticleSystem()
    {
        destroyParticleSystem.Play();
        isDestroyParticleSystemActive = true;
        Debug.Log("Destroy particle system activated.");
    }

    void DeactivateDestroyParticleSystem()
    {
        destroyParticleSystem.Stop();
        isDestroyParticleSystemActive = false;
        Debug.Log("Destroy particle system deactivated.");
    }
}