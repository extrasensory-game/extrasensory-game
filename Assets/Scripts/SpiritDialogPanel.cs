using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SpiritDialogPanel : MonoBehaviour {

	public Button Answer1;
	public Button Answer2;
	public Button Answer3;
	public GameObject Question;

	public Text Answer1Text;
	public Text Answer2Text;
	public Text Answer3Text;
	public Text QuestionText;

	public Action<int> OnAnswerAction;

	public void OnAnswer(int i)
	{
		if (OnAnswerAction != null)
			OnAnswerAction (i);
	}

}
