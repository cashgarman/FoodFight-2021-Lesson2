using UnityEngine;
using Random = UnityEngine.Random;

namespace FoodFight.Scripts
{
	public class FoodfightGame : MonoBehaviour
	{
		[SerializeField] private Target _targetPrefab;
		[SerializeField] private BoxCollider _spawnArea;

		private void Start()
		{
			// Spawn the first target
			SpawnTarget();
		}

		public void OnTargetHit()
		{
			// Spawn a target
			SpawnTarget();
		}

		private void SpawnTarget()
		{
			// Spawn a new target
			var newTarget = Instantiate(_targetPrefab, GetRandomTargetPosition(), _targetPrefab.transform.rotation);
			
			// Let the new target know about this game object so it can communicate
			newTarget._game = this;
		}

		private Vector3 GetRandomTargetPosition()
		{
			// Return a random position inside the spawn area
			return new Vector3(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x),
				Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y),
				Random.Range(_spawnArea.bounds.min.z, _spawnArea.bounds.max.z));
		}
	}
}