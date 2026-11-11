using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimentacaoCompleta : MonoBehaviour
{
    [Tooltip("Velocidade de movimento horizontal do personagem")]
    public float velocidade = 5f;

    [Tooltip("Força aplicada ao pular")]
    public float forcaPulo = 7f;

    [Tooltip("Tag do objeto que representa o chão")]
    public string tagChao = "Chao";

    private Rigidbody rb;
    private bool noChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Evita que o personagem tombe de lado ao colidir com paredes
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Movimento horizontal (A e D / Setas Esquerda e Direita)
        float entradaHorizontal = Input.GetAxis("Horizontal");
        Vector3 direcaoMovimento = new Vector3(entradaHorizontal, 0f, 0f);
        transform.Translate(direcaoMovimento * velocidade * Time.deltaTime, Space.World);

        // Pulo (Espaço)
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }

        if (entradaHorizontal > 0)
        {
            transform.localScale = new Vector3(7, 8, 1);
        }
        else if (entradaHorizontal < 0)
        {
            transform.localScale = new Vector3(-7, 8, 1);
        }
    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag(tagChao))
        {
            noChao = true;
        }
    }

    void OnCollisionExit(Collision colisao)
    {
        if (colisao.gameObject.CompareTag(tagChao))
        {
            noChao = false;
        }
    }
}
