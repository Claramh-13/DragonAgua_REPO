using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform RespawnPoint;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps"))
        {
            transform.position = RespawnPoint.position;
        }

    }
   
}
