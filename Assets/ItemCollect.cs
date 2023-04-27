using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    public delegate void CollectGold(int Gold); // dinh nghia ham Delegate
    public static CollectGold collectGoldDelegate; // khai bao ham Delegate
    private int Gold = 0;

    private void Start()
    {
        if (GameManager.HasInstance)
        {
            Gold = GameManager.Instance.Goldd;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_COLLECT_GOLD);
            }
            Destroy(collision.gameObject);
            Gold++;
            GameManager.Instance.UpdateGold(Gold);

            Debug.Log(Gold);
            collectGoldDelegate(Gold); // dung ham` Delegate
        }
    }
}
