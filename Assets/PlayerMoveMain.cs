using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMain : MonoBehaviour
{

    InputActions input;

    private void Awake()
    {
        input = new InputActions();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    //Yoinked from here https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

    //did change things

    private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 5.0f;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;

        private void Start()
        {
            controller = gameObject.AddComponent<CharacterController>();
        }

        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(input.Player.Move.ReadValue<Vector2>().x, 0, input.Player.Move.ReadValue<Vector2>().y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (input.Player.Jump.ReadValue<float>() > 0 && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }



}
