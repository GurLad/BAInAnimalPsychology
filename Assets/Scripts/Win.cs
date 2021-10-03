using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public string NextLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneLoader.LoadScene(NextLevel);
        }
    }
}
