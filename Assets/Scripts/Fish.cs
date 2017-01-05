using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{

	public GameObject egg;
	public GameObject eggParent;
	public GameObject BoundingBox;
	public Vector2 speed;
	public Vector2 startingAge;
	public Vector2 spawnTime;
	public int maxAge;

	private GameObject background;
	private float curSpeed;
	private float age = 0;
	private Vector2 curPoint;

	void Start ()
	{
		background = GameObject.FindGameObjectWithTag ("Background");
		BoundingBox = background;
		updateSpeed ();
		curPoint = getPoint ();
	}

	void FixedUpdate ()
	{
		MoveToPoint ();
		updateSpeed ();
	}

	public void randomizeAge ()
	{
		age = Random.Range (startingAge.x, startingAge.y);
	}


	public void updateAge (float age)
	{
		this.age += age;
		if (this.age >= maxAge)
			Destroy (gameObject);
	}

	private void MoveToPoint ()
	{
		transform.position = Vector2.MoveTowards (transform.position, curPoint, curSpeed);

		//Approximately at point
		if (Mathf.Approximately (transform.position.x, curPoint.x) && Mathf.Approximately (transform.position.y, curPoint.y))
			curPoint = getPoint ();
	}


	private void updateSpeed ()
	{
		curSpeed = Random.Range (speed.x, speed.y);

	}

	private Vector2 getPoint ()
	{
		Vector2 point = new Vector2 (Random.insideUnitCircle.x + transform.position.x, Random.insideUnitCircle.y + transform.position.y);
		if (BoundingBox.GetComponent<Collider2D> ().bounds.Contains (point))
			return point;
		else
			return getPoint ();
	}

	public void SpawnLoop ()
	{
		
		StartCoroutine (SpawnWait ());
	}

	private IEnumerator SpawnWait ()
	{
		yield return new WaitForSeconds (0);
		Spawn ();
	}

	private void Spawn ()
	{
		//Model Male and Female
		if (Random.Range (1, 3) == 1)
			return;
		//Model Juvenile Age
		if (age < 2)
			return;
		GameObject obj = Instantiate (egg, transform.position, egg.transform.rotation) as GameObject;
		obj.transform.parent = GameObject.FindGameObjectWithTag ("Egg").transform;
	}
}
