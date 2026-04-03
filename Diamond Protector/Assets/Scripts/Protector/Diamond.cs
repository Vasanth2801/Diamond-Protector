using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 200;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = (float)currentHealth/maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth > 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }

}
