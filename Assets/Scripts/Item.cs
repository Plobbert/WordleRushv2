using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName = "", description = "";
    public int cost = 0, width = 0, height = 0, maxAmount = 0, currentAmount = 0, roundUnlocked = 0, row = 0, column = 0;
    public GameObject icon;

    public Item(string name, string desc, int theCost, int theWidth, int theHeight, int theMaxAmount, int theCurrentAmount, int theRoundUnlocked)
    {
        itemName = name;
        description = desc;
        cost = theCost;
        width = theWidth;
        height = theHeight;
        maxAmount = theMaxAmount;
        currentAmount = theCurrentAmount;
        roundUnlocked = theRoundUnlocked;
    }

    public void SetName(string name)
    {
        itemName = name;
    }

    public string GetName()
    {
        return itemName;
    }

    public void SetDesc(string desc)
    {
        description = desc;
    }

    public string GetDesc()
    {
        return description;
    }

    public void SetCost(int theCost)
    {
        cost = theCost;
    }

    public int GetCost()
    {
        return cost;
    }

    public void SetWidth(int theWidth)
    {
        width = theWidth;
    }

    public int GetWidth()
    {
        return width;
    }

    public void SetHeight(int theHeight)
    {
        height = theHeight;
    }

    public int GetHeight()
    {
        return height;
    }

    public void SetMaxAmount(int amount)
    {
        maxAmount = amount;
    }

    public int GetMaxAmount()
    {
        return maxAmount;
    }

    public void SetCurrentAmount(int amount)
    {
        currentAmount = amount;
    }

    public int GetCurrentAmount()
    {
        return currentAmount;
    }
    public void SetRoundUnlocked(int round)
    {
        roundUnlocked = round;
    }

    public int GetRoundUnlocked()
    {
        return roundUnlocked;
    }

    public void SetRow(int theRow)
    {
        row = theRow;
    }

    public int GetRow()
    {
        return row;
    }

    public void SetColumn(int theColumn)
    {
        column = theColumn;
    }

    public int GetColumn()
    {
        return column;
    }

    public void SetIcon(GameObject theIcon)
    {
        icon = theIcon;
    }

    public GameObject GetIcon()
    {
        return icon;
    }
}

