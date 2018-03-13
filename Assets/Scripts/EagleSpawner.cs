using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

    GameObject leader;
    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;
    public GameObject seekTarget;

	void Start () {
        GameObject[] boids = new GameObject[7];

		for(int i = 0; i < 7; i++)
        {
            boids[i] = GameObject.Instantiate(prefab);
            boids[i].transform.rotation = transform.rotation;
            if(i != 0)
            {
                boids[i].AddComponent<OffsetPursue>();
            }
            else
            {
                boids[i].transform.localPosition = transform.localPosition;
                boids[i].AddComponent<Seek>();
                boids[i].GetComponent<Seek>().targetGOBJ = seekTarget;
            }
        }     
        boids[1].GetComponent<OffsetPursue>().leader = boids[0].GetComponent<Boid>();
        boids[1].transform.localPosition = transform.localPosition + new Vector3(gap, 0, gap);
        boids[2].GetComponent<OffsetPursue>().leader = boids[0].GetComponent<Boid>();
        boids[2].transform.localPosition = transform.localPosition + new Vector3(gap, 0, -gap);

        boids[3].GetComponent<OffsetPursue>().leader = boids[1].GetComponent<Boid>();
        boids[3].transform.localPosition = boids[1].transform.localPosition + new Vector3(gap, 0, gap);
        boids[4].GetComponent<OffsetPursue>().leader = boids[1].GetComponent<Boid>();
        boids[4].transform.localPosition = boids[1].transform.localPosition + new Vector3(gap, 0, -gap);

        boids[5].GetComponent<OffsetPursue>().leader = boids[1].GetComponent<Boid>();
        boids[5].transform.localPosition = boids[2].transform.localPosition + new Vector3(gap, 0, gap);
        boids[6].GetComponent<OffsetPursue>().leader = boids[1].GetComponent<Boid>();
        boids[6].transform.localPosition = boids[2].transform.localPosition + new Vector3(gap, 0, -gap);
    }
}
