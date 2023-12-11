using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicUI : MonoBehaviour
{
    [SerializeField] Ichigo player = null;
    [SerializeField] TMP_Text bombName = null;
    [SerializeField] Slider lifeBar = null;

	private void Awake()
	{
        bombName.text = "";
        lifeBar.maxValue = player.Life;       
        Ichigo.OnDammge += LifeUpdate;
        Ichigo.OnPickBomb += BombUpdate;
        Ichigo.OnDead += Dead;

	}
    private void LifeUpdate(int _value)
    {
        lifeBar.value = lifeBar.value - _value;
    }
    private void BombUpdate(Bomb _bomb)
    {
        bombName.text = _bomb.Name;
    }
    void Dead()
    {
        Destroy(transform.parent);
    }
}
