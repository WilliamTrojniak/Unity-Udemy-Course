using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(selfDestruct());
	}
	
	private IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


}
