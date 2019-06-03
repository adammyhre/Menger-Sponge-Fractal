using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour {

	public GameObject prefab;
	List<GameObject> sponge = new List<GameObject> ();
	public float size = 5f;

	void Start () {
		GameObject box = Instantiate(prefab, Vector3.zero, Quaternion.identity);
		box.transform.parent = gameObject.transform;
		box.transform.localScale = new Vector3 (size, size, size);
		box.GetComponent<Box>().size = size;
		sponge.Add (box);
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			List<GameObject> newSponge = Split(sponge);

			foreach (var cube in sponge) {
				Destroy (cube);
			}

			sponge = newSponge;
		}
	}

	List<GameObject> Split(List<GameObject> cubes) {
		
		List<GameObject> subCubes = new List<GameObject> ();

		foreach (var cube in cubes) {
			float size = cube.GetComponent<Box> ().size;
			float newSize = size / 3f;

			Debug.Log (cube.transform.position);
			for (int x = -1; x < 2; x++) {
				for (int y = -1; y < 2; y++) {	
					for (int z = -1; z < 2; z++) {


						Vector3 position = new Vector3 (x * newSize, y * newSize, z * newSize) + cube.transform.localPosition;
						var sum = Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z);
						Debug.Log (position);
						if (sum > 1) {

							GameObject copy = Instantiate (cube, position, Quaternion.identity);
							copy.GetComponent<Box> ().size = newSize;
							copy.transform.localScale = new Vector3 (newSize, newSize, newSize);
							copy.transform.parent = gameObject.transform;

							subCubes.Add (copy);
						}
					}
				}
			}
		}

		return subCubes;
	}
}
