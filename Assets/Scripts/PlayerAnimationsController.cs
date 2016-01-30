﻿using UnityEngine;
using System.Collections;

public class PlayerAnimationsController : MonoBehaviour {
    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}

    public void Walk() {
        animator.Play("Walk");
    }

    public void Idle() {
        animator.Play("Idle");
    }
}