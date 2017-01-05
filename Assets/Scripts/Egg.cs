using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{

	public float hatchTime;
	public Vector2 KGrowth;
	public Vector2 RGrowth;
	public GameObject fish;
	public GameObject fishParent;

	void Start ()
	{
		StartCoroutine (Loop ());
	}

	private IEnumerator Loop ()
	{
		yield return new WaitForSeconds (hatchTime);
		bool isInArea = transform.parent.GetComponent<EggParent> ().isInArea (transform.position);
		int amount;
		if (isInArea) {
			amount = Random.Range ((int)RGrowth.x, (int)RGrowth.y);
		} else {
			amount = Random.Range ((int)KGrowth.x, (int)KGrowth.y);
		}
		for (int i = 0; i < amount; i++) {
			GameObject obj = Instantiate (fish, transform.position, fish.transform.rotation) as GameObject;
			obj.transform.parent = GameObject.FindGameObjectWithTag ("Fish").transform;
		}
		Destroy (gameObject);
	}

}
