using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS{

	public enum PlayerState{
		Idle, Walking, Running, Jumping
	}

	[RequireComponent(typeof(CharacterController), typeof(AudioSource))]
	public class PlayerController : MonoBehaviour {

		[Range(0.1f, 2f)]
		public float walkSpeed = 0.8f;
		[Range(0.1f, 10f)]
		public float runSpeed = 1.5f;

		private CharacterController charaController;
		private GameObject FPSCamera;
		private Vector3 moveDir = Vector3.zero;

		[Range(0.0f, 10f)]
		public float gravity;
		[Range(1f, 15f)]
		public float jumpPower;

		[Range(0.1f, 2f)]
		public float crouchHeight;
		[Range(0.1f, 5f)]
		public float normalHeight;

		[HideInInspector]
		public PlayerState currentPlayerState;
		[HideInInspector] 
		public bool isWalking = false;
		[HideInInspector] 
		public bool isRunning = false;
		[HideInInspector] 
		public bool isCrouching = false;

		void Start () {
			FPSCamera = GameObject.Find("FPSCamera");
			charaController = GetComponent<CharacterController> ();
		}

		void Update () {
			Move ();
			Crouch();
			PlayerStateManager();
			// print(currentPlayerState);  // 現在のプレーヤーのステート（状態）を確認
		}

		void Move(){
			float moveH = Input.GetAxis ("Horizontal");
			float moveV = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (moveH, 0, moveV);

			if (movement.sqrMagnitude > 1) {
				movement.Normalize ();
			}

			Vector3 desiredMove = FPSCamera.transform.forward * movement.z + FPSCamera.transform.right * movement.x;
			moveDir.x = desiredMove.x * 5f;
			moveDir.z = desiredMove.z * 5f;

			if (ItemPicker.speedflg == 1) {
				charaController.Move (moveDir * Time.fixedDeltaTime * runSpeed);
				isWalking = false;
				isRunning = true;
			} else {
				charaController.Move (moveDir * Time.fixedDeltaTime * walkSpeed);
				isWalking = true;
				isRunning = false;
			}

			moveDir.y -= gravity * Time.deltaTime;

/* 			if(charaController.isGrounded){
				if(Input.GetKeyDown(KeyCode.Space)){
					moveDir.y = jumpPower;
				}
			} */
		}
			
		void Crouch(){
			if (Input.GetKey (KeyCode.C)) {
				charaController.height = crouchHeight;
				isCrouching = true;
			} else {
				charaController.height = normalHeight;
				isCrouching = false;
			}
		}

		// プレーヤーのステート（状態）管理
		void PlayerStateManager(){
			if (charaController.isGrounded) {
				if (charaController.velocity.sqrMagnitude < 0.01f) {
					currentPlayerState = PlayerState.Idle;  // Idle状態

				} else if (isWalking == true && isRunning == false) {
					currentPlayerState = PlayerState.Walking;  // Walking状態

				} else if (charaController.velocity.sqrMagnitude > 0.01f && isWalking == false && isRunning == true) {
					currentPlayerState = PlayerState.Running;  // Running状態
				}
			} else {
				currentPlayerState = PlayerState.Jumping;
			}
		}
	}
}