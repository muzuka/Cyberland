using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnDraggable : MonoBehaviour, IPointerDownHandler {

    public GameObject spawnObject;
    public GunItem gun;

	// Use this for initialization
    public void OnPointerDown(PointerEventData eventData)
    {
        spawnObject.GetComponent<Draggable>().gun = gun;
        EventSystem.current.SetSelectedGameObject(spawnObject);
    }
}
