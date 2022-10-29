
using UnityEngine;


public class PumpkinGenerator : MonoBehaviour
{

    public GameObject pumpkin;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float speedMultiplier;

    void Awake()
    {
        currentSpeed = minSpeed;
        GeneratePumpkin();
    }

    public void RandomGeneration()
    {
        float delay = Random.Range(0.01f, 0.5f);
        Invoke("GeneratePumpkin", delay);
    }
    private void GeneratePumpkin()
    {
        GameObject Pumpkin = Instantiate(pumpkin, transform.position, transform.rotation);
        Pumpkin.GetComponent<PumpkinScript>().pumpkinGenerator = this;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier;
        }

    }
}