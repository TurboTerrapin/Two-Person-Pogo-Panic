using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject pivotPoint;

    [SerializeField]
    private GameObject respawnPoint;

    private Quaternion rotation;

    private Rigidbody2D rb;

    private float horizontal;

    [SerializeField]
    private float jumpMax;
    [SerializeField]
    private float jumpMin;
    [SerializeField]
    private float jumpCurrent;
    [SerializeField]
    private float jumpAcceleration;

    public bool isGrounded;

    [SerializeField]
    private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isGrounded = false;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");

        if (!isGrounded)
        {
            transform.Rotate(transform.forward, -horizontal * rotationSpeed * Time.deltaTime);
            
        }
        if (isGrounded)
        {
            transform.RotateAround(pivotPoint.transform.position, transform.forward, -horizontal * rotationSpeed * Time.deltaTime);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            rb.isKinematic = true;
            
            //pivotPoint.transform.position = pivotPoint.GetComponent<GroundChecker>().landedPos;
        }


        if(Input.GetKey(KeyCode.Space))
        {
            jumpCurrent += jumpAcceleration;
            jumpCurrent = Mathf.Clamp(jumpCurrent, jumpMin, jumpMax);
        }


        if (isGrounded && Input.GetKeyUp(KeyCode.Space))
        {
            rb.isKinematic = false;

            rb.AddForce(-transform.up * jumpCurrent, ForceMode2D.Impulse);
            isGrounded = false;
            jumpCurrent = jumpMin;
        }
        
        if (Input.GetKeyUp(KeyCode.R))
        {
            transform.position = respawnPoint.transform.position;
            transform.rotation = rotation;
        }


    }
}
