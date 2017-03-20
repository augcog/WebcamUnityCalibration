using UnityEngine;
using System;

namespace StereoCameraSave
{
	/**
	 * A class that stores the relevant information of a StereoCamera such that it can
	 * serialized and saved into a file for future reference
	 **/
	[Serializable] public class StereoCameraSaveData
	{
		public EyeSaveData[] eyeList = new EyeSaveData[2];
		
		public StereoCameraSaveData (StereoCamera camera) {
			foreach (Eye childEye in camera.eyeList) {
				eyeList [(int) childEye.eye] = new EyeSaveData(childEye);
			}
		}
	}
	
	
	[Serializable] public class EyeSaveData {
		public SerMatrix4x4 projMatrix;
		public SerVector3 localPosition;
		public SerQuaternion localRotation;
		
		public EyeSaveData (Eye eye) {
			projMatrix = new SerMatrix4x4(eye.GetProjectionMatrix());
			localPosition = new SerVector3(eye.transform.localPosition);
			localRotation = new SerQuaternion(eye.transform.localRotation);
		}
	}
	
	
	// Helper classes because for some reason Unity doesn't define their data structures as serializable...
	
	[Serializable] public class SerVector3 {
		
		public float x;
		public float y;
		public float z;
		
		public SerVector3 (Vector3 vect) {
			SetVector3(vect);
		}
		
		public void SetVector3 (Vector3 vect) {
			x = vect.x;
			y = vect.y;
			z = vect.z;
		}
		
		public Vector3 GetVector3() {
			return new Vector3(x, y, z);
		}
	}
	
	[Serializable] public class SerQuaternion {
		
		public float x;
		public float y;
		public float z;
		public float w;
		
		public SerQuaternion (Quaternion quat) {
			SetQuaternion(quat);
		}
		
		public void SetQuaternion (Quaternion quat) {
			x = quat.x;
			y = quat.y;
			z = quat.z;
			w = quat.w;
		}
		
		public Quaternion GetQuaternion() {
			return new Quaternion(x, y, z, w);
		}
	}
	
	[Serializable] public class SerMatrix4x4 {
		
		public float[,] matrix = new float[4,4];
		
		public SerMatrix4x4 (Matrix4x4 mat) {
			SetMatrix4x4 (mat);
		}
		
		public void SetMatrix4x4 (Matrix4x4 mat) {
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					matrix[i,j] = mat[i,j];
				}
			}
		}
		
		public Matrix4x4 GetMatrix4x4() {
			Matrix4x4 newMat = new Matrix4x4();
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					newMat[i,j] = matrix[i,j];
				}
			}
			return newMat;
		}
	}
}