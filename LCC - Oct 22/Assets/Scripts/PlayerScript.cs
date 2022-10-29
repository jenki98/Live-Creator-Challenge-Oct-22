
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

    public float timer = 0.0f;
    public TextMeshProUGUI text;
    public GameObject scoreManager;
    public GameObject gameOver;
    ScoreManager smScript;
    int score;
    private void Awake()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        smScript = scoreManager.GetComponent<ScoreManager>();
        
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
            timer += Time.deltaTime;
            //scoreStruct.score = (int)(timer % 60);
            score = (int)(timer % 60);
            text.text = "SCORE: " + score.ToString("F");
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
            PlayerPrefs.SetInt("Score", score);
            isAlive = false;
            SendScore();
            Time.timeScale = 0;
        }
    }

    void SendScore()
    {
        gameOver.SetActive(true);
        if (isAlive == false)
        {
            smScript.SendLeaderboard();
        }
    }
}
