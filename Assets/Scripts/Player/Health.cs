using UnityEngine;
using TMPro;
using Photon.Pun;

public class Health : MonoBehaviourPun
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private TMP_Text healthText;

    public bool IsDead =  false;

    private void Start()
    {
        Initialize();
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        if (photonView.IsMine)
        {
            float newHealth = currentHealth - damage;
            photonView.RPC("ApplyDamage", RpcTarget.All, newHealth);
        }
    }

    [PunRPC]
    private void ApplyDamage(float newHealth)
    {
        currentHealth = newHealth;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            photonView.RPC("Die", RpcTarget.All);
            IsDead = true;
        }
    }

    private void Initialize()
    {
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<TMP_Text>();
    }

    private void UpdateHealthText()
    {
        if (photonView.IsMine)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    [PunRPC]
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    [PunRPC]
    public void Die()
    {
        IsDead = true;
        if (photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject); 
        }
    }
}
