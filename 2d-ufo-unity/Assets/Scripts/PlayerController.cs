using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text CountText;
    private bool isOver = false;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb2d = GetComponent<Rigidbody2D> ();
        SetCountText ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOver == false)
        {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
        }
        if (isOver == true && Input.GetKeyDown (KeyCode.Space))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText ();
        }
    }

    void SetCountText () 
    {
        CountText.text = "Gems: " + count.ToString();
        if (count >= 16)
        {
            rb2d.velocity = Vector2.zero;
            isOver= true;
            winText.SetActive(true);

        }
    }
}
