namespace Rope2d
{
    using UnityEngine;

    public class FingerSlicer : MonoBehaviour
    {
        public TrailRenderer trail;
        public LayerMask ropeLayer;
        public float fingerRadius = 0.1f;

        private bool IsActivated { get; set; }
        private bool IsSlicing { get; set; }

        private static RaycastHit2D[] cachedHits = new RaycastHit2D[16];

        private Camera _mainCamera;
        private float _cameraZCoord;
        private float _cameraYCoord;

        private void Activate()
        {
            _mainCamera = Camera.main;
            if (_mainCamera != null)
            {
                var position = _mainCamera.transform.position;
                _cameraZCoord = position.z;
                _cameraYCoord = position.y;
            }
            IsActivated = true;
        }

        public void Deactivate()
        {
            IsActivated = false;
        }

        private void Start()
        {
            Activate();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Debug.LogError("Start");
                StartSlicing();
            }

            var mousePos = Input.mousePosition;
            MoveTo(_mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y , -_cameraZCoord)));

            if (Input.GetMouseButtonUp(0))
            {
                // Debug.LogError("End");
                StopSlicing();
            }
        }

        private void StartSlicing()
        {
            IsSlicing = true;
            trail.enabled = false;
            trail.enabled = true;
            trail.emitting = true;
        }

        private void StopSlicing()
        {
            IsSlicing = false;
            if (trail) trail.emitting = false;
        }

        private void MoveTo(Vector3 position, bool? overrideSlicing = null)
        {
            bool slice = overrideSlicing ?? IsSlicing;
            if (slice)
            {
                SliceTo(position);
            }
            else
            {
                transform.position = position;
            }
        }

        private void SliceTo(Vector3 position)
        {
            var currentPosition = transform.position;
            if (position == currentPosition) return;

            if (IsActivated)
            {
                var dir = position - currentPosition;
                var dist = dir.magnitude;
                dir /= dist;

                var hitCount = Physics2D.CircleCastNonAlloc(currentPosition,
                    fingerRadius,
                    dir,
                    cachedHits,
                    dist,
                    ropeLayer.value);
                if (hitCount > 0)
                {
                    for (int i = 0; i < hitCount; i++)
                    {
                        var hit = cachedHits[i];
                        var ropeNode = hit.collider.GetComponentInParent<RopeNode>();
                        if (ropeNode)
                        {
                            ropeNode.CutAt(hit.point);
                            break;
                        }
                    }
                }
            }

            transform.position = position;
        }


#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
            Gizmos.DrawSphere(transform.position, fingerRadius);
        }
#endif
    }
}