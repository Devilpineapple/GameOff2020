using System.Collections.Generic;
using UnityEngine;

namespace CameraController
{
    public class MultipleTargetCamera : MonoBehaviour
    {
        public List<Transform> players = new List<Transform>();
        public Vector3 offset;
        public float smoothTime = 0.5f;
        public float minZoom = 40f;
        public float maxZoom = 10f;
        public float zoomLimiter = 50f;

        private Vector3 _velocity;
        private UnityEngine.Camera _cam;
        private Bounds _b;

        private void Awake()
        {
            _cam = GetComponent<UnityEngine.Camera>();
        }

        private void LateUpdate()
        {
            if (players.Count == 0)
                return;
            Move();
            Zoom();
        }

        private void Zoom()
        {
            var newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
            _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, newZoom, Time.deltaTime);
        }

        private float GetGreatestDistance()
        {
            var bounds = new Bounds(players[0].position, Vector3.zero);
            foreach (var t in players)
                bounds.Encapsulate(t.position);
            return bounds.size.z;
        }
    
        private void Move()
        {
            var centerPoint = GetCenterPoint();
            var newPos = centerPoint + offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref _velocity, smoothTime);
        }

        private Vector3 GetCenterPoint()
        {
            if (players.Count == 1)
                return players[0].position;
            var bounds = new Bounds(players[0].position, Vector3.zero);
            foreach (var t in players)
                bounds.Encapsulate(t.position);
            _b = bounds;
            return bounds.center;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_b.center, _b.size);
        }
    }
}