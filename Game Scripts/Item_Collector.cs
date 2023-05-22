using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Collector : MonoBehaviour
{
    int apples = 0;
    [SerializeField] private Text appleText;
    [SerializeField] private AudioSource collectionSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            apples = apples + 1;
            appleText.text = "Apples :" + apples;

        }
    }
}
