using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtLeader : MonoBehaviour {
    GameObject GB;

	// Update is called once per frame
	void Update () {
        GB = GameObject.FindGameObjectWithTag("leader");
        if(GB != null)
        {
            transform.LookAt(GB.transform);
        }
       
    }
}
