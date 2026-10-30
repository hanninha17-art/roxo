using UnityEngine;

public class ScriptDaBala : MonoBehaviour
{
    public int dano = 10; // Quantidade de dano que a bala causa

    // Se o seu jogo for 2D, mude para: OnTriggerEnter2D(Collider2D collision)
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se colidiu com o Jogador (certifique-se de que a Tag do jogador seja "Player")
        if (other.CompareTag("Player"))
        {
            // Tenta pegar o script de vida do jogador para aplicar o dano
            VidaEDano vida = other.GetComponent<VidaEDano>();
            
            if (vida != null)
            {
                vida.ReceberDano(dano);
            }

            // Destrói a bala após atingir o jogador
            Destroy(gameObject);
        }
        
        // Opcional: Destruir a bala se ela bater no cenário/paredes (ex: tag "Obstaculo")
        if (other.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }
    }
}