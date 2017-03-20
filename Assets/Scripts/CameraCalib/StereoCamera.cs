using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using StereoCameraSave;

public class StereoCamera : MonoBehaviour {
	
	public enum eyeType {LEFT, RIGHT};
	[HideInInspector] public Eye[] eyeList = new Eye[2];

	public string loadFileName;
	
	void Awake () {
		foreach (Transform child in transform) {
			Eye childEye = child.GetComponent<Eye>();
			eyeList[(int) childEye.eye] = childEye;
		}
	}

	void loadFile() {
		if (File.Exists ("C:/CS Projects/UICalibration/DepthToDisplayTransform/" + loadFileName)) {
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open ("C:/CS Projects/UICalibration/DepthToDisplayTransform/" + loadFileName, FileMode.Open);
			StereoCameraSaveData test2 = (StereoCameraSaveData) formatter.Deserialize (file);
			file.Close ();
			for (int i = 0; i < test2.eyeList.Length; i++) {
				eyeList [i].transform.localPosition = test2.eyeList [i].localPosition.GetVector3();
				eyeList [i].transform.localRotation = test2.eyeList [i].localRotation.GetQuaternion();
				eyeList [i].SetProjectionMatrix (test2.eyeList [i].projMatrix.GetMatrix4x4());
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		loadFile ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
