using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public HealthTracker dealerHealth;
    public HealthTracker playerHealth;

    private int winStreak = 0;

    public void PlayerWins()
    {
        winStreak++;

        int dmg = (winStreak >= 2) ? 20 : 10;

        dealerHealth.TakeDamage(dmg);
        Debug.Log("Player dealt " + dmg + " damage!");
    }

    public void DealerWins()
    {
        winStreak = 0;

        playerHealth.TakeDamage(10);
        Debug.Log("Dealer dealt 10 damage!");
    }

    public bool DealerDead => dealerHealth.currentHealth <= 0;
    public bool PlayerDead => playerHealth.currentHealth <= 0;
}
