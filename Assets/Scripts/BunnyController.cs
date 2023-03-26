using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rb2DBunnyComponent;

    // Control variables
    private bool isGrounded;
    private bool isPunctuated;

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
            rb2DBunnyComponent.AddForce(new Vector2(0f, _GameController.jumpForceBunny));
        }
    }

    private void LateUpdate()
    {
        if (isPunctuated == true)
        {
            _GameController.ToScore(1);
            isPunctuated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Collectable":
                isPunctuated = true;
                Destroy(collision.gameObject);
                break;

            case "Obstacle":
                _GameController.ChangeScene("GameOver");
                break;
        }
    }
}
