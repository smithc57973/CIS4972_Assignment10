/*
 * Chris Smith
 * UIManager
 * Assignment 10
 * A script to manage UI elements.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController pc;
    public Spawner s;
    public Text text;
    public Text winLoss;
    public Text tutorial;
    public int time;
    public bool didTut;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Tower").GetComponent<PlayerController>();
        tutorial.gameObject.SetActive(true);
        winLoss.gameObject.SetActive(false);
        time = 60;
        didTut = false;
        StartCoroutine(Tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + pc.health + "\nTime: " + time;
        if (time <= 0)
        {
            winLoss.text = "You Win!\nPress R to restart.";
            winLoss.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        time--;
        StartCoroutine(Timer());
    }

    public IEnumerator Tutorial()
    {
        tutorial.text = "Click anywhere on the screen to summon a turret.";
        yield return new WaitForSeconds(3f);
        tutorial.text = "You can only have 3 turrets active at a time.";
        yield return new WaitForSeconds(3f);
        tutorial.text = "Enemies will come from all sides, they want to attack your base in the middle.";
        yield return new WaitForSeconds(3f);
        tutorial.text = "Enemies near turrets will disappear, but break the turret.";
        yield return new WaitForSeconds(3f);
        tutorial.text = "Survive the onslaught!";
        yield return new WaitForSeconds(2f);
        didTut = true;
        tutorial.gameObject.SetActive(false);
        StartCoroutine(Timer());
        StartCoroutine(s.Spawn());
    }
}
