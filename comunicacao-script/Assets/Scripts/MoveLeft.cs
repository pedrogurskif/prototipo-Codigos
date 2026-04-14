using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;
    private float leftBound = -10;
    [SerializeField] PlayerController playerControllerScript;

    public void Init(PlayerController script)
    {
        playerControllerScript = script;
    }

    void Update()
    {
        if (!playerControllerScript.isGameOver())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);    

            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
