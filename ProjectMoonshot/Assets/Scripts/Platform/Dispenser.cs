using UnityEngine;
using Random = UnityEngine.Random;

namespace Platform
{
    public class Dispenser : BasePlatform
    {
        public GameObject[] objects;
        public Transform spawnPosition;
        public float cooldown = 2.5f;

        private float _elapsedTime;
        
        public override void Action()
        {
            var prefab = objects[Random.Range(0, objects.Length)];
            Instantiate(prefab, spawnPosition.position, Quaternion.identity);
            // Debug.Log(objects[Random.Range(0, objects.Length)].name);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= cooldown)
            {
                Action();
                _elapsedTime = 0f;
            }
        }
    }
}