using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    private GameController _GameController;

    private Rigidbody2D rb2DBunnyComponent;



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
        JumpBunny();
    }

    private void JumpBunny()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2DBunnyComponent.AddForce(new Vector2(0f, _GameController.jumpForceBunny));
        }
    }
}
