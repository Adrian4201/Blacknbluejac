using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    //for player and dealer
    public Health health;        
    
    public Image fillImage;        

    void Update()
    {
        fillImage.fillAmount = (float)health.currentHealth / health.maxHealth;
    }
}
