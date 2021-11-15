using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterErrorButton : MonoBehaviour
{
    public GameObject ErrorUI;
    public float TimeToShow = 2f;
    public GameObject Computer;
    public bool ActivateAnim = true;
    // Start is called before the first frame update

    public void ClickEnterError()
    {
        FindObjectOfType<AudioManager>().Play("Error");
        StartCoroutine(ShowErrorUI());
        ActivateAnim = true;
    }
    private void Update()
    {

    }

    IEnumerator ShowErrorUI() {
        ErrorUI.SetActive(true);
        yield return new WaitForSecondsRealtime(TimeToShow);
        ErrorUI.SetActive(false);
        ActivateAnim = false;
    }
}
