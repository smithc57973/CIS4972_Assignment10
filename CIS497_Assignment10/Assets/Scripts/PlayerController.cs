/*
 * Chris Smith
 * PlayerController
 * Assignment 10
 * A script for managing player inputs.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health;
    public UIManager ui;

    private void Start()
    {
        Time.timeScale = 1f;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ui.didTut)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                ObjectPooler.instance.SpawnFromPool("Turret", hit.point, Quaternion.identity);
            }
        }

        if (health <= 0)
        {
            ui.winLoss.text = "You Lose!\nPress R to restart.";
            ui.winLoss.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ObjectPooler.instance.ReturnObjectToPool("Enemy", collision.gameObject);
            health--;
        }
    }
}
