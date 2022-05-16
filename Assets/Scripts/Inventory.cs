using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    Item[,] inventory = new Item[5,6];
    Item[] allItems = new Item[5];
    List<Item> shop = new List<Item>();
    GameManager script;
    bool itemBeingPlaced = false;
    Item currItem, selectedItem;
    GameObject itemIcon, rotatingSquare, use, sell;
    List<GameObject> invObjs = new List<GameObject>();
    int[] currPos = { 0, 0 };
    int[] navPos = { 0, 0 };
   
    void Start()
    {
        allItems[0] = new Item("Extra Time", "Grants the player an extra 30 seconds when used.", 100, 1, 2, 3, 0, 0);
        allItems[1] = new Item("Undo", "Clears the previous guess, giving the player an extra guess.", 500, 2, 2, 1, 0, 0);
        allItems[2] = new Item("Free Letter", "Reveals one letter in the word on the keyboard.", 350, 2, 1, 3, 0, 5);
        allItems[3] = new Item("Double Coins!", "Doubles the amount of coins earned for the current round.", 150, 2, 2, 3, 0, 7);
        allItems[4] = new Item("Second Chance", "Whilst in the players inventory, this item grants them a second chance upon failing a round.", 1000, 2, 3, 1, 0, 10);
        script = GameObject.Find("GameManager").GetComponent<GameManager>();
        rotatingSquare = GameObject.Find("SelectionSquare");
        use = GameObject.Find("UseButton");
        sell = GameObject.Find("SellButton");
        Debug.Log(use);
        use.SetActive(false);
        sell.SetActive(false);
        updateShop();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemBeingPlaced)
        {
            CheckForInput();
        }
        else if (script.invOpen == true)
        {
            navigateInventory();
        }
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
    public bool checkCurrentSpot(Item item, int[] currtPos)
    {
        for (int i = currtPos[1]; i < currtPos[1] + item.GetWidth(); i++)
        {
            for (int j = currtPos[0]; j < currtPos[0] + item.GetHeight(); j++)
            {
                if (inventory[i, j] != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool SetSpot()
    {
        currItem.SetRow(currPos[0]);
        currItem.SetColumn(currPos[1]);
        for (int i = currPos[1]; i < currPos[1] + currItem.GetWidth(); i++)
        {
            for (int j = currPos[0]; j < currPos[0] + currItem.GetHeight(); j++)
            {
                inventory[i, j] = currItem;
            }
        }
        return true;
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
            if (allItems[i].GetRoundUnlocked() >= script.currentRound && !shop.Contains(allItems[i]))
            {
                shop.Add(allItems[i]);
            }
        }
    }

    public void handleShopItemHover(GameObject obj)
    {
        Color col = new Color(.5F, .5F, .5F);
        col.a = 1.0F;
        obj.GetComponent<Image>().color = col;
        GameObject obj2 = GameObject.Find("Description");
        if (obj.name == "ExtraTime")
        {
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = allItems[0].GetDesc();
        } else if (obj.name == "Undo")
        {
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = allItems[1].GetDesc();
        }
        else if (obj.name == "FreeLetter")
        {
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = allItems[2].GetDesc();
        }
        else if (obj.name == "DoubleCoins")
        {
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = allItems[3].GetDesc();
        }
        else if (obj.name == "SecondChance")
        {
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = allItems[4].GetDesc();
        }
    }

    public void handleShopItemHoverExit(GameObject obj)
    {
        Color col = new Color(.5F, .5F, .5F);
        col.a = 0.0F;
        obj.GetComponent<Image>().color = col;
        GameObject obj2 = GameObject.Find("Description");
        obj2.GetComponent<TMPro.TextMeshProUGUI>().text = "- Select desired item\n\n- Use arrow keys to move the item to a valid spot in your inventory\n\n-Press enter to confirm selection\n\n-When confirmed, use the arrow keys to move the green dot onto the item you would like to use, then hit enter.\n\n- Click USE or SELL";
    }

    public void handleShopItemClick(GameObject obj)
    {
        if (!itemBeingPlaced)
        {
            itemIcon = new GameObject();
            if (obj.name == "ExtraTime")
            {
                if (script.coins > 100)
                {
                    itemIcon.name = "MoreTime";
                    itemIcon.AddComponent<RectTransform>();
                    itemIcon.transform.position = GameObject.Find("0-0").transform.position;
                    itemIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(1.5F, 2.25F);
                    itemIcon.transform.position = new Vector3(itemIcon.transform.position.x, itemIcon.transform.position.y - 52.5F, itemIcon.transform.position.z);
                    itemIcon.transform.localScale = new Vector3(70, 90, 0);
                    itemIcon.AddComponent<Image>();
                    currItem = new Item(allItems[0].GetName(), allItems[0].GetDesc(), allItems[0].GetCost(), allItems[0].GetWidth(), allItems[0].GetHeight(), allItems[0].GetMaxAmount(), allItems[0].GetCurrentAmount(), allItems[0].GetRoundUnlocked());
                    Color col;
                    if (checkCurrentSpot(currItem, currPos))
                    {
                        col = new Color(.5F, .7F, .5F);
                    }
                    else
                    {
                        col = new Color(.7F, .5F, .5F);
                    }
                    col.a = .7F;
                    itemIcon.GetComponent<Image>().color = col;
                    itemIcon.AddComponent<SpriteRenderer>();
                    itemIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Plus30");
                    itemIcon.transform.SetParent(GameObject.Find("InventoryItems").transform);
                    itemBeingPlaced = true;
                }
            }
            if (obj.name == "Undo")
            {
                if (script.coins > 500)
                {
                    itemIcon.name = "UndoItem";
                    itemIcon.AddComponent<RectTransform>();
                    itemIcon.transform.position = GameObject.Find("0-0").transform.position;
                    itemIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(2.25F, 2.25F);
                    itemIcon.transform.position = new Vector3(itemIcon.transform.position.x + 52.5F, itemIcon.transform.position.y - 52.5F, itemIcon.transform.position.z);
                    itemIcon.transform.localScale = new Vector3(90, 90, 0);
                    itemIcon.AddComponent<Image>();
                    currItem = new Item(allItems[1].GetName(), allItems[1].GetDesc(), allItems[1].GetCost(), allItems[1].GetWidth(), allItems[1].GetHeight(), allItems[1].GetMaxAmount(), allItems[1].GetCurrentAmount(), allItems[1].GetRoundUnlocked());
                    Color col;
                    if (checkCurrentSpot(currItem, currPos))
                    {
                        col = new Color(.5F, .7F, .5F);
                    }
                    else
                    {
                        col = new Color(.7F, .5F, .5F);
                    }
                    col.a = .7F;
                    itemIcon.GetComponent<Image>().color = col;
                    itemIcon.AddComponent<SpriteRenderer>();
                    itemIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UndoIcon");
                    itemIcon.transform.SetParent(GameObject.Find("InventoryItems").transform);
                    itemBeingPlaced = true;
                }
            }
            if (obj.name == "FreeLetter")
            {
                if (script.coins > 350)
                {
                    itemIcon.name = "FreeLetterItem";
                    itemIcon.AddComponent<RectTransform>();
                    itemIcon.transform.position = GameObject.Find("0-0").transform.position;
                    itemIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(2.25F, 1.5F);
                    itemIcon.transform.position = new Vector3(itemIcon.transform.position.x + 52.5F, itemIcon.transform.position.y, itemIcon.transform.position.z);
                    itemIcon.transform.localScale = new Vector3(90, 70, 0);
                    itemIcon.AddComponent<Image>();
                    currItem = new Item(allItems[2].GetName(), allItems[2].GetDesc(), allItems[2].GetCost(), allItems[2].GetWidth(), allItems[2].GetHeight(), allItems[2].GetMaxAmount(), allItems[2].GetCurrentAmount(), allItems[2].GetRoundUnlocked());
                    Color col;
                    if (checkCurrentSpot(currItem, currPos))
                    {
                        col = new Color(.5F, .7F, .5F);
                    }
                    else
                    {
                        col = new Color(.7F, .5F, .5F);
                    }
                    col.a = .7F;
                    itemIcon.GetComponent<Image>().color = col;
                    itemIcon.AddComponent<SpriteRenderer>();
                    itemIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("FreeLetter");
                    itemIcon.transform.SetParent(GameObject.Find("InventoryItems").transform);
                    itemBeingPlaced = true;
                }
            }
            if (obj.name == "DoubleCoins")
            {
                if (script.coins > 400)
                {
                    itemIcon.name = "DoubleCoinItem";
                    itemIcon.AddComponent<RectTransform>();
                    itemIcon.transform.position = GameObject.Find("0-0").transform.position;
                    itemIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(2.25F, 2.25F);
                    itemIcon.transform.position = new Vector3(itemIcon.transform.position.x + 52.5F, itemIcon.transform.position.y - 52.5F, itemIcon.transform.position.z);
                    itemIcon.transform.localScale = new Vector3(90, 90, 0);
                    itemIcon.AddComponent<Image>();
                    currItem = new Item(allItems[3].GetName(), allItems[3].GetDesc(), allItems[3].GetCost(), allItems[3].GetWidth(), allItems[3].GetHeight(), allItems[3].GetMaxAmount(), allItems[3].GetCurrentAmount(), allItems[3].GetRoundUnlocked());
                    Color col;
                    if (checkCurrentSpot(currItem, currPos))
                    {
                        col = new Color(.5F, .7F, .5F);
                    }
                    else
                    {
                        col = new Color(.7F, .5F, .5F);
                    }
                    col.a = .7F;
                    itemIcon.GetComponent<Image>().color = col;
                    itemIcon.AddComponent<SpriteRenderer>();
                    itemIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("DoubleCoin");
                    itemIcon.transform.SetParent(GameObject.Find("InventoryItems").transform);
                    itemBeingPlaced = true;
                }
            }
            if (obj.name == "SecondChance")
            {
                if (script.coins > 1000)
                {
                    itemIcon.name = "SecondChanceItem";
                    itemIcon.AddComponent<RectTransform>();
                    itemIcon.transform.position = GameObject.Find("0-0").transform.position;
                    itemIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(2.25F, 3.0F);
                    itemIcon.transform.position = new Vector3(itemIcon.transform.position.x + 52.5F, itemIcon.transform.position.y - 105.0F, itemIcon.transform.position.z);
                    itemIcon.transform.localScale = new Vector3(90, 110, 0);
                    itemIcon.AddComponent<Image>();
                    currItem = new Item(allItems[4].GetName(), allItems[4].GetDesc(), allItems[4].GetCost(), allItems[4].GetWidth(), allItems[4].GetHeight(), allItems[4].GetMaxAmount(), allItems[4].GetCurrentAmount(), allItems[4].GetRoundUnlocked());
                    Color col;
                    if (checkCurrentSpot(currItem, currPos))
                    {
                        col = new Color(.5F, .7F, .5F);
                    }
                    else
                    {
                        col = new Color(.7F, .5F, .5F);
                    }
                    col.a = .7F;
                    itemIcon.GetComponent<Image>().color = col;
                    itemIcon.AddComponent<SpriteRenderer>();
                    itemIcon.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SecondChance");
                    itemIcon.transform.SetParent(GameObject.Find("InventoryItems").transform);
                    itemBeingPlaced = true;
                }
            }
        }
    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currPos[1] > 0) {
                currPos[1]--;
                GameObject vecPos = GameObject.Find(currPos[0].ToString() + "-" + currPos[1].ToString());
                itemIcon.transform.position = new Vector3(vecPos.transform.position.x + ((currItem.GetWidth() - 1) * 52.5F), vecPos.transform.position.y - ((currItem.GetHeight() - 1) * 52.5F), vecPos.transform.position.z);
                Color col;
                if (checkCurrentSpot(currItem, currPos))
                {
                    col = new Color(.5F, .7F, .5F);
                }
                else
                {
                    col = new Color(.8F, .5F, .5F);
                }
                col.a = .7F;
                itemIcon.GetComponent<Image>().color = col;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currPos[1] < 4 - currItem.GetWidth() + 1)
            {
                currPos[1]++;
                GameObject vecPos = GameObject.Find(currPos[0].ToString() + "-" + currPos[1].ToString());
                itemIcon.transform.position = new Vector3(vecPos.transform.position.x + ((currItem.GetWidth() - 1) * 52.5F) , vecPos.transform.position.y - ((currItem.GetHeight() - 1) * 52.5F), vecPos.transform.position.z);
                Color col;
                if (checkCurrentSpot(currItem, currPos))
                {
                    col = new Color(.5F, .7F, .5F);
                }
                else
                {
                    col = new Color(.8F, .5F, .5F);
                }
                col.a = .7F;
                itemIcon.GetComponent<Image>().color = col;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currPos[0] > 0)
            {
                currPos[0]--;
                GameObject vecPos = GameObject.Find(currPos[0].ToString() + "-" + currPos[1].ToString());
                itemIcon.transform.position = new Vector3(vecPos.transform.position.x + ((currItem.GetWidth() - 1) * 52.5F), vecPos.transform.position.y - ((currItem.GetHeight() - 1) * 52.5F), vecPos.transform.position.z);
                Color col;
                if (checkCurrentSpot(currItem, currPos))
                {
                    col = new Color(.5F, .7F, .5F);
                }
                else
                {
                    col = new Color(.8F, .5F, .5F);
                }
                col.a = .7F;
                itemIcon.GetComponent<Image>().color = col;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currPos[0] < 5 - currItem.GetHeight() + 1)
            {
                currPos[0]++;
                GameObject vecPos = GameObject.Find(currPos[0].ToString() + "-" + currPos[1].ToString());
                itemIcon.transform.position = new Vector3(vecPos.transform.position.x + ((currItem.GetWidth() - 1) * 52.5F), vecPos.transform.position.y - ((currItem.GetHeight() - 1) * 52.5F), vecPos.transform.position.z);
                Color col;
                if (checkCurrentSpot(currItem, currPos))
                {
                    col = new Color(.5F, .7F, .5F);
                }
                else
                {
                    col = new Color(.8F, .5F, .5F);
                }
                col.a = .7F;
                itemIcon.GetComponent<Image>().color = col;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (checkCurrentSpot(currItem, currPos))
            {
                script.coins -= currItem.GetCost();
                GameObject.Find("Coins").GetComponent<TMPro.TextMeshProUGUI>().text = script.coins.ToString();
                GameObject newItem = new GameObject();
                newItem.name = itemIcon.name;
                newItem.AddComponent<RectTransform>();
                newItem.transform.position = itemIcon.transform.position;
                newItem.GetComponent<RectTransform>().sizeDelta = itemIcon.GetComponent<RectTransform>().sizeDelta;
                newItem.transform.position = itemIcon.transform.position;
                newItem.transform.localScale = itemIcon.transform.localScale;
                newItem.AddComponent<Image>();
                Color col = new Color(.5F, .5F, .5F);
                col.a = 1F;
                newItem.GetComponent<Image>().color = col;
                newItem.AddComponent<SpriteRenderer>();
                newItem.GetComponent<SpriteRenderer>().sprite = itemIcon.GetComponent<SpriteRenderer>().sprite;
                newItem.transform.SetParent(GameObject.Find("InventoryItems").transform);
                currItem.SetIcon(newItem);
                if (currItem.GetName() == "Second Chance")
                {
                    script.secondChances++;
                }
                SetSpot();
                invObjs.Add(newItem);
                currPos[0] = 0;
                currPos[1] = 0;
                Destroy(itemIcon);
                currItem = null;
                itemBeingPlaced = false;
            } else
            {

            }
        }
    }
    void navigateInventory()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (navPos[0] > 0)
            {
                navPos[0]--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (navPos[0] < 4)
            {
                navPos[0]++;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (navPos[1] > 0)
            {
                navPos[1]--;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (navPos[1] < 5)
            {
                navPos[1]++;
            }
        }
        GameObject obj = GameObject.Find(navPos[1] + "-" + navPos[0]);
        rotatingSquare.transform.position = obj.transform.position;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject obj2 = GameObject.Find("Description");
            if (inventory[navPos[0], navPos[1]] != null)
            {
                selectedItem = inventory[navPos[0], navPos[1]];
                obj2.GetComponent<TMPro.TextMeshProUGUI>().text = selectedItem.GetDesc();
                use.SetActive(true);
                sell.SetActive(true);

            } else
            {
                obj2.GetComponent<TMPro.TextMeshProUGUI>().text = "- Select desired item\n\n- Use arrow keys to move the item to a valid spot in your inventory\n\n-Press enter to confirm selection\n\n-When confirmed, use the arrow keys to move the green dot onto the item you would like to use, then hit enter.\n\n- Click USE or SELL";
                selectedItem = null;
                use.SetActive(false);
                sell.SetActive(false);
            }
        }
    }

    public void handleUseClick()
    {
        bool abilityFailure = false;
        if (selectedItem != null)
        {
            if (selectedItem.GetName() == "Extra Time")
            {
                script.cntdnw += 30.0F;
                GameObject timer = GameObject.Find("Timer");
                TMPro.TextMeshProUGUI timerText = timer.GetComponent<TMPro.TextMeshProUGUI>();
                int b = (int)System.Math.Round(script.cntdnw, 0);
                int minute = b / 60;
                int second = b % 60;
                string seconds = second.ToString();
                if (second < 10)
                {
                    seconds = "0" + seconds;
                }
                timerText.text = minute.ToString() + ":" + seconds;
            }
            if (selectedItem.GetName() == "Undo")
            {
                if (script.wordsEntered == 0)
                {
                    abilityFailure = true;
                } else
                {
                    for (int i = script.wordsEntered - 1; i <= script.wordsEntered; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            string boxNum = i + "-" + (j);
                            GameObject box = GameObject.Find(boxNum);
                            TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
                            text.text = "";
                            SpriteRenderer sprite = box.GetComponent<SpriteRenderer>();
                            sprite.color = new Color(.79F, .28F, .28F);
                        }
                    }
                    script.lettersTyped = 0;
                    script.wordsEntered--;
                    script.typedWord = "";
                }
            }
            if (selectedItem.GetName() == "Free Letter")
            {
                GameObject keyboard = GameObject.Find("Keyboard");
                bool foundLetter = false;
                for (int i = 0; i < keyboard.transform.childCount; i++)
                {
                    if (!foundLetter) {
                        GameObject Go = keyboard.transform.GetChild(i).gameObject;
                        TMPro.TextMeshProUGUI text = Go.GetComponent<TMPro.TextMeshProUGUI>();
                        SpriteRenderer sprite = Go.GetComponent<SpriteRenderer>();
                        if (script.theWord.Contains(text.text.ToLower()) && !script.foundLetters.Contains(text.text.ToLower()))
                        {
                            sprite.color = new Color(.83F, .83F, 0);
                            script.foundLetters += text.text.ToLower();
                            foundLetter = true;
                        }
                    }
                }
            }
            if (selectedItem.GetName() == "Double Coins!")
            {
                script.coinMultiplier = 2.0F;
            }
            if (!abilityFailure)
            {
                GameObject obj2 = GameObject.Find("Description");
                obj2.GetComponent<TMPro.TextMeshProUGUI>().text = "- Select desired item\n\n- Use arrow keys to move the item to a valid spot in your inventory\n\n-Press enter to confirm selection\n\n-When confirmed, use the arrow keys to move the green dot onto the item you would like to use, then hit enter.\n\n- Click USE or SELL";
                ClearSpot(selectedItem.GetColumn(), selectedItem.GetRow(), selectedItem.GetWidth(), selectedItem.GetHeight());
                Destroy(selectedItem.GetIcon());
                use.SetActive(false);
                sell.SetActive(false);
                selectedItem = null;
            } else
            {
                abilityFailure = false;
            }
        }
    }

    public void handleSellClick()
    {
        if (selectedItem != null)
        {
            GameObject obj2 = GameObject.Find("Description");
            obj2.GetComponent<TMPro.TextMeshProUGUI>().text = "- Select desired item\n\n- Use arrow keys to move the item to a valid spot in your inventory\n\n-Press enter to confirm selection\n\n-When confirmed, use the arrow keys to move the green dot onto the item you would like to use, then hit enter.\n\n- Click USE or SELL";
            script.coins += selectedItem.GetCost();
            ClearSpot(selectedItem.GetColumn(), selectedItem.GetRow(), selectedItem.GetWidth(), selectedItem.GetHeight());
            Destroy(selectedItem.GetIcon());
            use.SetActive(false);
            sell.SetActive(false);
            GameObject.Find("Coins").GetComponent<TMPro.TextMeshProUGUI>().text = script.coins.ToString();
            selectedItem = null;
        }
    }

    public void removeSecondChance()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (inventory[i, j] != null)
                {
                    if (inventory[i,j].GetName() == "Second Chance")
                    {
                        Destroy(inventory[i, j].GetIcon());
                        ClearSpot(inventory[i, j].GetColumn(), inventory[i, j].GetRow(), inventory[i, j].GetWidth(), inventory[i, j].GetHeight());
                    }
                }
            }
        }
    }
}
