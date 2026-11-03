using UnityEngine;
using TMPro;

public class VidaInimigo : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public float vidaMaxima = 100f;
    private float vidaAtual;
    public TextMeshProUGUI vidaDoInimigo;

    void Start()
    {
        // Inicializa a vida do inimigo com o valor máximo no início do jogo
        vidaAtual = vidaMaxima;
    }

    // Este é o método público que o script do Jogador vai chamar
    public void TomarDano(float quantidadeDano)
    {
        // Subtrai o dano da vida atual
        vidaAtual -= quantidadeDano;
        
        Debug.Log(gameObject.name + " recebeu " + quantidadeDano + " de dano. Vida restante: " + vidaAtual);

        // Se quiser tocar uma animação de "efeito de dano" ou piscar uma cor, o código entra aqui

        // Verifica se a vida acabou
        if (vidaAtual <= 0)
        {
            Morrer();
        }

        if (vidaDoInimigo != null)
        {
            vidaDoInimigo.text = vidaAtual.ToString("0");
        }
    }

    void Morrer()
    {
        Debug.Log(gameObject.name + " morreu!");
        
        // Aqui você pode instanciar um efeito de explosão ou soltar itens (loot) antes de destruir
        
        // Destrói o objeto do inimigo
        Destroy(gameObject);
    }
}