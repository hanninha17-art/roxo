using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Pulo : MonoBehaviour
{
    public float forcaPulo = 7;
    private bool noChao = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    }
    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }
    void OnCollisionExit(Collision colisao)
    {
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = false;
        }
    }
}
