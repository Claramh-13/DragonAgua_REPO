using UnityEngine;
using UnityEngine.UI;   

public class HealthUi : MonoBehaviour
{
    [SerializeField] Image healthFill;

    void Update()
    {
       healthFill.fillAmount = GameManager.Instance.playerHealth / GameManager.Instance.maxHealth;   
    }

}
