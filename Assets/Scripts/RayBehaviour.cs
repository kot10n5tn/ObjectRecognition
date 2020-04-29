using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBehaviour : MonoBehaviour {
    RaycastHit[] hits = new RaycastHit[16];

    public void Update() {
        // マウスクリック座標を取得
        if (!Input.GetMouseButtonDown(0)) {
            return;
        }
        Vector3 touchPos = Input.mousePosition;  // スクリーン座標
                                                 // スマホではこっちを使用
                                                 //Vector3 touchPos = Input.GetTouch( 0 ).position;

        // カメラを原点としたスクリーン座標へのレイ
        Ray ray = Camera.main.ScreenPointToRay(touchPos);

        // レイとのコライダーの当たり判定
        int hitNum = Physics.RaycastNonAlloc(ray, this.hits);
        if (hitNum > 0) {
            // カメラに近い順に並べ替える
            System.Array.Sort(this.hits, 0, hitNum, new RayDistanceCompare());

            // 先頭に来たオブジェクトが最もカメラに近い
            Debug.Log(this.hits[0].transform.name);

            this.hits[0].transform.gameObject.GetComponent<TouchableBehaviour>().onTapped();
        }
    }

    public class RayDistanceCompare : IComparer<RaycastHit> {
        public int Compare(RaycastHit x, RaycastHit y) {
            if (x.distance < y.distance) {
                return -1;
            }
            if (x.distance > y.distance) {
                return 1;
            }
            return 0;
        }
    }
}
