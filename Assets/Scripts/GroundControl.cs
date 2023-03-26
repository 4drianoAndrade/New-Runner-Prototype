using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D rb2DBridgeComponent;

    // Control variables
    private bool isInstantiated;

    private void Awake()
    {
        _GameController = FindObjectOfType<GameController>();
        rb2DBridgeComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2DBridgeComponent.velocity = new Vector2(_GameController.groundSpeedMovement, 0f);
    }

    private void Update()
    {
        if (isInstantiated == false)
        {
            if (transform.position.x <= 0f)
            {
                isInstantiated = true;

                int randomNumberRespawnGround = Random.Range(0, 100);
                int indexGroundPrefab;

                if (randomNumberRespawnGround < 50)
                {
                    indexGroundPrefab = 0;
                }
                else
                {
                    indexGroundPrefab = 1;
                }

                GameObject bridgeTemp = Instantiate(_GameController.groundPrefab[indexGroundPrefab]);
                float instantiatePositionX = transform.position.x + _GameController.groundSizeForInstantiation;
                bridgeTemp.transform.position = new Vector2(instantiatePositionX, transform.position.y);
            }
        }

        if (transform.position.x <= _GameController.distanceToDestroyGround)
        {
            Destroy(this.gameObject);
        }
    }
}
