using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class checkerboardMovement : MonoBehaviour {
	
	public GameObject recordIndicator;
	public GameObject[] corners;
	public Vector3[] dest;
	public int movingSpeed;

	private int tracker;
	private bool record;
	private bool[] ifRecorded;

	void Start () {
		tracker = 0;
		ifRecorded = new bool[dest.Length];
		for (int i = 0; i < ifRecorded.Length; i++) {
			ifRecorded[i] = false;
		}
		record = false;
		recordIndicator.SetActive(record);
	}

	bool atLocation() { // Only record when the marker arrives at the destinated location
		return (Math.Abs(transform.position.x - dest [tracker].x) < 0.1f && Math.Abs(transform.position.y - dest [tracker].y) < 0.1f && Math.Abs(transform.position.z - dest [tracker].z) < 0.1f);
	}

	void Update () {
		if (tracker < dest.Length) {
			if (Input.GetKey ("space") && atLocation ()) {
				record = true;
				ifRecorded [tracker] = true;
			}
			if (Input.GetKeyUp ("space") && ifRecorded [tracker]) {
				if (record) {
					tracker = tracker + 1;
				}
				record = false;
			}
			float step = Time.deltaTime * movingSpeed;

			transform.position = Vector3.MoveTowards (transform.position, dest [tracker], step);

			recordIndicator.SetActive (record);
			// If record is true, send the last digit of UDP send array to be true
			print (Input.GetKey ("space"));
		}

	}
}
