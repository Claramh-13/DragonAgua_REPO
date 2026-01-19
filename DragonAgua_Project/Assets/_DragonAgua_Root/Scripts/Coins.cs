using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<GameManager>().AddCoin();
            Destroy(gameObject);
        }

    }







}
