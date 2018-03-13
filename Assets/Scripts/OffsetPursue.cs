using UnityEngine;

public class OffsetPursue : SteeringBehaviours
{
    public Boid leader;
    public Vector3 offset;
    public Vector3 worldTarget;
    float deceleration = .9f;
    float slowingDistance = 15f;

	void Start () {
        offset = transform.position - leader.transform.position;
        offset = Quaternion.Inverse(leader.transform.rotation) * offset;
    }	

    public Vector3 ArriveForce(Vector3 target)
    {
        Vector3 targetPos = target - transform.position;
        float distance = targetPos.magnitude;
        if(distance < 0f)
        {
            return Vector3.zero;
        }
        float ramped = boid.maxSpeed * (distance / slowingDistance * deceleration);
        float clamped = Mathf.Min(ramped, boid.maxSpeed);

        Vector3 desiredVel = clamped * (targetPos / distance);
        return desiredVel - boid.velocity;
    }

    public override Vector3 Calculate()
    {
        worldTarget = leader.transform.TransformPoint(offset);
        float dist = Vector3.Distance(worldTarget, transform.position);
        float time = dist / boid.maxSpeed;
        Vector3 targetPos = worldTarget + (leader.velocity * time);
        return ArriveForce(targetPos);
    }
}
