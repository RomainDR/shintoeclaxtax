using UnityEngine;

public class BombCollectible : Collectible
{
	[SerializeField] Bomb collectibleBomb;
	

	private void OnTriggerEnter(Collider other)
	{
		Ichigo _player = other.GetComponent<Ichigo>();
		if (!_player || !collectibleBomb)
			return;

		//gameObject.GetComponent<Renderer>().material = collectibleBomb.GetComponent<Renderer>().material;
		Ichigo.OnPickBomb?.Invoke(collectibleBomb);
		Destroy(gameObject);
	}
}
