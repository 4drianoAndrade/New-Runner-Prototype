using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rb2DBunnyComponent;

    // Control variables
    private bool isGrounded;

    private void Awake()
    {
        _GameController = FindAnyObjectByType<GameController>();
        rb2DBunnyComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }


    private void Update()
    {

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(_GameController.checkGroundTransform.position, _GameController.groundCheckRadiusSize, _GameController.groundJumpLayer);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb2DBunnyComponent.AddForce(new Vector2(0f, _GameController.jumpForceBunny * Time.fixedDeltaTime), ForceMode2D.Force);
        }
    }
}
