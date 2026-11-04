using UnityEngine;

public class TocarSom : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Pega o componente Audio Source anexado ao mesmo objeto
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Exemplo: toca o som ao apertar a tecla Espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play(); // Reproduce o Audio Clip configurado
        }
    }
}