using UnityEngine;

namespace Game.Duks
{
    public class DuckMove : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _deadZoneStart;
        [SerializeField] private float _deadZoneFinish;
        [SerializeField] private float _direction;
        [SerializeField] private GameObject _duck;

        private float _startSpeed;

        private void Awake()
        {
            _startSpeed = Random.Range(_minSpeed, _maxSpeed);
        }

        void Update()
        {
            transform.position = transform.position + (new Vector3(_direction, 0f, 0f) * _startSpeed * Time.deltaTime);

            if (transform.position.x > _deadZoneFinish || transform.position.x < _deadZoneStart)
            {
                Destroy(_duck);
            }
        }

     
    }

}