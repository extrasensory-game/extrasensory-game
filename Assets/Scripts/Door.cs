using System;
using UnityEngine;

namespace ExtrasensoryGame
{
	public class Door:MonoBehaviour
	{
		public Action DoorOpened;

		public void OnMouseUpAsButton()
		{
			DoorOpened ();

		}
	}
}

