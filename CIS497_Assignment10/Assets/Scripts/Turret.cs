/*
 * Chris Smith
 * Turret
 * Assignment 10
 * A class defining a turret and its actions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range;
    public bool canUse;

    // Start is called before the first frame update
    void Start()
    {
        range = 3f;
        canUse = false;
        StartCoroutine(Startup());
    }

    // Update is called once per frame
    void Update()
    {
        if (canUse)
        {
            GameObject[] goWithTag = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < goWithTag.Length; ++i)
            {
                if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= range)
                {
                    ObjectPooler.instance.ReturnObjectToPool("Enemy", goWithTag[i]);
                    ObjectPooler.instance.ReturnObjectToPool("Turret", this.gameObject);
                }
            }
        }
        
    }

    public IEnumerator Startup()
    {
        yield return new WaitForSeconds(1f);
        canUse = true;
    }
}
