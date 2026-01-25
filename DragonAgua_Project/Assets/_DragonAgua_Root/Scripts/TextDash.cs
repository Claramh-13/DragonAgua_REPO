using UnityEngine;
using TMPro;

public class TextDash : MonoBehaviour
{
    public TMP_Text messageText;

    private void Start()
    {
        messageText.gameObject.SetActive(false);    
    }

    public void ShowdashUnlockedMessages()
    {
        StartCoroutine(ShowMessage());
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        messageText.text = "dash desbloqueado";
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        messageText.gameObject.SetActive(false);
    }
}

