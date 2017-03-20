using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Eye : MonoBehaviour {
	public StereoCamera.eyeType eye;
	
	private Camera _my_camera;
	
	// Use this for initialization
	void Awake () {
		_my_camera = GetComponent<Camera> ();
	}
	
	public void SetEnabled(bool enable) {
		_my_camera.enabled = enable;
	}
	
	public bool IsEnabled() {
		return _my_camera.enabled;
	}
	
	public Matrix4x4 GetProjectionMatrix() {
		return _my_camera.projectionMatrix;
	}
	
	public void SetProjectionMatrix (Matrix4x4 m) {
		_my_camera.projectionMatrix = m;
	}
}
