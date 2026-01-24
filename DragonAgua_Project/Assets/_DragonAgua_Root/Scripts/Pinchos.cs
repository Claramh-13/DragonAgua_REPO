using UnityEngine;

public class Traps : MonoBehaviour
{
    public Transform respawnPoint;
    private bool respawning = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (respawning) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            respawning = true;

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            rb.position = respawnPoint.position;

            Invoke(nameof(ResetRespawn), 0.2f);
        }
    }

    void ResetRespawn()
    {
        respawning = false;
    }
}
