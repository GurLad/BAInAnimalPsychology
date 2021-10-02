using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Mod;
    private void Update()
    {
        transform.position = Target.transform.position + Mod;
    }
}
