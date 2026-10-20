using UnityEngine;
public class Movimento : MonoBehaviour
{
// Lógica explicada pelo aluno:
// ele se move apenas para esquerda e para a direita, usando as teclas A e D
    [Tooltip("Velocidade de movimento do personagem")]
    public float velocidade = 5;
    void Update()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        float entradaVertical = Input.GetAxis("Vertical");
        Vector2 direcao = new Vector2(entradaHorizontal, 0);
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}