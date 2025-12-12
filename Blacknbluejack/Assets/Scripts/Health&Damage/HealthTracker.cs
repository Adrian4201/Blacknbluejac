using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // UI health bar – Image must be set to "Filled" → "Radial360"
    public Image healthFill;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        UpdateBar();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        UpdateBar();
    }

    void UpdateBar()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
