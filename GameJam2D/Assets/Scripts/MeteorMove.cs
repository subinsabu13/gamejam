using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        transform.localScale -= Vector3.one * MeteorSpawner.staticShrinkSpeed * Time.deltaTime;
        if (transform.childCount == 0)
        {
            MeteorSpawner.staticPassedCount++;                
            Destroy(gameObject);
        }
    }
}
