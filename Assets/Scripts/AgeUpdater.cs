using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Months
{
	January = 1,
	February = 2,
	March = 3,
	April = 4,
	May = 5,
	June = 6,
	July = 7,
	August = 8,
	September = 9,
	October = 10,
	November = 11,
	December = 12
}

public class AgeUpdater : MonoBehaviour
{
	[Header ("The amount of Time in a Month")]
	public float monthTime;

	[Header ("Percent Of Fish that Die Naturally")]
	public Vector2 PercentageKilledPerMonth;

	[Header ("Percent Of Fish that are Fished")]
	public Vector2 PercentageFishedPerMonth;

	public Collider2D[] mpas;
	public Text MonthText;
	public Text fishCountText;
	public Text yearText;
	public Text caughtText;

	private Months month;
	private int year = 1;
	private int caught = 0;

	void Start ()
	{
		month = (Months)Random.Range (1, 12);
		Debug.Log ("Starting Month " + month);
		StartCoroutine (Loop ());
		StartCoroutine (CountLoop ());
	}

	private IEnumerator CountLoop ()
	{
		while (true) {
			fishCountText.text = "Fish: " + transform.childCount;
			caughtText.text = "Caught: " + caught;
			yearText.text = year + "";
			yield return null;
		}
	}


	private IEnumerator Loop ()
	{
		while (true) {
			yield return new WaitForSeconds (monthTime);
			NaturalKill ();
			FisherKill ();
			UpdateAges ();
			if (month == Months.January) {
				for (int i = 0; i < transform.childCount; i++) {
					Fish fish = transform.GetChild (i).GetComponent<Fish> ();
					fish.SpawnLoop ();
				}
			}

			if (month == Months.December) {
				month = Months.January;
				year++;
			} else {
				int monthDate = (int)month;
				monthDate++;
				month = (Months)monthDate;
			}
			MonthText.text = month + "";
		}
	}

	private void FisherKill ()
	{
		float percent = Random.Range (PercentageKilledPerMonth.x, PercentageKilledPerMonth.y);
		percent *= .01f;
		percent *= transform.childCount;
		for (int i = 0; i < percent; i++) {
			Kill ();
		}
	}

	private void Kill ()
	{
		GameObject temp = transform.GetChild (Random.Range (0, transform.childCount)).gameObject;
		foreach (Collider2D cd in mpas) {
			if (cd.bounds.Contains (temp.transform.position)) {
				return;
			}
		}
		caught++;
		Destroy (temp);
	}

	private void NaturalKill ()
	{
		float percent = Random.Range (PercentageKilledPerMonth.x, PercentageKilledPerMonth.y);
		percent *= .01f;
		percent *= transform.childCount;
		for (int i = 0; i < percent; i++) {
			Destroy (transform.GetChild (Random.Range (0, transform.childCount)).gameObject);
		}
	}

	private void UpdateAges ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			Fish fish = transform.GetChild (i).GetComponent<Fish> ();
			fish.updateAge (.08f);
		}
	}
}