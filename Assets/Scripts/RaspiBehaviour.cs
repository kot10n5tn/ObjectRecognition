﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspiBehaviour : MonoBehaviour {

    public bool isMain = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void showAnimation(float waitTime = 0f) {
        Invoke("move", waitTime);
    }

    void move() {
        var hash = iTween.Hash("islocal", true);
        hash.Add("x", 0.071f);
        hash.Add("y", 0.003f);
        hash.Add("z", 0.049f);
        hash.Add("time", 1f);
        iTween.MoveFrom(this.gameObject, hash);
        iTween.ScaleTo(this.gameObject, new Vector3(0.102f, 0.102f, 0.102f), 0.5f);

        Invoke("hideAnimation", 2.0f);
    }

    void hideAnimation() {
        var hash = iTween.Hash("islocal", true);
        hash.Add("x", 0.071f);
        hash.Add("y", 0.003f);
        hash.Add("z", 0.049f);
        hash.Add("time", 1f);
        iTween.MoveTo(this.gameObject, hash);

        if (isMain) {
            Invoke("expand", 1.2f);
        } else {
            Invoke("setDeactive", 0.6f);
        }
    }

    void expand() {
        iTween.ScaleBy(this.gameObject, new Vector3(2.0f, 2.0f, 2.0f), 0.4f);
        Invoke("explode", 0.6f);
    }

    void explode() {
        iTween.PunchScale(this.gameObject, new Vector3(0.25f, 0.25f, 0.25f), 0.6f);
        foreach (var _transform in gameObject.GetComponentsInChildren<Transform>()) {
            Debug.Log(_transform.name);
            var particle = _transform.GetComponentInChildren<ParticleSystem>();
            particle.Play();
        }
    }

    void setDeactive() {
        this.gameObject.SetActive(false);
    }
}