using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {
    GameObject leader;
    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;
    OffsetPursue op;

    Vector3 offsetLeft = new Vector3(40, 0, 20);
    Vector3 offsetRight = new Vector3(40, 0, -20);
    public GameObject seekTarget;
    public float SpawnTime = 3f;
    int waveCount = 1;

    List<GameObject> boids = new List<GameObject>();
    // Use this for initialization
    void Awake () {
        leader = GameObject.Instantiate(prefab);
        leader.tag = "leader";
        prefab.transform.position = this.transform.position;
        Seek seek = leader.AddComponent<Seek>();
        seek.targetGOBJ = seekTarget;
        boids.Add(leader);
        StartCoroutine(Wave(waveCount));
    }
	

    IEnumerator Wave(int count)
    {
        GameObject boid = GameObject.Instantiate(prefab);
        op = boid.AddComponent<OffsetPursue>();
        op.leader = leader.GetComponent<Boid>();
        Vector3 leaderPos = leader.transform.position;
        boid.transform.position = leaderPos + offsetLeft;
        boids.Add(boid);
    
        GameObject boid2 = GameObject.Instantiate(prefab);
        op = boid2.AddComponent<OffsetPursue>();
        op.leader = leader.GetComponent<Boid>();
        boid2.transform.position = leaderPos + offsetRight;
        boids.Add(boid2);
        yield return new WaitForSeconds(SpawnTime);

    }
	// Update is called once per frame
	void Update () {
		
	}
}
