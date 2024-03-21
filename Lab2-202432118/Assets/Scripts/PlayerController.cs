using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x, z;
    private float force = 10f;
    private Vector3 movement;
    private Rigidbody rb;

    private int health = 10;
    private int points = 0;
    private bool isPaused = false;
    private int numberFoods;

    public AudioSource audioSource;
    public AudioClip eatClip;
    public AudioClip failClip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numberFoods = GameObject.FindGameObjectsWithTag("Food").Length;
        if (rb == null)
        {
            Debug.Log("Error no Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        movement = new Vector3(x, 0, z).normalized;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Debug.Log("Pause: " + isPaused);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Debug.Log("Pause: " + isPaused);
                Time .timeScale = 1;
                isPaused = false;
            }
        }

        if (points == numberFoods)
        {
            Debug.Log("Congrats all food eaten");
            Time.timeScale = 0;
        }

        if (health == 0)
        {
            Debug.Log("Died");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * force, ForceMode.Force);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
        Debug.Log($"Points: {points}\n Health: {health}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            points++;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(eatClip);
        }

        if (other.tag == "Notedible")
        {
            health--;
            audioSource.PlayOneShot(failClip);
        }

        if(other.tag == "Enemy")
        {
            health--;
        }
        Debug.Log($"Points: {points}\n Health: {health}");
    }
}
