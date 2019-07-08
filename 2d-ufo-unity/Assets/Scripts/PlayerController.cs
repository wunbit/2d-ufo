using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text CountText;

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
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
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
    }
}
