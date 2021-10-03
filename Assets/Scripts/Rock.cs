using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool check = false;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (check)
            {
                Destroy(gameObject);
            }
            else
            {
                check = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            Destroy(this);
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
