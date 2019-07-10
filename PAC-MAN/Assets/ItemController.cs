using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            if (this.gameObject.tag == "PowerCookie") {
                Debug.Log("Power");
                //プレイヤー強化＆敵逃げる　コルーチン使えば多分おけ
            }

            if (this.gameObject.tag == "Cookie") {
                //得点アップ。UIにお知らせする
                Debug.Log("Cookie");
            }
            Destroy(this.gameObject);
        }
    }
}
