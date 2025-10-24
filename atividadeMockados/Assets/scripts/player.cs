using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; 
    private Rigidbody2D rb;
    private bool isGrounded;
    private int vida;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = 5;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 direcao = new Vector2(horizontal, vertical);
        rb.linearVelocity = direcao.normalized;
        this.GetComponent<Rigidbody2D>().linearVelocity = direcao * this.moveSpeed;

        Debug.Log("vida atual: " + vida);
    }

    public void ReceberDano()
    {
        this.vida--;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Dano"))
        {
            itemDano Dano = collider.GetComponent<itemDano>();
            ReceberDano();

        }
    }

}
