using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public List<GameObject> Rocks;
    public int Count;
    public Vector2 XArea;
    public Vector2 ZArea;

    private void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject rock = Instantiate(Rocks[Random.Range(0, Rocks.Count)]);
            rock.transform.position = new Vector3(Random.Range(XArea.x, XArea.y), rock.transform.position.y, Random.Range(ZArea.x, ZArea.y));
        }
    }
}
