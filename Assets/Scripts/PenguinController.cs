using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinController : AnimalController
{
    [Header("Penguin")]
    public Vector2 LockInterval;
    public float MovingAwayStrength;
    public float ModifierRate;
    public float ModifierStrength;
    private float count;
    private float modifier;
    private bool locked;
    protected override void Update()
    {
        base.Update();
        count -= Time.deltaTime;
        if (count >= 0)
        {
            count += Random.Range(LockInterval.x, LockInterval.y);
            locked = !locked;
        }
        if (!locked)
        {
            modifier += Time.deltaTime * ModifierRate;
            if (modifier >= 1)
            {
                modifier -= 2;
            }
        }
    }
    protected override void MoveAction(float speedValue)
    {
        base.MoveAction(speedValue);
        RotateAction((Mathf.Sin(Time.time) * MovingAwayStrength + Mathf.Cos(modifier * Mathf.PI) * ModifierStrength) * Time.deltaTime);
    }
}
