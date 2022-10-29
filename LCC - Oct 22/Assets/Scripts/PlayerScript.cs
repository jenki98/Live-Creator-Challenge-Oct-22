
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 300f;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
               ;
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
                isGrounded = true;
        }    
    }
}
