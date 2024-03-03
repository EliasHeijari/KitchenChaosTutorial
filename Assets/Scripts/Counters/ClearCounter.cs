using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        { // Counter Is Empty
            if (player.HasKitchenObject())
            { // Player Is Holding Kitchen Object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            { // Player Is Not Holding Aything

            }
        }
        else
        { // Counter Has A Kitchen Object
            if (!player.HasKitchenObject())
            { // Player Does Not Hold Anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            else
            { // Player Is Holding Kitchen Object
                if (player.GetKitchenObject() is PlateKitchenObject)
                {
                    // Player is holding a plate
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else {
                    // player is holding a KitchenObject, not a plate
                    if (GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                    {
                        // Counter has a plate and player has a KitchenObject
                        // TODO: put KitchenObject top of a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
        }
    }
}
