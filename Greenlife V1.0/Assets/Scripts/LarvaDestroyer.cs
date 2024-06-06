using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaDestroyer : MonoBehaviour
{
    public ParticleSystem destroyParticleSystem;
    public GameObject painelAtivado;

    public bool isDestroyParticleSystemActive = false;
    public float destroyDelay = 2.0f; // Tempo de atraso em segundos
    private int larvasDestruidas = 0;
    private const int maxLarvasDestruidas = 15;

    void Start()
    {
        destroyParticleSystem.Stop();
        isDestroyParticleSystemActive = false;
        painelAtivado.SetActive(false); // Certifique-se de que o painel esteja desativado no início
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
                    Debug.Log("Larva detected: " + hit.collider.name);
                    StartCoroutine(DestroyLarvaAfterDelay(hit.collider.gameObject, destroyDelay));
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

    private IEnumerator DestroyLarvaAfterDelay(GameObject larva, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (isDestroyParticleSystemActive)
        {
            Debug.Log("Larva destroyed: " + larva.name);
            Destroy(larva);
            IncrementarLarvasDestruidas();
        }
    }

    private void IncrementarLarvasDestruidas()
    {
        larvasDestruidas++;
        GlobalManager.Instance.IncrementarLarvasDestruidas(); // Incrementa o contador no GlobalManager

        if (larvasDestruidas >= maxLarvasDestruidas)
        {
            AtivarPainel();
        }

        Debug.Log("Larvas destruídas: " + larvasDestruidas);
    }

    private void AtivarPainel()
    {
        painelAtivado.SetActive(true);
        Debug.Log("Painel ativado.");
    }
}