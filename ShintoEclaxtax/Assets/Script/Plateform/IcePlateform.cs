using System.ComponentModel;
using UnityEngine;
using SException = System.Exception;

[RequireComponent (typeof(TimerCustom))]
public class IcePlateform : Plateform
{
	[SerializeField] TimerCustom timerFreeze;
	[SerializeField] bool isInfiniteFreeze = false;
	[SerializeField] Material materialFreeze = null;
	[SerializeField] Material materialBlock = null;
	[SerializeField] MeshRenderer mesh = null;

	[SerializeField] LayerMask solidLayer;
	[SerializeField] LayerMask worldLayer;



	private void Awake()
	{
		if (!materialFreeze || !materialBlock) throw new SException("Materials is invalid");

		timerFreeze = GetComponent<TimerCustom>();
		timerFreeze.OnTimerStart += SetIceBlock;
		timerFreeze.OnTimerStop += Disable;
	}
	private void Start() => mesh.material = materialBlock;
	
	public override void Enable()
	{
		if (isInfiniteFreeze) return;
		if (IsEnabled)
		{
			timerFreeze.Restart();
			return;
		}

		base.Enable();
		if (!isInfiniteFreeze)
			timerFreeze.StartTimer();
		else
			SetIceBlock();
	}
	public override void Disable()
	{
		base.Disable();
		mesh.material = materialBlock;
		timerFreeze.Restart();
		ChangeLayer(worldLayer);
	}
	public void SetIceBlock()
	{
		mesh.material = materialFreeze;
		ChangeLayer(solidLayer);
	}	

	private void OnCollisionEnter(Collision collision)
	{
		//Ichigo _player = collision.gameObject.GetComponent<Ichigo>();
		TestPlayer _player = collision.gameObject.GetComponent<TestPlayer>();
		if (!_player) return;
		_player.gameObject.transform.position = collision.transform.position;
	}

	private void ChangeLayer(LayerMask layerMask)
	{
		int _value = ToLayer(layerMask.value);
		gameObject.layer = _value;
	}

	/// <summary>
	/// Cherche le layer depuis le bitmask du layerMask
	/// </summary>
	/// <param name="bitmask">Valeur du LayerMask</param>
	/// <returns>Integer</returns>
	public static int ToLayer(int bitmask)
	{
		int result = bitmask > 0 ? 0 : 31;
		while (bitmask > 1)
		{
			bitmask = bitmask >> 1; //divise par 2 le bitmask
			result++;
		}
		return result;
	}

}
