using System;
using Game.Base;
using UnityEngine;

namespace Game.Duks
{
    public class DuckScore : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _score;


        public static event Action<int> OnAddScore;

        public void Hit()
        {
            Destroy(gameObject);
            OnAddScore?.Invoke(_score);
        }

    }
}