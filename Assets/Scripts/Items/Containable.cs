﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Containable : MonoBehaviour, IInteractable {

    [SerializeField] private ContainableSize size = ContainableSize.Normal;

    private Container container;

    public Container Container {
        get {
            return container;
        }
        set {
            if (value != null && container != null) {
                Debug.LogError("Tried to contain an already contained object");
                return;
            }
            container = value;
        }
    }

    public bool IsInteractable(GameObject source) {
        // Check to see if we can remove it from the current container
        if (container != null && container.Restricted) {
            return false;
        }

        CharacterInventory inventory = source.GetComponent<CharacterInventory>();
        if (!inventory) {
            return false;
        }
        return inventory.GetActiveHand().CanContain(this);
    }

    public void Interact(GameObject source) {
        if (!IsInteractable(source)) {
            return;
        }
        CharacterInventory inventory = source.GetComponent<CharacterInventory>();

        if (container != null) {
            container.Remove(this);
        }

        inventory.GetActiveHand().Contain(this);
    }

    public ContainableSize GetWeight() {
        return size;
    }
}
