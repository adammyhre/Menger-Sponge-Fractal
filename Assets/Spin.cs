using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	float spinValue = 90f;

	void Start () {
		
	}
	
	void Update () {
		transform.Rotate (Vector3.up * spinValue * Time.deltaTime);
	}
}
