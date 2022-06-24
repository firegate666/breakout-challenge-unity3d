using UnityEngine;

namespace de.firegate.breakout
{
	public class Ball : MonoBehaviour
	{
		public float Speed = 5.0f;

		public void Accelarate()
		{
			float x = Random.Range(0, 2) == 0 ? -1 : 1;
			float y = Random.Range(0, 2) == 0 ? -1 : 1;

			GetComponent<Rigidbody>().velocity = new Vector3(Speed * x, Speed * y, 0.0f);
		}
	}
}
