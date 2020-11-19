using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;

    public GameObject CountdownText;
    int SpacePressed = 10;
    int PowerUpLeft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressed--;
            CountdownText.GetComponent<Text>().text = "Countdown: " + SpacePressed;
        }
        if (SpacePressed <= 0)
        {
            CountdownText.GetComponent<Text>().text = "Countdown: 0";
            SceneManager.LoadScene("LoseScene");
        }

        // goto win screen
        if (PowerUpLeft <= 0)
        {           
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PowerUp")
        {
            SpacePressed+=5;
            PowerUpLeft--;
            CountdownText.GetComponent<Text>().text = "Countdown: " + SpacePressed;
            Destroy(other.gameObject);
        }

        // goto lose screen
        if (other.gameObject.tag == "Enemy")
        {           
            //Destroy(gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }
}
