using UnityEngine;

public class Seek : SteeringBehaviours {

    public GameObject targetGOBJ;
    public Vector3 target = Vector3.zero;

    public override Vector3 Calculate()
    {
        Vector3 desired = target - transform.position;
        desired = desired.normalized;
        desired *= boid.maxSpeed;
        return desired - boid.velocity;
    }
	void Update () {

		if(targetGOBJ != null)
        {
            target = targetGOBJ.transform.position;
        }
	}
}
