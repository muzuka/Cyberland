using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public GunItem gun { get; set; }
    public Image icon;
    public int id;

    public void OnDrop(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            Vector3 mousePosition = Input.mousePosition;

            RectTransform invEntry = transform as RectTransform;

            Debug.Log("Dropped at " + mousePosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(invEntry, mousePosition))
            {
                gun = EventSystem.current.currentSelectedGameObject.GetComponent<Draggable>().gun;
                icon.sprite = gun.icon;
                if (gun.name != "Pistol" && gun.name != "Laser" && gun.name != "Shuriken")
                {
                    icon.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    icon.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);
                    icon.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
                }
                switch(id)
                {
                    case 1:
                        SelectedGuns.gun1 = gun;
                        break;
                    case 2:
                        SelectedGuns.gun2 = gun;
                        break;
                    case 3:
                        SelectedGuns.gun3 = gun;
                        break;
                }
            }
        }
    }
}
