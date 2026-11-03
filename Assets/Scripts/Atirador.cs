using UnityEngine;

public class Atirador : MonoBehaviour 
{
    [Header("Configurações de Tiro")]
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f; 

    [Header("Configurações de Ataque Corpo a Corpo (Tecla E)")]
    public float danoAtaque = 10f;
    public Transform pontoDeAtaque;
    public float raioDeAtaque = 1.5f;
    public LayerMask camadaInimigo; // Defina no Inspector qual layer é o "Inimigo"

    void Update() 
    {
        // Tiro com botão esquerdo do mouse / Fire1
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot(); 
        }

        // Ataque com a tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarInimigoNaZona();
        }
    }

    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        Rigidbody rb = bullet.GetComponent<Rigidbody>(); // Ajustado para Rigidbody2D se for o caso
        if (rb != null) 
        {
            rb.linearVelocity = firePoint.right * bulletSpeed; 
        }
    }

    void AtacarInimigoNaZona()
    {
        // Detecta todos os colliders dos inimigos dentro do raio de ataque
        Collider[] inimigosAtingidos = Physics.OverlapSphere(pontoDeAtaque.position, raioDeAtaque, camadaInimigo);

        foreach (Collider inimigoCollider in inimigosAtingidos)
        {
            // Busca o script 'Inimigo' no objeto que foi atingido
            VidaInimigo inimigo = inimigoCollider.GetComponent<VidaInimigo>();

            // Se o objeto realmente tiver o script de Inimigo, aplica o dano
            if (inimigo != null)
            {
                inimigo.TomarDano(danoAtaque);
            }
        }
    }

    // Desenha a esfera de ataque na aba Scene para facilitar o ajuste do raio
    void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoDeAtaque.position, raioDeAtaque);
    }
}