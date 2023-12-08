using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class WindExplode : ExplodeZone
{
	[SerializeField] Wind[] tornads = new Wind[4];

	public override void Init(Vector3 _position)
	{
		if (tornads.Length < 4) throw new System.Exception("tornads list < 4");
		else if (tornads.Length > 4)
		{
			Wind[] winds = new Wind[4];
			for (int i = 0; i < 4; i++)
				winds[i] = tornads[i];
			tornads = winds;
		}
		int _angle = 0;
		for (int i = 0; i < 4; i++)
		{
			Wind _wind = Instantiate<Wind>(tornads[i]);
			_wind.Init(_position, _angle);
			_angle += 90;
		}
		Delete();
	}

	public override void Delete()
	{
		base.Delete();
	}

}
