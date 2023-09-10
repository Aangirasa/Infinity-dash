using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController controller;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(gameObject.CompareTag("obstacle") && transform.position.x < -25)
        {
            Destroy(gameObject);
        }
       
    }
}
