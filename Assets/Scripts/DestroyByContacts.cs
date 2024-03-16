using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContacts : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.name == "Cube")
    {
        return;
    }
    if(other.gameObject.name == "Player")
    {
        Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
        gameController.GameOver();
    }
    
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(explosion,transform.position,transform.rotation);
        gameController.UpdateScore();
}
}
