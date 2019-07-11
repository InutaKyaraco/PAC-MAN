using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstarController : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject RoomObject;//死んだら目指す場所。初期位置保存でもいい鴨

    NavMeshAgent m_navMeshAgent;

    enum Status {
        Normal = 0, Escape = 1, GoHome = 2
    };

    int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        //StartCoroutine(Chase(PlayerObject.transform.position));
        gameStatus = (int)Status.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameStatus) {
            case (int)Status.Normal:
                //通常時の敵の動き

                break;

            case (int)Status.Escape:
                //逃げてる時の敵の動き
                break;

            case (int)Status.GoHome:
                //やられて家に帰っている時の敵の動き
                break;
        }
    }

    public void ChangeGameStatus(string Status) {
        //アイテム取った時にステータスを逃げるに変える（アイテムスクリプトから呼ぶ）

    }



    IEnumerator Chase(Vector3 i_target){
        //while (Vector3.Distance(this.transform.position, i_target) > 0.01f) {
            if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {
                m_navMeshAgent.SetDestination(i_target);
            //}
            yield return null;
        }
    }

    //IEnumerator Escape(Vector3 i_target) {

    //}

    //IEnumerator GoHome(Vector3 i_target) {

    //}



}
