using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    private int count = 0;
    private int totalPickups;

    public Text scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Count how many pickup cubes exist in the scene at start
        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        // Initial message
        scoreText.text = "Collect all the cubes!";
    }

    void FixedUpdate()
    {  
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            count++;

            // Hide the cube completely
            other.gameObject.SetActive(false);

            if (count >= totalPickups)
            {
                // All cubes collected
                scoreText.text = "Good job!";
            }
        }
    }
}
