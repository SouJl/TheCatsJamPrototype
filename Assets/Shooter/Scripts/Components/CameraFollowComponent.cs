using UnityEngine;

namespace Shooter.Components
{
    internal class CameraFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform _followTarget;
        [SerializeField] private float _smoothTime = 0.25f;
        [SerializeField] private bool isCustomOffset;
        [SerializeField] private Vector3 offset;

        private void Start()
        {
            if (!isCustomOffset)
            {
                offset = transform.position - _followTarget.position;
            }
        }

        private void LateUpdate()
        {
            SmoothFollow();
        }

        public void SmoothFollow()
        {
            Vector3 targetPos = _followTarget.position + offset;
            Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, _smoothTime);

            transform.position = smoothFollow;
            transform.LookAt(_followTarget);
        }
    }
}
