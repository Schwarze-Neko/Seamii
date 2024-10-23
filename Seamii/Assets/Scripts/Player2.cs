using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        rb.velocity = movement * moveSpeed;
    }
}
