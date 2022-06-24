public class Health
{
	public int _health { get; private set; }

	public Health(int health)
	{
		_health = health;
	}

	public void ApplyModification(int healthModification)
	{
		_health += healthModification;
	}

	public bool IsDead()
	{
		return _health <= 0;
	}
}
