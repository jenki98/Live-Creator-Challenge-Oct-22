
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 300f;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D rb;

    public TextMeshProUGUI text;
    Score scoreStruct;
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

        if (isAlive)
        {
            scoreStruct.score += Time.deltaTime * 4;
            text.text = "SCORE: " + scoreStruct.score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
                isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Pumpkin"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}
