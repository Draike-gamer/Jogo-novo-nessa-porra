using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SimpleTimer : MonoBehaviour
{
    public float totalTime = 60f; // Tempo total do temporizador em segundos
    private float timeRemaining; // Tempo restante do temporizador
    public Text timerText; // Referência ao texto que mostrará o temporizador
    private bool timerIsRunning = false; // Flag para verificar se o temporizador está rodando

    // Referência ao script do tripwire
    public GameStateSaver gameStateSaver;

    void Start()
    {
        // Iniciar o temporizador
        StartTimer();
    }

    void Update()
    {
        // Verificar se o temporizador está rodando
        if (timerIsRunning)
        {
            // Atualizar o tempo restante
            timeRemaining -= Time.deltaTime;

            // Verificar se o tempo restante é menor ou igual a zero
            if (timeRemaining <= 0)
            {
                // Se o tempo acabou, parar o temporizador
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Tempo acabou!");
                Cursor.lockState = CursorLockMode.None;

                // Chama a função para indicar que o temporizador chegou a zero no GameStateSaver
                gameStateSaver.ResetScene();
            }

            // Atualizar o texto do temporizador
            DisplayTime(timeRemaining);
        }
    }

    // Método para iniciar o temporizador
    public void StartTimer()
    {
        // Inicializar o tempo restante com o tempo total
        timeRemaining = totalTime;
        timerIsRunning = true;
    }

    // Método para atualizar o texto do temporizador
    void DisplayTime(float timeToDisplay)
    {
        // Converter o tempo restante para minutos e segundos
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Atualizar o texto do temporizador
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}