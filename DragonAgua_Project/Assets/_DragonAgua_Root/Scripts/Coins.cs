using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(2);
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
        }

    }







}
