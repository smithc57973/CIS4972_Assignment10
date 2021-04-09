/*
 * Chris Smith
 * Spawner
 * Assignment 10
 * A script to control enemy spawning.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public UIManager ui;
    float top = 18f;
    float bottom = -20f;
    float left = -32f;
    float right = 32f;

    private void Start()
    {
        //StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        int side = Random.Range(0, 4);
        Vector3 spawnPos = new Vector3();
        Debug.Log(side);
        if (side == 0)
        {
            spawnPos = new Vector3(Random.Range(left, right), 0, top);
        }
        if (side == 1)
        {
            spawnPos = new Vector3(Random.Range(left, right), 0, bottom);
        }
        if (side == 2)
        {
            spawnPos = new Vector3(left, 0, Random.Range(bottom, top));
        }
        if (side == 3)
        {
            spawnPos = new Vector3(right, 0, Random.Range(bottom, top));
        }

        ObjectPooler.instance.SpawnFromPool("Enemy", spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(side);
        StartCoroutine(Spawn());
    }
}
