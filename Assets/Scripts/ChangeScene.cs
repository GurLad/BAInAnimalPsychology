using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string Scene;

    public void Click()
    {
        SceneLoader.LoadScene(Scene);
    }
}
