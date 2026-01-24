using UnityEngine;

public class DragonBattleTrigger : MonoBehaviour
{
    public GameObject dragon;   // arrastras el dragón aquí
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            // Activar el dragón
            dragon.SetActive(true);

            // Lanzar animación
            Animator anim = dragon.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Emerger");
            }
        }
    }
}
