using UnityEngine;

namespace Game.PlayerControllers
{


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _moveSpeed;

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            float moveDirectionX = Input.GetAxisRaw("Horizontal");
            float moveDirectionY = Input.GetAxisRaw("Vertical");
            _rigidBody.velocity = new Vector2(moveDirectionX * _moveSpeed, moveDirectionY * _moveSpeed);
        }
    }
}