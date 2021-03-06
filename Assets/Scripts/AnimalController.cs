using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    public float RotateSpeed;
    public float MoveSpeed;
    public AdvancedAnimation WalkAnimation;
    public AdvancedAnimation IdleAnimation;
    public Vector3 Rotation;
    protected Rigidbody Rigidbody;
    protected virtual void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    protected virtual void Update()
    {
        if (Control.GetAxis(Control.Axis.X) != 0)
        {
            RotateAction(Control.GetAxis(Control.Axis.X) * RotateSpeed * Time.deltaTime);
        }
        if (Control.GetAxis(Control.Axis.Y) > 0)
        {
            MoveAction(Control.GetAxis(Control.Axis.Y) * MoveSpeed);
            WalkAnimation.Active = true;
            IdleAnimation.Active = false;
        }
        else
        {
            WalkAnimation.Active = false;
            IdleAnimation.Active = true;
        }
    }
    protected virtual void LateUpdate()
    {
        transform.localEulerAngles = Rotation;
    }
    protected virtual void RotateAction(float rotateValue)
    {
        Rotation.y += rotateValue;
    }
    protected virtual void MoveAction(float speedValue)
    {
        Vector3 workingVelocity;
        workingVelocity = -transform.right * speedValue;
        workingVelocity.y = Rigidbody.velocity.y;
        Rigidbody.velocity = workingVelocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            StateController.Lose();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            StateController.Lose();
        }
    }
}
