using System.Collections;
using UnityEngine;
using TMPro;
public class Communication : MonoBehaviour
{

    public static Communication _instance;
    [SerializeField] private GameObject communicationTextPanel;
    [SerializeField] private TextMeshProUGUI communicationText;
    

    private void Awake()
    {
        _instance = this;
        communicationTextPanel.SetActive(false);
    }

    public void ShowText(string text,float hideTime)
    {
        communicationTextPanel.SetActive(true);
        communicationText.SetText(text);
        StartCoroutine(WaitAndHide(hideTime));
    }
    IEnumerator WaitAndHide(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        communicationTextPanel.SetActive(false);
    }
}
