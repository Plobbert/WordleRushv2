using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    Item[,] inventory = new Item[5 , 6];
    Item[] allItems = new Item[5];
    List<Item> shop = new List<Item>();
    GameManager script;
    void Start()
    {
        allItems[0] = new Item("Extra Time", "Grants the player an extra 30 seconds when used.", 100, 1, 2, 3, 0, 0);
        allItems[1] = new Item("Undo", "Clears the previous guess, giving the player an extra guess.", 500, 2, 2, 1, 0, 0);
        allItems[2] = new Item("Free Letter", "Reveals one letter in the word on the keyboard.", 350, 2, 1, 3, 0, 5);
        allItems[3] = new Item("Double Coins!", "Doubles the amount of coins earned for the current round.", 400, 2, 2, 3, 0, 7);
        allItems[4] = new Item("Second Chance", "Whilst in the players inventory, this item grants them a second chance upon failing a round.", 1000, 2, 3, 1, 0, 10);
        script = this.GetComponent<GameManager>();
        updateShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanInsert(int wide, int high)
    {
        int checkForSpot = 0;
        for (int i = 0; i < 5 - wide; i++)
        {
            for (int j = 0; j < 6 - high; j++)
            {
                for (int k = 0; k < wide; k++)
                {
                    for (int l = 0; l < high; l++)
                    {
                        if (inventory[i + k, j + l] == null)
                        {
                            checkForSpot++;
                        }
                    }
                }
                if (checkForSpot == wide * high)
                {
                    return true;
                } else
                {
                    checkForSpot = 0;
                }
            }
        }
        return false;
    }

    public bool SetSpot(int i, int j, int wide, int high, Item item)
    {
        int checkForSpot = 0;
        for (int k = 0; k < wide; k++)
        {
            for (int l = 0; l < high; l++)
            {
                if (inventory[i + k, j + l] == null)
                {
                    checkForSpot++;
                }
            }
        }
        if (checkForSpot == wide * high)
        {
            for (int k = 0; k < wide; k++)
            {
                for (int l = 0; l < high; l++)
                {
                    inventory[i + k, j + l] = item;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ClearSpot(int i, int j, int wide, int high)
    {
        for (int k = 0; k < wide; k++)
        {
            for (int l = 0; l < high; l++)
            {
                inventory[i + k, j + l] = null;
            }
        }
    }

    public void updateShop()
    {
        for (int i = 0; i < 5; i++)
        {
            if (allItems[i].GetRoundUnlocked() >= script.currentRound)
            {
                shop.Add(allItems[i]);
            }
        }
    }
}
