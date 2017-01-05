using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public int count;
	public Collider2D BoundingBox;
	public GameObject toSpawn;
	public GameObject parent;

	void Start ()
	{
		for (int i = 0; i < count; i++) {
			Vector2 pos = getPoint ();
			Vector3 ac = new Vector3 (pos.x, pos.y);
			GameObject obj = Instantiate (toSpawn, ac, toSpawn.transform.rotation) as GameObject;
			obj.GetComponent<Fish> ().randomizeAge ();
			obj.transform.parent = parent.transform;
		}
	}

	private Vector2 getPoint ()
	{
		return new Vector2 (Random.Range (BoundingBox.bounds.min.x, BoundingBox.bounds.max.x), Random.Range (BoundingBox.bounds.min.y, BoundingBox.bounds.max.y));
	}
}
