using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    public Vector3 spawnPosition;
    public float time = 2f;
    public float coolDown = 2f;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("Spawn", time, coolDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (!playerController.gameOver)
        {
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
     
    }
}
