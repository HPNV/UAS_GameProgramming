using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI credit;

    void Start()
    {
        goldText.text = $"Gold Count: {GameManager.instance.GetGold()}";
        killText.text = $"Kill Count: {GameManager.instance.GetKill()}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleCredit()
    {
        credit.gameObject.SetActive(!credit.gameObject.activeSelf);
    }
}
