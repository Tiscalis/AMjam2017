﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : InteractableObject
{
    [SerializeField]
    private GameObject OpenDoor;
    [SerializeField]
    private GameObject ClosedDoor;
    [SerializeField]
    private bool isOpen = false;

    private const string closedTag = "DoorClosed";
    private const string openTag = "DoorOpen";


    public void Start()
    {
        SetState(isOpen);
    }

    public override void Interact(Actor actor)
    {
        base.Interact(actor);

        actor.Kill();

        GameManager.Instance.UnregisterInteractable(this);
        ChangeState();
        gameObject.tag = "DoorOpen";
        //var renderers = gameObject.GetComponentsInChildren<Renderer>();
        //foreach (var rendr in renderers)
        //    rendr.enabled = false;
    }

    public override void ResetInteractiable()
    {
        base.ResetInteractiable();
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (var rendr in renderers)
            rendr.enabled = true;
    }
    [ContextMenu("Change State")]
    public void ChangeState()
    {
        isOpen = !isOpen;
        SetState(isOpen);
        this.tag = isOpen ? openTag : closedTag;
    }

    private void SetState(bool origin)
    {
        OpenDoor.SetActive(origin);
        ClosedDoor.SetActive(!origin);
    }
}
