using NUnit.Framework;

public class HealthTest
{
	// A Test behaves as an ordinary method
	[Test]
	public void HealthIsDecreasedAndDetectedDeadProperly()
	{
		Health health = new(10);
		Assert.AreEqual(10, health._health);

		health.ApplyModification(-4);
		Assert.AreEqual(6, health._health);
		Assert.False(health.IsDead());

		health.ApplyModification(-6);
		Assert.AreEqual(0, health._health);
		Assert.True(health.IsDead());
	}
}
