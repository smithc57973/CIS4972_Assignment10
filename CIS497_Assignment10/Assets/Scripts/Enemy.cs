/*
 * Chris Smith
 * Enemy
 * Assignment 10
 * A class defining an enemy and its actions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject tower;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower");
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, Time.deltaTime);
    }
}
