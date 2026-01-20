using System.Collections;
using UnityEngine;

public class DashUnlockUI : MonoBehaviour
{
    public GameObject dashText;
    public DashUnlockUI dashUI; 

    public void ShowDashUnlocked()
    {
        dashText.SetActive(true);
        StartCoroutine(HideAfterDelay());

    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        dashText.SetActive(false);  
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
