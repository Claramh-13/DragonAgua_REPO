using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{
    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dragon"))
        {
            Debug.Log("HIT DRAGON");

            DragonHealth dragon = other.GetComponent<DragonHealth>();
            if (dragon != null)
            {
                dragon.TakeDamage(damage);
            }
        }
    }
}
