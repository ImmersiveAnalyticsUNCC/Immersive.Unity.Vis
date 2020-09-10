using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text counttext;
    public Text WinText;
    private void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        display();
        WinText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            count++;
            other.gameObject.SetActive(false);
            display();
        }
    }

    void display()
    {
        counttext.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You Win!!!!!!!!!";
            Time.timeScale = 0;
        }
    }
}
