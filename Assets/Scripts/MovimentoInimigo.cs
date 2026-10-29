using UnityEngine;

public class MovimentoInimigo : MonoBehaviour 
{
    [SerializeField] private Transform[] PontosDeCaminho;
    [SerializeField] private float velocidadeDeMovimento = 5f;
    
    private int pontoAtual = 0;
    private float ultimaPosicaoX;

    void Update() 
    {
        MovimentarInimigo();
        EspelharNaHorizontal();
    }

    private void MovimentarInimigo() 
    {
        // Proteção caso nenhum ponto tenha sido arrastado no Inspector do Unity
        if (PontosDeCaminho == null || PontosDeCaminho.Length == 0) return;

        // Move o inimigo em direção ao ponto atual do caminho
        transform.position = Vector2.MoveTowards(transform.position, PontosDeCaminho[pontoAtual].position, velocidadeDeMovimento * Time.deltaTime);

        // Verifica se a posição atual é igual à posição do ponto (usando distância para evitar falhas de precisão de float)
        if (Vector2.Distance(transform.position, PontosDeCaminho[pontoAtual].position) < 0.1f) 
        {
            pontoAtual += 1;
            ultimaPosicaoX = transform.localPosition.x;

            // Se chegou ao fim do caminho, volta para o primeiro ponto
            if (pontoAtual >= PontosDeCaminho.Length) 
            {
                pontoAtual = 0;
            }
        }
    }

    private void EspelharNaHorizontal()
    {
        if (transform.localPosition.x < ultimaPosicaoX)
        {
            transform.localScale = new Vector3 (1f, 1f, 1f);
        }

        else if (transform.localPosition.x > ultimaPosicaoX)
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
    }
}