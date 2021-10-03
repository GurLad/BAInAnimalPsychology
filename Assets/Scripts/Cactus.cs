using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public List<GameObject> Models;

    private void Start()
    {
        transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        Models[Random.Range(0, Models.Count)].SetActive(true);
    }
}
