using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaDestroyer : MonoBehaviour
{
    public ParticleSystem destroyParticleSystem;
<<<<<<< HEAD
=======
    public LayerMask larvaLayer; // Layer específica para as larvas
>>>>>>> parent of 215171a (goosecadovaitomanocu)
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

<<<<<<< HEAD
            if (Physics.Raycast(ray, out hit, 50f)) // Alcance de 50 unidades
            {
                Debug.Log("Raycast hit: " + hit.collider.name);

=======
            if (Physics.Raycast(ray, out hit, 50f, larvaLayer)) // Alcance de 15 unidades
            {
>>>>>>> parent of 215171a (goosecadovaitomanocu)
                if (hit.collider.CompareTag("Larva"))
                {
                    Destroy(hit.collider.gameObject);
                    GlobalManager.Instance.IncrementarLarvasDestruidas(); // Incrementa o contador no GlobalManager
                }
<<<<<<< HEAD
                else
                {
                    Debug.Log("Hit an object, but it's not a larva: " + hit.collider.name);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
=======
>>>>>>> parent of 215171a (goosecadovaitomanocu)
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