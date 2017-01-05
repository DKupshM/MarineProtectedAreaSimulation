using UnityEngine;
using System.Collections;

public class EggParent : MonoBehaviour
{

	public Collider2D[] kAreas;

	public bool isInArea (Vector3 pos)
	{
		foreach (Collider2D c in kAreas) {
			if (c.bounds.Contains (pos))
				return true;
		}
		return false;
	}
}
