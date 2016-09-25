using System;
using UnityEngine;

namespace ExtrasensoryGame
{
	public class ActiveObject:MonoBehaviour
	{
		public Action DoorOpened;

		public void OnMouseUpAsButton()
		{
			if(DoorOpened!=null)
				DoorOpened ();
		}
	}
}

