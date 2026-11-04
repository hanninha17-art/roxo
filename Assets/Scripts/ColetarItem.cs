using UnityEngine;
using TMPro;

public class ColetarItem : MonoBehaviour
{
    // Pontuação do jogador
    public static int pontuacao = 0;

    public TextMeshProUGUI coletaTexto;

    // Som da moeda
    public AudioClip somColeta;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Item"))
        {
            pontuacao += 10;

            Debug.Log("Pontuação atual: " + pontuacao);

            coletaTexto.text = pontuacao.ToString("0");

            // Reproduz o som da coleta
            if (somColeta != null)
            {
                AudioSource.PlayClipAtPoint(somColeta, transform.position);
            }

            // Destrói a moeda
            Destroy(outro.gameObject);
        }
    }
}