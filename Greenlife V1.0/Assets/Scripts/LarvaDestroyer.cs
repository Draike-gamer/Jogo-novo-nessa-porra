using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaDestroyer : MonoBehaviour
{
    public ParticleSystem destroyParticleSystem;
    public GameObject painelAtivado;

    private bool isDestroyParticleSystemActive = false;

    void Start()
    {
        destroyParticleSystem.Stop();
        Debug.Log("Destroy particle system stopped at start.");
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

            if (Physics.Raycast(ray, out hit, 50f)) // Alcance de 50 unidades
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
                Debug.Log("Raycast did not hit any object.");
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
        Debug.Log("Destroy particle system activated.");
    }

    void DeactivateDestroyParticleSystem()
    {
        destroyParticleSystem.Stop();
        isDestroyParticleSystemActive = false;
        Debug.Log("Destroy particle system deactivated.");
    }
}