using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeteorSpawner : MonoBehaviour
{
    private int passedCount = 0;
    public static int staticPassedCount = 0;

    public GameObject[] meteorPrefabs;
    public GameObject meteorSetGO;
    public Text wavesCountText;

    private float nextTimeToSpawn = 0f;
    public float shrinkSpeed = 0.05f;
    public static float staticShrinkSpeed;
    public static float spawnRate = 0.07f;

    private bool setCreated = false;
    private bool initialLoad = true;
    public static bool startShrink = false;
    void Start()
    {
        initialLoad = true;
        startShrink = false;
        staticPassedCount = 0;
    }
    void Update()
    {
        passedCount = staticPassedCount;
        GameObject go, meteorSet = null;
        staticShrinkSpeed = shrinkSpeed;
        if (Time.time >= nextTimeToSpawn)
        {
            if (setCreated || initialLoad)
            {
                setCreated = false;
                initialLoad = false;
                meteorSet = Instantiate(meteorSetGO, new Vector3(0.0f, 0.0f, -4.0f), Quaternion.identity);
            }

            int points;
            Vector3[] vertices3D;
            points = Random.Range(10, 15);
            vertices3D = new Vector3[points];
            for (int i = 0; i < vertices3D.Length; i++)
            {
                float x = Mathf.Cos((i / (float)points) * 2 * Mathf.PI);
                float y = Mathf.Sin((i / (float)points) * 2 * Mathf.PI);
                vertices3D[i] = new Vector3(x, y, -4.0f);
                go = Instantiate(meteorPrefabs[Random.Range(0, meteorPrefabs.Length)], vertices3D[i], Quaternion.identity);
                go.transform.parent = meteorSet.transform;
                if (i == vertices3D.Length - 1)
                {
                    setCreated = true;
                    startShrink = true; // to start the wave movement
                }
            }
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
        wavesCountText.text = (passedCount < 10 ? "0" : "") + ((int)passedCount).ToString();
    }
}
