using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private int Score = 0;

    private float scoreInterval = 1;
    private float nextscore = 3f;

    public Text Scoretxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 4 || transform.position.y <= -4)
        {
            transform.position = new Vector3(0, 0, 0);
        }

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (Time.time >= nextscore)
        {
            nextscore = Time.time + scoreInterval;
            Score++;
        }

        Scoretxt.text = "Score: " + Score;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
