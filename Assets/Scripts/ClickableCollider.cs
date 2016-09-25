using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableCollider : MonoBehaviour
{
    public Action OnClick = () => { };

    public void OnMouseUpAsButton()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            OnClick.Invoke();
    }
}
