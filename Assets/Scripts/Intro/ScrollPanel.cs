using UnityEngine;

namespace ExtrasensoryGame.Assets.Scripts.Intro
{
    public class ScrollPanel : MonoBehaviour
    {
        [SerializeField]
        private DiabloEntering diablo;
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

        public void ClosePanel()
        {
            animator.SetTrigger("Close");
        }

        public void OnAnimationEnd()
        {
            diablo.Leave();
        }
    }
}
