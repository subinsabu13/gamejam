﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public void Update()
	{
		Destroy(gameObject, 2.0f);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}