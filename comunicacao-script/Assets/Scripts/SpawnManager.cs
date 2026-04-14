using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    [SerializeField] PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle ()
    {
        if (!playerControllerScript.isGameOver()) {
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPos,
                obstaclePrefab.transform.rotation);
            // recuperamos o script do objeto instanciado
            MoveLeft moveLeftScript = obstacle.GetComponent<MoveLeft>();
            moveLeftScript.Init(playerControllerScript);
        }
    } 
}
