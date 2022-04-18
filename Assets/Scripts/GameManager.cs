using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    string[] wordList = { "about", "above", "abuse", "actor", "acute", "admit", "adopt", "adult", "after", "again", "agent", "agree", "ahead", "alarm", "album", "alert", "alike", "alive", "allow", "alone", "along", "alter", "among", "anger", "angle", "angry", "apart", "apple", "apply", "arena", "argue", "arise", "array", "aside", "asset", "audio", "audit", "avoid", "award", "aware", "badly", "baker", "bases", "basic", "basis", "beach", "began", "begin", "begun", "being", "below", "bench", "billy", "birth", "black", "blame", "blind", "block", "blood", "board", "boost", "booth", "bound", "brain", "brand", "bread", "break", "breed", "brief", "bring", "broad", "broke", "brown", "build", "built", "buyer", "cable", "calif", "carry", "catch", "cause", "chain", "chair", "chart", "chase", "cheap", "check", "chest", "chief", "child", "china", "chose", "civil", "claim", "class", "clean", "clear", "click", "clock", "close", "coach", "coast", "could", "count", "court", "cover", "craft", "crash", "cream", "crime", "cross", "crowd", "crown", "curve", "cycle", "daily", "dance", "dated", "dealt", "death", "debut", "delay", "depth", "doing", "doubt", "dozen", "draft", "drama", "drawn", "dream", "dress", "drill", "drink", "drive", "drove", "dying", "eager", "early", "earth", "eight", "elite", "empty", "enemy", "enjoy", "enter", "entry", "equal", "error", "event", "every", "exact", "exist", "extra", "faith", "false", "fault", "fiber", "field", "fifth", "fifty", "fight", "final", "first", "fixed", "flash", "fleet", "floor", "fluid", "focus", "force", "forth", "forty", "forum", "found", "frame", "frank", "fraud", "fresh", "front", "fruit", "fully", "funny", "giant", "given", "glass", "globe", "going", "grace", "grade", "grand", "grant", "grass", "great", "green", "gross", "group", "grown", "guard", "guess", "guest", "guide", "happy", "harry", "heart", "heavy", "hence", "henry", "horse", "hotel", "house", "human", "ideal", "image", "index", "inner", "input", "issue", "japan", "jimmy", "joint", "jones", "judge", "known", "label", "large", "laser", "later", "laugh", "layer", "learn", "lease", "least", "leave", "legal", "level", "lewis", "light", "limit", "links", "lives", "local", "logic", "loose", "lower", "lucky", "lunch", "lying", "magic", "major", "maker", "march", "maria", "match", "maybe", "mayor", "meant", "media", "metal", "might", "minor", "minus", "mixed", "model", "money", "month", "moral", "motor", "mount", "mouse", "mouth", "movie", "music", "needs", "never", "newly", "night", "noise", "north", "noted", "novel", "nurse", "occur", "ocean", "offer", "often", "order", "other", "ought", "paint", "panel", "paper", "party", "peace", "peter", "phase", "phone", "photo", "piece", "pilot", "pitch", "place", "plain", "plane", "plant", "plate", "point", "pound", "power", "press", "price", "pride", "prime", "print", "prior", "prize", "proof", "proud", "prove", "queen", "quick", "quiet", "quite", "radio", "raise", "range", "rapid", "ratio", "reach", "ready", "refer", "right", "rival", "river", "robin", "roger", "roman", "rough", "round", "route", "royal", "rural", "scale", "scene", "scope", "score", "sense", "serve", "seven", "shall", "shape", "share", "sharp", "sheet", "shelf", "shell", "shift", "shirt", "shock", "shoot", "short", "shown", "sight", "since", "sixth", "sixty", "sized", "skill", "sleep", "slide", "small", "smart", "smile", "smith", "smoke", "solid", "solve", "sorry", "sound", "south", "space", "spare", "speak", "speed", "spend", "spent", "split", "spoke", "sport", "staff", "stage", "stake", "stand", "start", "state", "steam", "steel", "stick", "still", "stock", "stone", "stood", "store", "storm", "story", "strip", "stuck", "study", "stuff", "style", "sugar", "suite", "super", "sweet", "table", "taken", "taste", "taxes", "teach", "teeth", "terry", "texas", "thank", "theft", "their", "theme", "there", "these", "thick", "thing", "think", "third", "those", "three", "threw", "throw ", "tight", "times", "tired", "title", "today", "topic", "total", "touch", "tough", "tower", "track", "trade", "train", "treat", "trend", "trial", "tried", "tries", "truck", "truly", "trust", "truth", "twice", "under", "undue", "union", "unity", "until", "upper", "upset", "urban", "usage", "usual", "valid", "value", "video", "virus", "visit", "vital", "voice", "waste", "watch", "water", "wheel", "where", "which", "while", "white", "whole", "whose", "woman", "women", "world", "worry", "worse", "worst", "worth", "would", "wound", "write", "wrong", "wrote", "yield", "young", "youth" };
    public int lettersTyped = 0, wordsEntered = 0;
    public string typedWord = "";
    public string theWord = "";
    // Start is called before the first frame update
    void Start()
    {
        theWord = wordList[Random.Range(0, wordList.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

    }

    void UpdateText()
    {
        if (lettersTyped < 5)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                typedWord += "A";
                typeText("A");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                typedWord += "B";
                typeText("B");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                typedWord += "C";
                typeText("C");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                typedWord += "D";
                typeText("D");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                typedWord += "E";
                typeText("E");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                typedWord += "F";
                typeText("F");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                typedWord += "G";
                typeText("G");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                typedWord += "H";
                typeText("H");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                typedWord += "I";
                typeText("I");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                typedWord += "J";
                typeText("J");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                typedWord += "K";
                typeText("K");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                typedWord += "L";
                typeText("L");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                typedWord += "M";
                typeText("M");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                typedWord += "N";
                typeText("N");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                typedWord += "O";
                typeText("O");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                typedWord += "P";
                typeText("P");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                typedWord += "Q";
                typeText("Q");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                typedWord += "R";
                typeText("R");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                typedWord += "S";
                typeText("S");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                typedWord += "T";
                typeText("T");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                typedWord += "U";
                typeText("U");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                typedWord += "V";
                typeText("V");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                typedWord += "W";
                typeText("W");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                typedWord += "X";
                typeText("X");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                typedWord += "Y";
                typeText("Y");
                lettersTyped++;
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                typedWord += "Z";
                typeText("Z");
                lettersTyped++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (lettersTyped != 0)
            {
                typedWord = typedWord.Substring(0, lettersTyped - 1);
                lettersTyped--;
                typeText("");
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (lettersTyped == 5)
            {
                GameObject box = GameObject.Find("Correctness");
                TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
                checkLetters();
                if (typedWord.ToLower().Equals(theWord))
                {
                    text.text = "Correct!";
                    text.color = new Color(0, 256, 0);
                }
                else
                {
                    if (wordsEntered == 5)
                    {
                        text.text = "epic fail bro";
                        text.color = new Color(256, 0, 0);
                    } else
                    {
                        typedWord = "";
                        lettersTyped = 0;
                        wordsEntered++;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            resetBoard();
        }
    }

    void typeText(string letterToType)
    {
        string boxNum = wordsEntered + "-" + (lettersTyped);
        GameObject box = GameObject.Find(boxNum);
        TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
        text.text = letterToType;
    }

    void checkLetters()
    {
        for (int i = 0; i < 5; i++)
        {
            string letterTested = typedWord.Substring(i, 1).ToLower();
            bool isLetterInWord = theWord.Contains(letterTested);
            int letterStatus = 0; // 0 = default, 1 = correct placement achieved, 2 = correct letter but wrong placement, 3 = not in word
            if (letterTested.Equals(theWord.Substring(i, 1)))
            {
                string boxNum = wordsEntered + "-" + (i);
                GameObject box = GameObject.Find(boxNum);
                SpriteRenderer sprite = box.GetComponent<SpriteRenderer>();
                sprite.color = new Color(0, 256, 0);
                letterStatus = 1;
            }
            else if (isLetterInWord)
            {
                string boxNum = wordsEntered + "-" + (i);
                GameObject box = GameObject.Find(boxNum);
                SpriteRenderer sprite = box.GetComponent<SpriteRenderer>();
                sprite.color = new Color(191, 191, 0);
                letterStatus = 2;
            } else
            {
                letterStatus = 3;
            }
            GameObject box1 = GameObject.Find(letterTested.ToUpper());
            SpriteRenderer sprite1 = box1.GetComponent<SpriteRenderer>();
            if (letterStatus == 1)
            {
                sprite1.color = new Color(0, 256, 0);
            } else if (letterStatus == 2)
            {
                Color test = new Color(0, 256, 0);
                if (sprite1.color != test)
                {
                    sprite1.color = new Color(191, 191, 0);
                }
            } else if (letterStatus == 3)
            {
                sprite1.color = new Color(0.3F, 0.3F, 0.3F);
            }
        }
    }

    void resetBoard()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                string boxNum = i + "-" + (j);
                GameObject box = GameObject.Find(boxNum);
                TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
                text.text = "";
                SpriteRenderer sprite = box.GetComponent<SpriteRenderer>();
                sprite.color = new Color(.9F, .2F, .2F);
            }
        }
        GameObject keyboard = GameObject.Find("Keyboard");
        for (int i = 0; i < keyboard.transform.childCount; i++)
        {
            GameObject Go = keyboard.transform.GetChild(i).gameObject;
            SpriteRenderer sprite = Go.GetComponent<SpriteRenderer>();
            sprite.color = new Color(.55F, .55F, .55F);
        }
        lettersTyped = 0;
        typedWord = "";
        theWord = wordList[Random.Range(0, wordList.Length)];
        wordsEntered = 0;
    }
}