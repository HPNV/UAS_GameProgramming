using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddGold();
            GameManager.instance.Save();
            SoundManager.instance.PlaySFX("pickup");
            Destroy(this.gameObject);
        }
    }
}
