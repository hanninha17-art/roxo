using UnityEngine;
using TMPro;
public class ColetarItem : MonoBehaviour
{
// Lógica explicada pelo aluno:
// Quando o jogador colidir com prefab deverá coleta-lo, fazendo ele desaparecer e acrescentar 10 pontos ao contador de pontos do jogador
    // Marque o Collider do item como "Is Trigger" no Inspector
    public static int pontuacao = 0;
     public TextMeshProUGUI coletaTexto;
    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Item"))
        {
            pontuacao += 10;
            Debug.Log("Pontuação atual: " + pontuacao);
            Destroy(outro.gameObject);
        }
        coletaTexto.text=pontuacao.ToString("0");
    }
}