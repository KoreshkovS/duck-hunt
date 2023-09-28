using Game.Duks;
using UnityEngine;

namespace Game.Base
{
    public class PlayerRaycaster: MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _layerMask;

        public void DoRaycast()
        {
            Vector3 ray = _camera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(ray);
            if (collider)
            {
                if (collider.TryGetComponent(out IDamagable duckScore))
                {
                    duckScore.Hit();
                }
            }
        }
    }
}