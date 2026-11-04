using UnityEngine;
using TMPro;

public class VidaEDano : MonoBehaviour
{
    // Lógica explicada pelo aluno:
    // quando o colisor do jogador colidir com o colisor do inimigo ele receberá 10 de dano
    public TextMeshProUGUI quantidadeVida;
    public GameOverManager gameOverManager;
    public int vida = 100;

    // NOVO: Criamos um Start para a vida já começar aparecendo certa na tela ao iniciar o jogo
    void Start()
    {
        if (quantidadeVida != null)
        {
            quantidadeVida.text = vida.ToString("0");
        }
    }

    public void ReceberDano(int quantidade)
    {
        vida -= quantityVida(quantidade); // Evita que a vida fique negativa
        Debug.Log(gameObject.name + " recebeu " + quantidade + " de dano. Vida atual: " + vida);
        
        if (quantidadeVida != null)
        {
            quantidadeVida.text = vida.ToString("0");
        }
    }

    // Função auxiliar para garantir que a vida não fique menor que 0
    private int quantityVida(int dano)
    {
        int resultado = vida - dano;
        return resultado < 0 ? vida : dano; 
    }

    void OnTriggerEnter(Collider outro)
    {
        // 1. Coleta de item de vida
        if (outro.CompareTag("vida"))
        {
            vida += 10;
            Debug.Log("vida atual: " + vida);
            Destroy(outro.gameObject);
        }
        
        // 2. ENCAIXE AQUI: Detecção do tiro do Inimigo
        if (outro.CompareTag("BalaInimigo"))
        {
            ReceberDano(10); // Aplica 10 de dano (ou o valor que preferir)
            Destroy(outro.gameObject); // Destrói a bala após ela atingir o jogador
        }

        if (quantidadeVida != null)
        {
            quantidadeVida.text = vida.ToString("0");
        }
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu.");
        // Se quiser colocar uma tela de Game Over, o código entraria aqui!
         gameOverManager.ShowGameOver();
    }

    void Update()
    {
        if (vida <= 0)
        {
            Morrer();
            Destroy(gameObject); // Destruir por último para dar tempo de rodar o script
        }
    }

    void OnCollisionEnter(Collision coliDano)
    {
        if (coliDano.gameObject.CompareTag("Inimigo"))
        {
            ReceberDano(10);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("void"))
        {
            ReceberDano(100); 
        }
    }
}