using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 300f;
    float movement = 0f;
    
    public static bool playerHit = false;

    public GameObject BulletPrefeb;
    public float bullspeed;
    public Transform gunPos;
    void Start()
    {
        playerHit = false;
    }
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -moveSpeed);
    }
    void Shoot()
    {
        GameObject bull = Instantiate(BulletPrefeb, gunPos.position, Quaternion.identity);
        bull.GetComponent<Rigidbody2D>().velocity = transform.up * 100;
    }
}
