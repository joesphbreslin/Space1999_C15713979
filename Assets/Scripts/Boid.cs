using UnityEngine;

using System.Collections.Generic;

public class Boid : MonoBehaviour {

    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;
    public float mass = 1f;
    public float maxSpeed = 5.0f;

    List<SteeringBehaviours> behaviours = new List<SteeringBehaviours>();

	void Start () {
        SteeringBehaviours[] behaviours = GetComponents<SteeringBehaviours>();
        foreach(SteeringBehaviours b in behaviours)
        {
            this.behaviours.Add(b);
        }
	}

    Vector3 Calculate()
    {
        force = Vector3.zero;
        foreach(SteeringBehaviours b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate();
            }
        }
        return force;
    }

    void Banking()
    {
        AccelerationSmoothing();
        ApplyAccelerationToVelocity();
        ApplyLerpingAndLookAt();
    }

    void AccelerationSmoothing()
    {
        
        Vector3 tempAcc = force / mass;
        float smoothRate = Mathf.Clamp(9.0f, 0.15f, 0.4f) / 2;
        acceleration = Vector3.Lerp(acceleration, tempAcc, smoothRate);
    }
    void ApplyAccelerationToVelocity()
    {
        velocity += acceleration;  //TEST THIS MIGHT BE *
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }

    void ApplyLerpingAndLookAt()
    {
        Vector3 globalUp = new Vector3(0, .2f, 0);
        Vector3 accUp = acceleration *= 0.05f;
        Vector3 bankUp = globalUp + accUp;

        float smoothTime = Time.deltaTime * 3.0f;
        Vector3 tempUp = transform.up;
        tempUp = Vector3.Lerp(tempUp, bankUp, smoothTime);

        if(velocity.magnitude > 0.0001)
        {
            velocity *= .99f;
            transform.LookAt(transform.position, tempUp);
        }

        transform.position += velocity * Time.deltaTime;

    }


    void Update () {
        force = Calculate();
        Banking();
	}
}
