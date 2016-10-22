﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool move = true;//動かせるか
	private bool moving = false;//動作中か
	private bool isOpen = false;//開いているか
	private float oldPos = 0;

	private float doorSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (moving && move) {
			if (isOpen) {//開いているなら
				if (oldPos- transform.position.x <= 1.65f) {
					transform.position -= new Vector3 (1.5f, 0f, 0f) * Time.deltaTime;
				} else {//開 完了
					isOpen = false;
					moving = false;
				}
			} else {//閉じてれば
				if (transform.position.x - oldPos <= 1.65f) {
					transform.position += new Vector3 (1.5f, 0f, 0f) * Time.deltaTime;
				} else {//閉 完了
					isOpen = true;
					moving = false;
				}
			}
		}
	}

	public bool Open(){
		if (move) {
			if (!moving) {//動作中でなければ
				oldPos = transform.position.x;
				moving = true;
			}
			return true;
		}else{
			return false;
		}
	}
}
