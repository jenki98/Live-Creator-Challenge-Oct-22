using UnityEngine;

public class PumpkinScript : MonoBehaviour
{

    public PumpkinGenerator pumpkinGenerator;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * pumpkinGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.gameObject.CompareTag("NextLine"))
        {
            pumpkinGenerator.RandomGeneration();
        }

        if (collision.gameObject.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}

