using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableBehaviour : MonoBehaviour {

    public InfoBehaviour info;

    private void Start() {

    }

    private void Update() {

    }

    public void onTapped() {
        info.show();
    }
}
