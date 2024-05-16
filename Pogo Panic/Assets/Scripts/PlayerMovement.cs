using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject pivotPoint;


    private Rigidbody2D rb;

    private float horizontal;


    public bool isGrounded;

    [SerializeField]
    private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");

        if (!isGrounded)
        {
            transform.Rotate(transform.forward, horizontal * rotationSpeed * Time.deltaTime);
        }
        if (isGrounded)
        {
            transform.RotateAround(pivotPoint.transform.forward, transform.forward, -horizontal * rotationSpeed * Time.deltaTime);
            //pivotPoint.GetComponent<Rigidbody2D>().isKinematic = true;
        }





        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            //pivotPoint.GetComponent<Rigidbody2D>().isKinematic = false;
            rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
            isGrounded = false;
        }


    }
}
