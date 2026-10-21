using UnityEngine;

public class Atirador : MonoBehaviour
{
    [Header("Configurações de Tiro")]
    public GameObject bulletPrefab; // O prefab do projétil/bala que você quer atirar
    public Transform firePoint;     // O local (Vazio/Empty) de onde a bala vai sair
    public float bulletSpeed = 20f; // A velocidade do tiro

    void Update()
    {
        // Detecta o clique do botão esquerdo do mouse ou o botão de disparo padrão ("Fire1")
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cria uma cópia da bala na posição e rotação do firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Obtém o Rigidbody do projétil criado para aplicar força e fazê-lo se mover
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            // Se for um jogo 2D, empurra para a direção "direita" do ponto de tiro
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }
    }
}