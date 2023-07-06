using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ネームスペースの設定
namespace BODY{
	public class BodyController : MonoBehaviour {

		[Range(0.1f, 10f)]
		public float lookSensitivity = 5f;
		[Range(0.1f, 1f)]
		public float lookSmooth = 0.1f;

		private float yRot;

		private float currentYRot;

		private float yRotVelocity;

		void Update () {
			yRot += Input.GetAxis ("Mouse X") * lookSensitivity;  // マウスの横移動

			currentYRot = Mathf.SmoothDamp (currentYRot, yRot, ref yRotVelocity, lookSmooth);

			transform.rotation = Quaternion.Euler (-90, currentYRot, 0);
		}
	}
}