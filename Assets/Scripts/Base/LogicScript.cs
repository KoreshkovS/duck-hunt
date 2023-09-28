using System.Collections;
using Game.Duks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Base
{
    public interface IDamagable
    {
        public void Hit();
        
    }

    public class LogicScript : MonoBehaviour
    {
        [SerializeField] private int _playerScore;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _timeText;
        [SerializeField] private float _endGameTime;
        [SerializeField] private int _bulletsMagazine = 7;
        [SerializeField] private Text _bulletsText;
        [SerializeField] private float _coolDown;
        [SerializeField] private PlayerRaycaster _playerRaycaster;
        [SerializeField] private GameObject _duckSpawners;

        private int currentBullets;
        private float _currentTime;
        private Coroutine reloadRoutine;
        
        private void Start()
        {
            DuckScore.OnAddScore += AddScore;
            _currentTime = _endGameTime;
            currentBullets = _bulletsMagazine;
            _bulletsText.text = currentBullets.ToString();
        }
        private void OnDestroy()
        {
            DuckScore.OnAddScore -= AddScore;
        }

        private void Update()
        {
            TimeUpdate();
            if (_currentTime <= 0)
            {
                enabled = false;
                Destroy(_duckSpawners);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            
        }

        [ContextMenu("Increase Score")]
        public void AddScore(int score)
        {
            _playerScore = _playerScore + score;
            _scoreText.text = _playerScore.ToString();
        }
        private void Shoot()
        {
            if (currentBullets > 0)
            {
                _playerRaycaster.DoRaycast();
                currentBullets -= 1;
                _bulletsText.text = currentBullets.ToString();
                if (currentBullets == 0)
                {
                    Reload();
                }
            }
        }

        private void Reload()
        {
            if (reloadRoutine != null) 
            {
                return;
            }
            reloadRoutine = StartCoroutine(ReloadRoutine());

        }
        private IEnumerator ReloadRoutine()
        {
            yield return new WaitForSeconds(_coolDown);
            currentBullets = _bulletsMagazine;
            reloadRoutine = null;
        }

        private void TimeUpdate()
        {
            _currentTime = Mathf.Clamp(_currentTime - Time.deltaTime, 0, _endGameTime);
            _timeText.text = _currentTime.ToString();
        }

        

    }
}