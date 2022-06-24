using UnityEngine;

namespace de.firegate.breakout
{
	public class Brick : MonoBehaviour
	{
		public Health Health = new(3);

		private Renderer _renderer;

		private void Start()
		{
			_renderer = GetComponent<Renderer>();
		}

		private void OnCollisionEnter(Collision collision)
		{
			Ball ball = collision.gameObject.GetComponent<Ball>();

			if ( ball != null )
			{
				Health.ApplyModification(-1);

				Color c = _renderer.material.color;
				c.a /= 2.0f;
				_renderer.material.color = c;

				if ( Health.IsDead() )
				{
					Destroy(gameObject);
					GameManager.Instance.BrickDestroyed();
				}
			}
		}
	}
}
