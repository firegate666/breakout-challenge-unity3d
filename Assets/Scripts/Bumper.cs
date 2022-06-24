using UnityEngine;

namespace de.firegate.breakout
{
	public class Bumper : MonoBehaviour
	{
		public float Speed = 5.0f;
		public float MinX = -5.0f;
		public float MaxX = 5.0f;

		private void Update()
		{
			float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
			float y = 0.0f; // Input.GetAxis("Vertical");

			transform.Translate(x, y, 0.0f);

			Vector3 ot = transform.position;
			transform.position = new Vector3(Mathf.Clamp(ot.x, MinX, MaxX), ot.y, ot.z);
		}
	}
}
