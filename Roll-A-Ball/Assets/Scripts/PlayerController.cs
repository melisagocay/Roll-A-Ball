using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;

    public Text scoreText;
    public Text livesText;
    
    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;
    

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        score = 0;
        scoreText.text = "Score: " + score.ToString ();
        lives = 3;
        SetLivesText ();
        loseText.text = "";
        winText.text = "";
    }
    


    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed); 
        if (Input.GetKey("escape"))
            Application.Quit ();
     

    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1; 
            SetCountText();
            score = score + 1; // I added this code to track the score and count separately.
            SetScoreText();
        }

        if (score == 12)
        {
             transform.position = new Vector3(-22.7f, transform.position.y,0.5f);
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {       
            other.gameObject.SetActive(false);
             count = count + 1;
            SetCountText();
            //score = score - 1; // this removes 1 from the score
            SetScoreText();
            lives = lives - 1;
            SetLivesText ();
        }
        if(lives == 0)
        {
            Destruction ();
        }
    }
    void Destruction ()
    {
        Destroy(this.gameObject); 
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
    }
    
    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            loseText.text = "You Lost!";
        }
    }
    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 20)
        {
            winText.text = "You Win!";
        }

    }


}
