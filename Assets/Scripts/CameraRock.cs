using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRock : MonoBehaviour
{
    public float Rate;
    public float Strength;
    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        transform.position = initPos + new Vector3(0, Mathf.Sin(Time.time * Rate) * Strength);
    }
}
