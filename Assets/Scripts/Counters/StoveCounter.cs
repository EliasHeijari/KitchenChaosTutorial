using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        { // Counter Is Empty
            if (player.HasKitchenObject())
            { // Player Is Holding Kitchen Object
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) // Player carrying sliceable kitchen object
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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

            }
        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputFromInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else return null;
    }

    private FryingRecipeSO GetCuttingRecipeSOWithInput (KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }

}
