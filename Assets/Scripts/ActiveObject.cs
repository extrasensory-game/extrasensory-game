using System;
using UnityEngine;

namespace ExtrasensoryGame
{
	public class ActiveObject:MonoBehaviour
	{
		public Action Action;

		public void OnMouseUpAsButton()
		{
			if(Action!=null)
				Action ();
		}
	}
}

