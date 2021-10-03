using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteForceSetMusic : MonoBehaviour
{
    public string Name;

    private void Start()
    {
        CrossfadeMusicPlayer.Instance.Play(Name);
    }
}
