using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Duks
{
    public class DuckSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnItem;
        [SerializeField] private float _spawnRateMin;
        [SerializeField] private float _spawnRateMax;
        [SerializeField] private float _spawnRange;

        private float timer;
        private float spawnRate;

        private void Start()
        {
            SpawnObject();

            spawnRate = Random.Range(_spawnRateMin, _spawnRateMax);
        }

        private void Update()
        {
            
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnObject();
                timer = 0;
            }
        }

        public void SpawnObject()
        {
            float topPoint = transform.position.y - _spawnRange;
            float bottomtPoint = transform.position.y + _spawnRange;
            Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(topPoint, bottomtPoint), transform.position.z);

            Instantiate(_spawnItem, spawnPosition, transform.rotation);
        }
    }
}