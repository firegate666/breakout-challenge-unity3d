using UnityEngine;

namespace de.firegate.breakout
{
	public class Bottom : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			Ball ball = collision.gameObject.GetComponent<Ball>();

			if ( ball != null ) GameManager.Instance.GameOver();
		}
	}
}
