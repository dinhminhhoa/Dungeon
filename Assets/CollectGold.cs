using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectGold : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI numberOfGold;
    private int Gold = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            Gold++;
            numberOfGold.SetText(Gold.ToString());
            Debug.Log(Gold);
        }
    }
}
