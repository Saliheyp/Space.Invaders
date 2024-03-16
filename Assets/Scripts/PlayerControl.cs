
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Boundary
{
public float xMin,xMax,zMin,zMax;
public float rotation;
}
public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioPlayer;
    public float speed =2;
    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;
    [SerializeField] float nextFire ;
    [SerializeField] float fireRate;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0 , moveVertical);
        
        rb.velocity = movement*speed;

        Vector3 position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),1,Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));

        rb.position = position;

            rb.rotation = Quaternion.Euler(0,0,rb.velocity.x*boundary.rotation);
        
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space) &&Time.time > nextFire )
        {
        nextFire = Time.time + fireRate;
        Instantiate(shot,shotSpawn.transform.position,shotSpawn.transform.rotation);
        audioPlayer.Play();
        }
    }
}
