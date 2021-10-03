using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OstrichController : AnimalController
{
    [Header("Ostrich")]
    public Vector2 SpeedChangeWaitTime;
    public Vector2 SpeedChangeValues;
    public Vector2 RotChangeWaitTime;
    public Vector2 RotChangeValues;
    [Header("Rotator")]
    public float RotatorRate;
    public float RotatorStrength;
    public Transform Rotator;
    private Vector3 rotatorRot;
    private float speedBase;
    private float speedCount;
    private float speedMod;
    private bool speedLocked;
    private float rotBase;
    private float rotCount;
    private float rotMod;
    private float rotModRate;
    private bool rotLocked;

    protected override void Start()
    {
        speedBase = MoveSpeed;
        rotBase = RotateSpeed;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        rotatorRot.x = Mathf.Sin(Time.time * RotatorRate) * RotatorStrength;
        Rotator.localEulerAngles = rotatorRot;
        // Speed
        speedCount -= Time.deltaTime;
        if (speedCount < 0)
        {
            speedCount += Random.Range(SpeedChangeWaitTime.x, SpeedChangeWaitTime.y);
            speedMod = Random.Range(SpeedChangeValues.x, SpeedChangeValues.y) * Mathf.Sign(speedBase - MoveSpeed);
            speedLocked = !speedLocked;
        }
        if (!speedLocked)
        {
            MoveSpeed += speedMod * Time.deltaTime;
        }
        // Rot
        rotCount -= Time.deltaTime;
        if (rotCount < 0)
        {
            rotCount += Random.Range(RotChangeWaitTime.x, RotChangeWaitTime.y);
            rotMod = Random.Range(RotChangeValues.x, RotChangeValues.y) * Mathf.Sign(rotBase - RotateSpeed);
            rotLocked = !rotLocked;
        }
        if (!rotLocked)
        {
            RotateSpeed += rotMod * Time.deltaTime;
        }
    }

    protected override void RotateAction(float rotateValue)
    {
        base.RotateAction(rotateValue);
    }

    protected override void MoveAction(float speedValue)
    {
        Vector3 workingVelocity;
        workingVelocity = Quaternion.Euler(0, rotatorRot.x, 0) * -transform.right * speedValue;
        workingVelocity.y = Rigidbody.velocity.y;
        Rigidbody.velocity = workingVelocity;
    }
}
