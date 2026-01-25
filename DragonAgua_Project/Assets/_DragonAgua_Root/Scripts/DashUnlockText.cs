using System.Collections;
using UnityEngine;

public class DashUnlockText : MonoBehaviour
{
    [Header("DASH UNLOKED, Press shift or RT to Dash")]
    public GameObject text1;
    public GameObject text2;

    public float displayTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (text1 != null) text1.SetActive(false);
        if (text2 != null) text2.SetActive(false);   
    }

    public void Showtexts()
    {
        if (text1 != null) text1.SetActive(true);
        if (text2 != null) text2.SetActive(true);

        StartCoroutine(HideTexts());

    }

    IEnumerator HideTexts()
    {
        yield return new WaitForSeconds(displayTime);

        if (text1 != null) text1.SetActive(false);
        if (text2 != null) text2.SetActive(false);


    }


    

}
