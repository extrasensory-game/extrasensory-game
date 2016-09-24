using UnityEngine;

namespace ExtrasensoryGame.Assets.Scripts.Intro
{
    public class ScrollPanel : MonoBehaviour
    {
        private Animator animator;
        // Use this for initialization
        private void Start ()
        {
            animator = GetComponent<Animator>();
        }

        public void OpenPanel()
        {
            animator.SetTrigger("Open");
        }
    }
}
