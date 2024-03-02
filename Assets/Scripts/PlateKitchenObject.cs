using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    private List<KitchenObjectSO> kitchenObjectSOs;

    private void Awake() {
        kitchenObjectSOs = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSOs.Contains(kitchenObjectSO))
        { // Already has this type
            return false;
        }
        else
        {
            kitchenObjectSOs.Add(kitchenObjectSO);
            return true;
        }
    }
}
