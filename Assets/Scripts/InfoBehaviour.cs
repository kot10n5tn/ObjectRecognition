using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour {

    private bool isShown = false;

    public Vector3 from;
    public Vector3 to;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void show() {
        isShown = !isShown;
        if (isShown) {
            var hash = iTween.Hash("islocal", true);
            hash.Add("x", to.x);
            hash.Add("y", to.y);
            hash.Add("z", to.z);
            hash.Add("time", 0.2f);
            iTween.MoveTo(this.gameObject, hash);
            iTween.ScaleTo(this.gameObject, new Vector3(1f, 1f, 0.01f), 0.4f);
        } else {
            var hash = iTween.Hash("islocal", true);
            hash.Add("x", from.x);
            hash.Add("y", from.y);
            hash.Add("z", from.z);
            hash.Add("time", 0.2f);
            iTween.MoveTo(this.gameObject, hash);
            iTween.ScaleTo(this.gameObject, new Vector3(0f, 0f, 0f), 0.4f);
        }
    }
}
