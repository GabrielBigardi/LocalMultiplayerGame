using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Image healthBar;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int damageToTake)
    {
        curHealth -= damageToTake;
        if (curHealth <= 0)
        {
            curHealth = 0;
            Die();
        }

        healthBar.fillAmount = (float)curHealth / maxHealth;
    }

    public void Heal(int healAmount)
    {
        curHealth += healAmount;
        if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }

        healthBar.fillAmount = (float)curHealth / maxHealth;
    }

    public void Die()
    {
        var teamId = GetComponent<PlayerEntity>().currentTeam;
        if(ScoreManager.Instance != null) ScoreManager.Instance.AddScore(teamId, 1);

        transform.position = new Vector3(-6.16f, -3.5f, 0f);
        Heal(maxHealth);
    }
}
