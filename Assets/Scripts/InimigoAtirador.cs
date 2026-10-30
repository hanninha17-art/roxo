using UnityEngine;

public class InimigoAtirador : MonoBehaviour
{
    [Header("Configurações de Tiro")]
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public float bulletSpeed = 20f; 
    public float fireRate = 1f;       // Tempo de espera entre os tiros (em segundos)
    private float nextFireTime = 0f;  // Controla quando o inimigo pode atirar novamente

    [Header("Configurações de Detecção")]
    public Transform player;          // Arraste o jogador aqui no Inspetor
    public float detectionRange = 10f; // Distância mínima para começar a atirar

    void Update()
    {
        // Verifica se o jogador foi referenciado
        if (player == null) return;

        // Calcula a distância atual entre o inimigo e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Se o jogador estiver perto E o tempo de recarga já passou
        if (distanceToPlayer <= detectionRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Define o próximo momento em que poderá atirar
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            // Se o seu jogo for 2D, usa firePoint.right. Se for 3D, use firePoint.forward
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }

    // Desenha um círculo/esfera no editor para você visualizar o alcance do inimigo
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}