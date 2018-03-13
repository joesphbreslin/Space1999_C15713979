using UnityEngine;

public abstract class SteeringBehaviours : MonoBehaviour {

    public Vector3 force;

    [HideInInspector]
    public Boid boid;

	void Awake () {
        boid = GetComponent<Boid>();
	}

    public abstract Vector3 Calculate();
}
