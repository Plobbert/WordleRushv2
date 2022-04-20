using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    string[] wordList = { "about", "above", "abuse", "actor", "acute", "admit", "adopt", "adult", "after", "again", "agent", "agree", "ahead", "alarm", "album", "alert", "alike", "alive", "allow", "alone", "along", "alter", "among", "anger", "angle", "angry", "apart", "apple", "apply", "arena", "argue", "arise", "array", "aside", "asset", "audio", "audit", "avoid", "award", "aware", "badly", "baker", "bases", "basic", "basis", "beach", "began", "begin", "begun", "being", "below", "bench", "billy", "birth", "black", "blame", "blind", "block", "blood", "board", "boost", "booth", "bound", "brain", "brand", "bread", "break", "breed", "brief", "bring", "broad", "broke", "brown", "build", "built", "buyer", "cable", "calif", "carry", "catch", "cause", "chain", "chair", "chart", "chase", "cheap", "check", "chest", "chief", "child", "china", "chose", "civil", "claim", "class", "clean", "clear", "click", "clock", "close", "coach", "coast", "could", "count", "court", "cover", "craft", "crash", "cream", "crime", "cross", "crowd", "crown", "curve", "cycle", "daily", "dance", "dated", "dealt", "death", "debut", "delay", "demon", "depth", "doing", "doubt", "dozen", "draft", "drama", "drawn", "dream", "dress", "drill", "drink", "drive", "drove", "dying", "eager", "early", "earth", "eight", "elite", "empty", "enemy", "enjoy", "enter", "entry", "equal", "error", "event", "every", "exact", "exist", "extra", "faith", "false", "fault", "fiber", "field", "fifth", "fifty", "fight", "final", "first", "fixed", "flash", "fleet", "floor", "fluid", "focus", "force", "forth", "forty", "forum", "found", "frame", "frank", "fraud", "fresh", "front", "fruit", "fully", "funny", "giant", "given", "glass", "globe", "going", "grace", "grade", "grand", "grant", "grass", "great", "green", "gross", "group", "grown", "guard", "guess", "guest", "guide", "happy", "harry", "heart", "heavy", "hence", "henry", "horse", "hotel", "house", "human", "ideal", "image", "index", "inner", "input", "issue", "japan", "jimmy", "joint", "jones", "judge", "known", "label", "large", "laser", "later", "laugh", "layer", "learn", "lease", "least", "leave", "legal", "level", "lewis", "light", "limit", "links", "lives", "local", "logic", "loose", "lower", "lucky", "lunch", "lying", "magic", "major", "maker", "march", "maria", "match", "maybe", "mayor", "meant", "media", "metal", "might", "minor", "minus", "mixed", "model", "money", "month", "moral", "motor", "mount", "mouse", "mouth", "movie", "music", "needs", "never", "newly", "night", "noise", "north", "noted", "novel", "nurse", "occur", "ocean", "offer", "often", "order", "other", "ought", "paint", "panel", "paper", "party", "peace", "peter", "phase", "phone", "photo", "piece", "pilot", "pitch", "place", "plain", "plane", "plant", "plate", "point", "pound", "power", "press", "price", "pride", "prime", "print", "prior", "prize", "proof", "proud", "prove", "queen", "quick", "quiet", "quite", "radio", "raise", "range", "rapid", "ratio", "reach", "ready", "refer", "right", "rival", "river", "robin", "roger", "roman", "rough", "round", "route", "royal", "rural", "scale", "scene", "scope", "score", "sense", "serve", "seven", "shall", "shape", "share", "sharp", "sheet", "shelf", "shell", "shift", "shirt", "shock", "shoot", "short", "shown", "sight", "since", "sixth", "sixty", "sized", "skill", "sleep", "slide", "small", "smart", "smile", "smith", "smoke", "solid", "solve", "sorry", "sound", "south", "space", "spare", "speak", "speed", "spend", "spent", "split", "spoke", "sport", "staff", "stage", "stake", "stand", "start", "state", "steam", "steel", "stick", "still", "stock", "stone", "stood", "store", "storm", "story", "strip", "stuck", "study", "stuff", "style", "sugar", "suite", "super", "sweet", "table", "taken", "taste", "taxes", "teach", "teeth", "terry", "texas", "thank", "theft", "their", "theme", "there", "these", "thick", "thing", "think", "third", "those", "three", "threw", "throw ", "tight", "times", "tired", "title", "today", "topic", "total", "touch", "tough", "tower", "track", "trade", "train", "treat", "trend", "trial", "tried", "tries", "truck", "truly", "trust", "truth", "twice", "under", "undue", "union", "unity", "until", "upper", "upset", "urban", "usage", "usual", "valid", "value", "video", "virus", "visit", "vital", "voice", "waste", "watch", "water", "wheel", "where", "which", "while", "white", "whole", "whose", "woman", "women", "world", "worry", "worse", "worst", "worth", "would", "wound", "write", "wrong", "wrote", "yield", "young", "youth" };
    string[] allWordListSource = { "WHICH", "THERE", "THEIR", "ABOUT", "WOULD", "THESE", "OTHER", "WORDS", "COULD", "WRITE", "FIRST", "WATER", "AFTER", "WHERE", "RIGHT", "THINK", "THREE", "YEARS", "PLACE", "SOUND", "GREAT", "AGAIN", "STILL", "EVERY", "SMALL", "FOUND", "THOSE", "NEVER", "UNDER", "MIGHT", "WHILE", "HOUSE", "WORLD", "BELOW", "ASKED", "GOING", "LARGE", "UNTIL", "ALONG", "SHALL", "BEING", "OFTEN", "EARTH", "BEGAN", "SINCE", "STUDY", "NIGHT", "LIGHT", "ABOVE", "PAPER", "PARTS", "YOUNG", "STORY", "POINT", "TIMES", "HEARD", "WHOLE", "WHITE", "GIVEN", "MEANS", "MUSIC", "MILES", "THING", "TODAY", "LATER", "USING", "MONEY", "LINES", "ORDER", "GROUP", "AMONG", "LEARN", "KNOWN", "SPACE", "TABLE", "EARLY", "TREES", "SHORT", "HANDS", "STATE", "BLACK", "SHOWN", "STOOD", "FRONT", "VOICE", "KINDS", "MAKES", "COMES", "CLOSE", "POWER", "LIVED", "VOWEL", "TAKEN", "BUILT", "HEART", "READY", "QUITE", "CLASS", "BRING", "ROUND", "HORSE", "SHOWS", "PIECE", "GREEN", "STAND", "BIRDS", "START", "RIVER", "TRIED", "LEAST", "FIELD", "WHOSE", "GIRLS", "LEAVE", "ADDED", "COLOR", "THIRD", "HOURS", "MOVED", "PLANT", "DOING", "NAMES", "FORMS", "HEAVY", "IDEAS", "CRIED", "CHECK", "FLOOR", "BEGIN", "WOMAN", "ALONE", "PLANE", "SPELL", "WATCH", "CARRY", "WROTE", "CLEAR", "NAMED", "BOOKS", "CHILD", "GLASS", "HUMAN", "TAKES", "PARTY", "BUILD", "SEEMS", "BLOOD", "SIDES", "SEVEN", "MOUTH", "SOLVE", "NORTH", "VALUE", "DEATH", "MAYBE", "HAPPY", "TELLS", "GIVES", "LOOKS", "SHAPE", "LIVES", "STEPS", "AREAS", "SENSE", "SPEAK", "FORCE", "OCEAN", "SPEED", "WOMEN", "METAL", "SOUTH", "GRASS", "SCALE", "CELLS", "LOWER", "SLEEP", "WRONG", "PAGES", "SHIPS", "NEEDS", "ROCKS", "EIGHT", "MAJOR", "LEVEL", "TOTAL", "AHEAD", "REACH", "STARS", "STORE", "SIGHT", "TERMS", "CATCH", "WORKS", "BOARD", "COVER", "SONGS", "EQUAL", "STONE", "WAVES", "GUESS", "DANCE", "SPOKE", "BREAK", "CAUSE", "RADIO", "WEEKS", "LANDS", "BASIC", "LIKED", "TRADE", "FRESH", "FINAL", "FIGHT", "MEANT", "DRIVE", "SPENT", "LOCAL", "WAXES", "KNOWS", "TRAIN", "BREAD", "HOMES", "TEETH", "COAST", "THICK", "BROWN", "CLEAN", "QUIET", "SUGAR", "FACTS", "STEEL", "FORTH", "RULES", "NOTES", "UNITS", "PEACE", "MONTH", "VERBS", "SEEDS", "HELPS", "SHARP", "VISIT", "WOODS", "CHIEF", "WALLS", "CROSS", "WINGS", "GROWN", "CASES", "FOODS", "CROPS", "FRUIT", "STICK", "WANTS", "STAGE", "SHEEP", "NOUNS", "PLAIN", "DRINK", "BONES", "APART", "TURNS", "MOVES", "TOUCH", "ANGLE", "BASED", "RANGE", "MARKS", "TIRED", "OLDER", "FARMS", "SPEND", "SHOES", "GOODS", "CHAIR", "TWICE", "CENTS", "EMPTY", "ALIKE", "STYLE", "BROKE", "PAIRS", "COUNT", "ENJOY", "SCORE", "SHORE", "ROOTS", "PAINT", "HEADS", "SHOOK", "SERVE", "ANGRY", "CROWD", "WHEEL", "QUICK", "DRESS", "SHARE", "ALIVE", "NOISE", "SOLID", "CLOTH", "SIGNS", "HILLS", "TYPES", "DRAWN", "WORTH", "TRUCK", "PIANO", "UPPER", "LOVED", "USUAL", "FACES", "DROVE", "CABIN", "BOATS", "TOWNS", "PROUD", "COURT", "MODEL", "PRIME", "FIFTY", "PLANS", "YARDS", "PROVE", "TOOLS", "PRICE", "SHEET", "SMELL", "BOXES", "RAISE", "MATCH", "TRUTH", "ROADS", "THREW", "ENEMY", "LUNCH", "CHART", "SCENE", "GRAPH", "DOUBT", "GUIDE", "WINDS", "BLOCK", "GRAIN", "SMOKE", "MIXED", "GAMES", "WAGON", "SWEET", "TOPIC", "EXTRA", "PLATE", "TITLE", "KNIFE", "FENCE", "FALLS", "CLOUD", "WHEAT", "PLAYS", "ENTER", "BROAD", "STEAM", "ATOMS", "PRESS", "LYING", "BASIS", "CLOCK", "TASTE", "GROWS", "THANK", "STORM", "AGREE", "BRAIN", "TRACK", "SMILE", "FUNNY", "BEACH", "STOCK", "HURRY", "SAVED", "SORRY", "GIANT", "TRAIL", "OFFER", "OUGHT", "ROUGH", "DAILY", "AVOID", "KEEPS", "THROW", "ALLOW", "CREAM", "LAUGH", "EDGES", "TEACH", "FRAME", "BELLS", "DREAM", "MAGIC", "OCCUR", "ENDED", "CHORD", "FALSE", "SKILL", "HOLES", "DOZEN", "BRAVE", "APPLE", "CLIMB", "OUTER", "PITCH", "RULER", "HOLDS", "FIXED", "COSTS", "CALLS", "BLANK", "STAFF", "LABOR", "EATEN", "YOUTH", "TONES", "HONOR", "GLOBE", "GASES", "DOORS", "POLES", "LOOSE", "APPLY", "TEARS", "EXACT", "BRUSH", "CHEST", "LAYER", "WHALE", "MINOR", "FAITH", "TESTS", "JUDGE", "ITEMS", "WORRY", "WASTE", "HOPED", "STRIP", "BEGUN", "ASIDE", "LAKES", "BOUND", "DEPTH", "CANDY", "EVENT", "WORSE", "AWARE", "SHELL", "ROOMS", "RANCH", "IMAGE", "SNAKE", "ALOUD", "DRIED", "LIKES", "MOTOR", "POUND", "KNEES", "REFER", "FULLY", "CHAIN", "SHIRT", "FLOUR", "DROPS", "SPITE", "ORBIT", "BANKS", "SHOOT", "CURVE", "TRIBE", "TIGHT", "BLIND", "SLEPT", "SHADE", "CLAIM", "FLIES", "THEME", "QUEEN", "FIFTH", "UNION", "HENCE", "STRAW", "ENTRY", "ISSUE", "BIRTH", "FEELS", "ANGER", "BRIEF", "RHYME", "GLORY", "GUARD", "FLOWS", "FLESH", "OWNED", "TRICK", "YOURS", "SIZES", "NOTED", "WIDTH", "BURST", "ROUTE", "LUNGS", "UNCLE", "BEARS", "ROYAL", "KINGS", "FORTY", "TRIAL", "CARDS", "BRASS", "OPERA", "CHOSE", "OWNER", "VAPOR", "BEATS", "MOUSE", "TOUGH", "WIRES", "METER", "TOWER", "FINDS", "INNER", "STUCK", "ARROW", "POEMS", "LABEL", "SWING", "SOLAR", "TRULY", "TENSE", "BEANS", "SPLIT", "RISES", "WEIGH", "HOTEL", "STEMS", "PRIDE", "SWUNG", "GRADE", "DIGIT", "BADLY", "BOOTS", "PILOT", "SALES", "SWEPT", "LUCKY", "PRIZE", "STOVE", "TUBES", "ACRES", "WOUND", "STEEP", "SLIDE", "TRUNK", "ERROR", "PORCH", "SLAVE", "EXIST", "FACED", "MINES", "MARRY", "JUICE", "RACED", "WAVED", "GOOSE", "TRUST", "FEWER", "FAVOR", "MILLS", "VIEWS", "JOINT", "EAGER", "SPOTS", "BLEND", "RINGS", "ADULT", "INDEX", "NAILS", "HORNS", "BALLS", "FLAME", "RATES", "DRILL", "TRACE", "SKINS", "WAXED", "SEATS", "STUFF", "RATIO", "MINDS", "DIRTY", "SILLY", "COINS", "HELLO", "TRIPS", "LEADS", "RIFLE", "HOPES", "BASES", "SHINE", "BENCH", "MORAL", "FIRES", "MEALS", "SHAKE", "SHOPS", "CYCLE", "MOVIE", "SLOPE", "CANOE", "TEAMS", "FOLKS", "FIRED", "BANDS", "THUMB", "SHOUT", "CANAL", "HABIT", "REPLY", "RULED", "FEVER", "CRUST", "SHELF", "WALKS", "MIDST", "CRACK", "PRINT", "TALES", "COACH", "STIFF", "FLOOD", "VERSE", "AWAKE", "ROCKY", "MARCH", "FAULT", "SWIFT", "FAINT", "CIVIL", "GHOST", "FEAST", "BLADE", "LIMIT", "GERMS", "READS", "DUCKS", "DAIRY", "WORST", "GIFTS", "LISTS", "STOPS", "RAPID", "BRICK", "CLAWS", "BEADS", "BEAST", "SKIRT", "CAKES", "LIONS", "FROGS", "TRIES", "NERVE", "GRAND", "ARMED", "TREAT", "HONEY", "MOIST", "LEGAL", "PENNY", "CROWN", "SHOCK", "TAXES", "SIXTY", "ALTAR", "PULLS", "SPORT", "DRUMS", "TALKS", "DYING", "DATES", "DRANK", "BLOWS", "LEVER", "WAGES", "PROOF", "DRUGS", "TANKS", "SINGS", "TAILS", "PAUSE", "HERDS", "AROSE", "HATED", "CLUES", "NOVEL", "SHAME", "BURNT", "RACES", "FLASH", "WEARY", "HEELS", "TOKEN", "COATS", "SPARE", "SHINY", "ALARM", "DIMES", "SIXTH", "CLERK", "MERCY", "SUNNY", "GUEST", "FLOAT", "SHONE", "PIPES", "WORMS", "BILLS", "SWEAT", "SUITS", "SMART", "UPSET", "RAINS", "SANDY", "RAINY", "PARKS", "SADLY", "FANCY", "RIDER", "UNITY", "BUNCH", "ROLLS", "CRASH", "CRAFT", "NEWLY", "GATES", "HATCH", "PATHS", "FUNDS", "WIDER", "GRACE", "GRAVE", "TIDES", "ADMIT", "SHIFT", "SAILS", "PUPIL", "TIGER", "ANGEL", "CRUEL", "AGENT", "DRAMA", "URGED", "PATCH", "NESTS", "VITAL", "SWORD", "BLAME", "WEEDS", "SCREW", "VOCAL", "BACON", "CHALK", "CARGO", "CRAZY", "ACTED", "GOATS", "ARISE", "WITCH", "LOVES", "QUEER", "DWELL", "BACKS", "ROPES", "SHOTS", "MERRY", "PHONE", "CHEEK", "PEAKS", "IDEAL", "BEARD", "EAGLE", "CREEK", "CRIES", "ASHES", "STALL", "YIELD", "MAYOR", "OPENS", "INPUT", "FLEET", "TOOTH", "CUBIC", "WIVES", "BURNS", "POETS", "APRON", "SPEAR", "ORGAN", "CLIFF", "STAMP", "PASTE", "RURAL", "BAKED", "CHASE", "SLICE", "SLANT", "KNOCK", "NOISY", "SORTS", "STAYS", "WIPED", "BLOWN", "PILED", "CLUBS", "CHEER", "WIDOW", "TWIST", "TENTH", "HIDES", "COMMA", "SWEEP", "SPOON", "STERN", "CREPT", "MAPLE", "DEEDS", "RIDES", "MUDDY", "CRIME", "JELLY", "RIDGE", "DRIFT", "DUSTY", "DEVIL", "TEMPO", "HUMOR", "SENDS", "STEAL", "TENTS", "WAIST", "ROSES", "REIGN", "NOBLE", "CHEAP", "DENSE", "LINEN", "GEESE", "WOVEN", "POSTS", "HIRED", "WRATH", "SALAD", "BOWED", "TIRES", "SHARK", "BELTS", "GRASP", "BLAST", "POLAR", "FUNGI", "TENDS", "PEARL", "LOADS", "JOKES", "VEINS", "FROST", "HEARS", "LOSES", "HOSTS", "DIVER", "PHASE", "TOADS", "ALERT", "TASKS", "SEAMS", "CORAL", "FOCUS", "NAKED", "PUPPY", "JUMPS", "SPOIL", "QUART", "MACRO", "FEARS", "FLUNG", "SPARK", "VIVID", "BROOK", "STEER", "SPRAY", "DECAY", "PORTS", "SOCKS", "URBAN", "GOALS", "GRANT", "MINUS", "FILMS", "TUNES", "SHAFT", "FIRMS", "SKIES", "BRIDE", "WRECK", "FLOCK", "STARE", "HOBBY", "BONDS", "DARED", "FADED", "THIEF", "CRUDE", "PANTS", "FLUTE", "VOTES", "TONAL", "RADAR", "WELLS", "SKULL", "HAIRS", "ARGUE", "WEARS", "DOLLS", "VOTED", "CAVES", "CARED", "BROOM", "SCENT", "PANEL", "FAIRY", "OLIVE", "BENDS", "PRISM", "LAMPS", "CABLE", "PEACH", "RUINS", "RALLY", "SCHWA", "LAMBS", "SELLS", "COOLS", "DRAFT", "CHARM", "LIMBS", "BRAKE", "GAZED", "CUBES", "DELAY", "BEAMS", "FETCH", "RANKS", "ARRAY", "HARSH", "CAMEL", "VINES", "PICKS", "NAVAL", "PURSE", "RIGID", "CRAWL", "TOAST", "SOILS", "SAUCE", "BASIN", "PONDS", "TWINS", "WRIST", "FLUID", "POOLS", "BRAND", "STALK", "ROBOT", "REEDS", "HOOFS", "BUSES", "SHEER", "GRIEF", "BLOOM", "DWELT", "MELTS", "RISEN", "FLAGS", "KNELT", "FIBER", "ROOFS", "FREED", "ARMOR", "PILES", "AIMED", "ALGAE", "TWIGS", "LEMON", "DITCH", "DRUNK", "RESTS", "CHILL", "SLAIN", "PANIC", "CORDS", "TUNED", "CRISP", "LEDGE", "DIVED", "SWAMP", "CLUNG", "STOLE", "MOLDS", "YARNS", "LIVER", "GAUGE", "BREED", "STOOL", "GULLS", "AWOKE", "GROSS", "DIARY", "RAILS", "BELLY", "TREND", "FLASK", "STAKE", "FRIED", "DRAWS", "ACTOR", "HANDY", "BOWLS", "HASTE", "SCOPE", "DEALS", "KNOTS", "MOONS", "ESSAY", "THUMP", "HANGS", "BLISS", "DEALT", "GAINS", "BOMBS", "CLOWN", "PALMS", "CONES", "ROAST", "TIDAL", "BORED", "CHANT", "ACIDS", "DOUGH", "CAMPS", "SWORE", "LOVER", "HOOKS", "MALES", "COCOA", "PUNCH", "AWARD", "REINS", "NINTH", "NOSES", "LINKS", "DRAIN", "FILLS", "NYLON", "LUNAR", "PULSE", "FLOWN", "ELBOW", "FATAL", "SITES", "MOTHS", "MEATS", "FOXES", "MINED", "ATTIC", "FIERY", "MOUNT", "USAGE", "SWEAR", "SNOWY", "RUSTY", "SCARE", "TRAPS", "RELAX", "REACT", "VALID", "ROBIN", "CEASE", "GILLS", "PRIOR", "SAFER", "POLIO", "LOYAL", "SWELL", "SALTY", "MARSH", "VAGUE", "WEAVE", "MOUND", "SEALS", "MULES", "VIRUS", "SCOUT", "ACUTE", "WINDY", "STOUT", "FOLDS", "SEIZE", "HILLY", "JOINS", "PLUCK", "STACK", "LORDS", "DUNES", "BURRO", "HAWKS", "TROUT", "FEEDS", "SCARF", "HALLS", "COALS", "TOWEL", "SOULS", "ELECT", "BUGGY", "PUMPS", "LOANS", "SPINS", "FILES", "OXIDE", "PAINS", "PHOTO", "RIVAL", "FLATS", "SYRUP", "RODEO", "SANDS", "MOOSE", "PINTS", "CURLY", "COMIC", "CLOAK", "ONION", "CLAMS", "SCRAP", "DIDST", "COUCH", "CODES", "FAILS", "OUNCE", "LODGE", "GREET", "GYPSY", "UTTER", "PAVED", "ZONES", "FOURS", "ALLEY", "TILES", "BLESS", "CREST", "ELDER", "KILLS", "YEAST", "ERECT", "BUGLE", "MEDAL", "ROLES", "HOUND", "SNAIL", "ALTER", "ANKLE", "RELAY", "LOOPS", "ZEROS", "BITES", "MODES", "DEBTS", "REALM", "GLOVE", "RAYON", "SWIMS", "POKED", "STRAY", "LIFTS", "MAKER", "LUMPS", "GRAZE", "DREAD", "BARNS", "DOCKS", "MASTS", "POURS", "WHARF", "CURSE", "PLUMP", "ROBES", "SEEKS", "CEDAR", "CURLS", "JOLLY", "MYTHS", "CAGES", "GLOOM", "LOCKS", "PEDAL", "BEETS", "CROWS", "ANODE", "SLASH", "CREEP", "ROWED", "CHIPS", "FISTS", "WINES", "CARES", "VALVE", "NEWER", "MOTEL", "IVORY", "NECKS", "CLAMP", "BARGE", "BLUES", "ALIEN", "FROWN", "STRAP", "CREWS", "SHACK", "GONNA", "SAVES", "STUMP", "FERRY", "IDOLS", "COOKS", "JUICY", "GLARE", "CARTS", "ALLOY", "BULBS", "LAWNS", "LASTS", "FUELS", "ODDLY", "CRANE", "FILED", "WEIRD", "SHAWL", "SLIPS", "TROOP", "BOLTS", "SUITE", "SLEEK", "QUILT", "TRAMP", "BLAZE", "ATLAS", "ODORS", "SCRUB", "CRABS", "PROBE", "LOGIC", "ADOBE", "EXILE", "REBEL", "GRIND", "STING", "SPINE", "CLING", "DESKS", "GROVE", "LEAPS", "PROSE", "LOFTY", "AGONY", "SNARE", "TUSKS", "BULLS", "MOODS", "HUMID", "FINER", "DIMLY", "PLANK", "CHINA", "PINES", "GUILT", "SACKS", "BRACE", "QUOTE", "LATHE", "GAILY", "FONTS", "SCALP", "ADOPT", "FOGGY", "FERNS", "GRAMS", "CLUMP", "PERCH", "TUMOR", "TEENS", "CRANK", "FABLE", "HEDGE", "GENES", "SOBER", "BOAST", "TRACT", "CIGAR", "UNITE", "OWING", "THIGH", "HAIKU", "SWISH", "DIKES", "WEDGE", "BOOTH", "EASED", "FRAIL", "COUGH", "TOMBS", "DARTS", "FORTS", "CHOIR", "POUCH", "PINCH", "HAIRY", "BUYER", "TORCH", "VIGOR", "WALTZ", "HEATS", "HERBS", "USERS", "FLINT", "CLICK", "MADAM", "BLEAK", "BLUNT", "AIDED", "LACKS", "MASKS", "WADED", "RISKS", "NURSE", "CHAOS", "SEWED", "CURED", "AMPLE", "LEASE", "STEAK", "SINKS", "MERIT", "BLUFF", "BATHE", "GLEAM", "BONUS", "COLTS", "SHEAR", "GLAND", "SILKY", "SKATE", "BIRCH", "ANVIL", "SLEDS", "GROAN", "MAIDS", "MEETS", "SPECK", "HYMNS", "HINTS", "DROWN", "BOSOM", "SLICK", "QUEST", "COILS", "SPIED", "SNOWS", "STEAD", "SNACK", "PLOWS", "BLOND", "TAMED", "THORN", "WAITS", "GLUED", "BANJO", "TEASE", "ARENA", "BULKY", "CARVE", "STUNT", "WARMS", "SHADY", "RAZOR", "FOLLY", "LEAFY", "NOTCH", "FOOLS", "OTTER", "PEARS", "FLUSH", "GENUS", "ACHED", "FIVES", "FLAPS", "SPOUT", "SMOTE", "FUMES", "ADAPT", "CUFFS", "TASTY", "STOOP", "CLIPS", "DISKS", "SNIFF", "LANES", "BRISK", "IMPLY", "DEMON", "SUPER", "FURRY", "RAGED", "GROWL", "TEXTS", "HARDY", "STUNG", "TYPED", "HATES", "WISER", "TIMID", "SERUM", "BEAKS", "ROTOR", "CASTS", "BATHS", "GLIDE", "PLOTS", "TRAIT", "RESIN", "SLUMS", "LYRIC", "PUFFS", "DECKS", "BROOD", "MOURN", "ALOFT", "ABUSE", "WHIRL", "EDGED", "OVARY", "QUACK", "HEAPS", "SLANG", "AWAIT", "CIVIC", "SAINT", "BEVEL", "SONAR", "AUNTS", "PACKS", "FROZE", "TONIC", "CORPS", "SWARM", "FRANK", "REPAY", "GAUNT", "WIRED", "NIECE", "CELLO", "NEEDY", "CHUCK", "STONY", "MEDIA", "SURGE", "HURTS", "REPEL", "HUSKY", "DATED", "HUNTS", "MISTS", "EXERT", "DRIES", "MATES", "SWORN", "BAKER", "SPICE", "OASIS", "BOILS", "SPURS", "DOVES", "SNEAK", "PACES", "COLON", "SIEGE", "STRUM", "DRIER", "CACAO", "HUMUS", "BALES", "PIPED", "NASTY", "RINSE", "BOXER", "SHRUB", "AMUSE", "TACKS", "CITED", "SLUNG", "DELTA", "LADEN", "LARVA", "RENTS", "YELLS", "SPOOL", "SPILL", "CRUSH", "JEWEL", "SNAPS", "STAIN", "KICKS", "TYING", "SLITS", "RATED", "EERIE", "SMASH", "PLUMS", "ZEBRA", "EARNS", "BUSHY", "SCARY", "SQUAD", "TUTOR", "SILKS", "SLABS", "BUMPS", "EVILS", "FANGS", "SNOUT", "PERIL", "PIVOT", "YACHT", "LOBBY", "JEANS", "GRINS", "VIOLA", "LINER", "COMET", "SCARS", "CHOPS", "RAIDS", "EATER", "SLATE", "SKIPS", "SOLES", "MISTY", "URINE", "KNOBS", "SLEET", "HOLLY", "PESTS", "FORKS", "GRILL", "TRAYS", "PAILS", "BORNE", "TENOR", "WARES", "CAROL", "WOODY", "CANON", "WAKES", "KITTY", "MINER", "POLLS", "SHAKY", "NASAL", "SCORN", "CHESS", "TAXIS", "CRATE", "SHYLY", "TULIP", "FORGE", "NYMPH", "BUDGE", "LOWLY", "ABIDE", "DEPOT", "OASES", "ASSES", "SHEDS", "FUDGE", "PILLS", "RIVET", "THINE", "GROOM", "LANKY", "BOOST", "BROTH", "HEAVE", "GRAVY", "BEECH", "TIMED", "QUAIL", "INERT", "GEARS", "CHICK", "HINGE", "TRASH", "CLASH", "SIGHS", "RENEW", "BOUGH", "DWARF", "SLOWS", "QUILL", "SHAVE", "SPORE", "SIXES", "CHUNK", "MADLY", "PACED", "BRAID", "FUZZY", "MOTTO", "SPIES", "SLACK", "MUCUS", "MAGMA", "AWFUL", "DISCS", "ERASE", "POSED", "ASSET", "CIDER", "TAPER", "THEFT", "CHURN", "SATIN", "SLOTS", "TAXED", "BULLY", "SLOTH", "SHALE", "TREAD", "RAKED", "CURDS", "MANOR", "AISLE", "BULGE", "LOINS", "STAIR", "TAPES", "LEANS", "BUNKS", "SQUAT", "TOWED", "LANCE", "PANES", "SAKES", "HEIRS", "CASTE", "DUMMY", "PORES", "FAUNA", "CROOK", "POISE", "EPOCH", "RISKY", "WARNS", "FLING", "BERRY", "GRAPE", "FLANK", "DRAGS", "SQUID", "PELTS", "ICING", "IRONY", "IRONS", "BARKS", "WHOOP", "CHOKE", "DIETS", "WHIPS", "TALLY", "DOZED", "TWINE", "KITES", "BIKES", "TICKS", "RIOTS", "ROARS", "VAULT", "LOOMS", "SCOLD", "BLINK", "DANDY", "PUPAE", "SIEVE", "SPIKE", "DUCTS", "LENDS", "PIZZA", "BRINK", "WIDEN", "PLUMB", "PAGAN", "FEATS", "BISON", "SOGGY", "SCOOP", "ARGON", "NUDGE", "SKIFF", "AMBER", "SEXES", "ROUSE", "SALTS", "HITCH", "EXALT", "LEASH", "DINED", "CHUTE", "SNORT", "GUSTS", "MELON", "CHEAT", "REEFS", "LLAMA", "LASSO", "DEBUT", "QUOTA", "OATHS", "PRONE", "MIXES", "RAFTS", "DIVES", "STALE", "INLET", "FLICK", "PINTO", "BROWS", "UNTIE", "BATCH", "GREED", "CHORE", "STIRS", "BLUSH", "ONSET", "BARBS", "VOLTS", "BEIGE", "SWOOP", "PADDY", "LACED", "SHOVE", "JERKY", "POPPY", "LEAKS", "FARES", "DODGE", "GODLY", "SQUAW", "AFFIX", "BRUTE", "NICER", "UNDUE", "SNARL", "MERGE", "DOSES", "SHOWY", "DADDY", "ROOST", "VASES", "SWIRL", "PETTY", "COLDS", "CURRY", "COBRA", "GENIE", "FLARE", "MESSY", "CORES", "SOAKS", "RIPEN", "WHINE", "AMINO", "PLAID", "SPINY", "MOWED", "BATON", "PEERS", "VOWED", "PIOUS", "SWANS", "EXITS", "AFOOT", "PLUGS", "IDIOM", "CHILI", "RITES", "SERFS", "CLEFT", "BERTH", "GRUBS", "ANNEX", "DIZZY", "HASTY", "LATCH", "WASPS", "MIRTH", "BARON", "PLEAD", "ALOOF", "AGING", "PIXEL", "BARED", "MUMMY", "HOTLY", "AUGER", "BUDDY", "CHAPS", "BADGE", "STARK", "FAIRS", "GULLY", "MUMPS", "EMERY", "FILLY", "OVENS", "DRONE", "GAUZE", "IDIOT", "FUSSY", "ANNOY", "SHANK", "GOUGE", "BLEED", "ELVES", "ROPED", "UNFIT", "BAGGY", "MOWER", "SCANT", "GRABS", "FLEAS", "LOUSY", "ALBUM", "SAWED", "COOKY", "MURKY", "INFER", "BURLY", "WAGED", "DINGY", "BRINE", "KNEEL", "CREAK", "VANES", "SMOKY", "SPURT", "COMBS", "EASEL", "LACES", "HUMPS", "RUMOR", "AROMA", "HORDE", "SWISS", "LEAPT", "OPIUM", "SLIME", "AFIRE", "PANSY", "MARES", "SOAPS", "HUSKS", "SNIPS", "HAZEL", "LINED", "CAFES", "NAIVE", "WRAPS", "SIZED", "PIERS", "BESET", "AGILE", "TONGS", "STEED", "FRAUD", "BOOTY", "VALOR", "DOWNY", "WITTY", "MOSSY", "PSALM", "SCUBA", "TOURS", "POLKA", "MILKY", "GAUDY", "SHRUG", "TUFTS", "WILDS", "LASER", "TRUSS", "HARES", "CREED", "LILAC", "SIREN", "TARRY", "BRIBE", "SWINE", "MUTED", "FLIPS", "CURES", "SINEW", "BOXED", "HOOPS", "GASPS", "HOODS", "NICHE", "YUCCA", "GLOWS", "SEWER", "WHACK", "FUSES", "GOWNS", "DROOP", "BUCKS", "PANGS", "MAILS", "WHISK", "HAVEN", "CLASP", "SLING", "STINT", "URGES", "CHAMP", "PIETY", "CHIRP", "PLEAT", "POSSE", "SUNUP", "MENUS", "HOWLS", "QUAKE", "KNACK", "PLAZA", "FIEND", "CAKED", "BANGS", "ERUPT", "POKER", "OLDEN", "CRAMP", "VOTER", "POSES", "MANLY", "SLUMP", "FINED", "GRIPS", "GAPED", "PURGE", "HIKED", "MAIZE", "FLUFF", "STRUT", "SLOOP", "PROWL", "ROACH", "COCKS", "BLAND", "DIALS", "PLUME", "SLAPS", "SOUPS", "DULLY", "WILLS", "FOAMS", "SOLOS", "SKIER", "EAVES", "TOTEM", "FUSED", "LATEX", "VEILS", "MUSED", "MAINS", "MYRRH", "RACKS", "GALLS", "GNATS", "BOUTS", "SISAL", "SHUTS", "HOSES", "DRYLY", "HOVER", "GLOSS", "SEEPS", "DENIM", "PUTTY", "GUPPY", "LEAKY", "DUSKY", "FILTH", "OBOES", "SPANS", "FOWLS", "ADORN", "GLAZE", "HAUNT", "DARES", "OBEYS", "BAKES", "ABYSS", "SMELT", "GANGS", "ACHES", "TRAWL", "CLAPS", "UNDID", "SPICY", "HOIST", "FADES", "VICAR", "ACORN", "PUSSY", "GRUFF", "MUSTY", "TARTS", "SNUFF", "HUNCH", "TRUCE", "TWEED", "DRYER", "LOSER", "SHEAF", "MOLES", "LAPSE", "TAWNY", "VEXED", "AUTOS", "WAGER", "DOMES", "SHEEN", "CLANG", "SPADE", "SOWED", "BROIL", "SLYLY", "STUDS", "GRUNT", "DONOR", "SLUGS", "ASPEN", "HOMER", "CROAK", "TITHE", "HALTS", "AVERT", "HAVOC", "HOGAN", "GLINT", "RUDDY", "JEEPS", "FLAKY", "LADLE", "TAUNT", "SNORE", "FINES", "PROPS", "PRUNE", "PESOS", "RADII", "POKES", "TILED", "DAISY", "HERON", "VILLA", "FARCE", "BINDS", "CITES", "FIXES", "JERKS", "LIVID", "WAKED", "INKED", "BOOMS", "CHEWS", "LICKS", "HYENA", "SCOFF", "LUSTY", "SONIC", "SMITH", "USHER", "TUCKS", "VIGIL", "MOLTS", "SECTS", "SPARS", "DUMPS", "SCALY", "WISPS", "SORES", "MINCE", "PANDA", "FLIER", "AXLES", "PLIED", "BOOBY", "PATIO", "RABBI", "PETAL", "POLYP", "TINTS", "GRATE", "TROLL", "TOLLS", "RELIC", "PHONY", "BLEAT", "FLAWS", "FLAKE", "SNAGS", "APTLY", "DRAWL", "ULCER", "SOAPY", "BOSSY", "MONKS", "CRAGS", "CAGED", "TWANG", "DINER", "TAPED", "CADET", "GRIDS", "SPAWN", "GUILE", "NOOSE", "MORES", "GIRTH", "SLIMY", "AIDES", "SPASM", "BURRS", "ALIBI", "LYMPH", "SAUCY", "MUGGY", "LITER", "JOKED", "GOOFY", "EXAMS", "ENACT", "STORK", "LURED", "TOXIC", "OMENS", "NEARS", "COVET", "WRUNG", "FORUM", "VENOM", "MOODY", "ALDER", "SASSY", "FLAIR", "GUILD", "PRAYS", "WRENS", "HAULS", "STAVE", "TILTS", "PECKS", "STOMP", "GALES", "TEMPT", "CAPES", "MESAS", "OMITS", "TEPEE", "HARRY", "WRING", "EVOKE", "LIMES", "CLUCK", "LUNGE", "HIGHS", "CANES", "GIDDY", "LITHE", "VERGE", "KHAKI", "QUEUE", "LOATH", "FOYER", "OUTDO", "FARED", "DETER", "CRUMB", "ASTIR", "SPIRE", "JUMPY", "EXTOL", "BUOYS", "STUBS", "LUCID", "THONG", "AFORE", "WHIFF", "MAXIM", "HULLS", "CLOGS", "SLATS", "JIFFY", "ARBOR", "CINCH", "IGLOO", "GOODY", "GAZES", "DOWEL", "CALMS", "BITCH", "SCOWL", "GULPS", "CODED", "WAVER", "MASON", "LOBES", "EBONY", "FLAIL", "ISLES", "CLODS", "DAZED", "ADEPT", "OOZED", "SEDAN", "CLAYS", "WARTS", "KETCH", "SKUNK", "MANES", "ADORE", "SNEER", "MANGO", "FIORD", "FLORA", "ROOMY", "MINKS", "THAWS", "WATTS", "FREER", "EXULT", "PLUSH", "PALED", "TWAIN", "CLINK", "SCAMP", "PAWED", "GROPE", "BRAVO", "GABLE", "STINK", "SEVER", "WANED", "RARER", "REGAL", "WARDS", "FAWNS", "BABES", "UNIFY", "AMEND", "OAKEN", "GLADE", "VISOR", "HEFTY", "NINES", "THROB", "PECAN", "BUTTS", "PENCE", "SILLS", "JAILS", "FLYER", "SABER", "NOMAD", "MITER", "BEEPS", "DOMED", "GULFS", "CURBS", "HEATH", "MOORS", "AORTA", "LARKS", "TANGY", "WRYLY", "CHEEP", "RAGES", "EVADE", "LURES", "FREAK", "VOGUE", "TUNIC", "SLAMS", "KNITS", "DUMPY", "MANIA", "SPITS", "FIRTH", "HIKES", "TROTS", "NOSED", "CLANK", "DOGMA", "BLOAT", "BALSA", "GRAFT", "MIDDY", "STILE", "KEYED", "FINCH", "SPERM", "CHAFF", "WILES", "AMIGO", "COPRA", "AMISS", "EYING", "TWIRL", "LURCH", "POPES", "CHINS", "SMOCK", "TINES", "GUISE", "GRITS", "JUNKS", "SHOAL", "CACHE", "TAPIR", "ATOLL", "DEITY", "TOILS", "SPREE", "MOCKS", "SCANS", "SHORN", "REVEL", "RAVEN", "HOARY", "REELS", "SCUFF", "MIMIC", "WEEDY", "CORNY", "TRUER", "ROUGE", "EMBER", "FLOES", "TORSO", "WIPES", "EDICT", "SULKY", "RECUR", "GROIN", "BASTE", "KINKS", "SURER", "PIGGY", "MOLDY", "FRANC", "LIARS", "INEPT", "GUSTY", "FACET", "JETTY", "EQUIP", "LEPER", "SLINK", "SOARS", "CATER", "DOWRY", "SIDED", "YEARN", "DECOY", "TABOO", "OVALS", "HEALS", "PLEAS", "BERET", "SPILT", "GAYLY", "ROVER", "ENDOW", "PYGMY", "CARAT", "ABBEY", "VENTS", "WAKEN", "CHIMP", "FUMED", "SODAS", "VINYL", "CLOUT", "WADES", "MITES", "SMIRK", "BORES", "BUNNY", "SURLY", "FROCK", "FORAY", "PURER", "MILKS", "QUERY", "MIRED", "BLARE", "FROTH", "GRUEL", "NAVEL", "PALER", "PUFFY", "CASKS", "GRIME", "DERBY", "MAMMA", "GAVEL", "TEDDY", "VOMIT", "MOANS", "ALLOT", "DEFER", "WIELD", "VIPER", "LOUSE", "ERRED", "HEWED", "ABHOR", "WREST", "WAXEN", "ADAGE", "ARDOR", "STABS", "PORED", "RONDO", "LOPED", "FISHY", "BIBLE", "HIRES", "FOALS", "FEUDS", "JAMBS", "THUDS", "JEERS", "KNEAD", "QUIRK", "RUGBY", "EXPEL", "GREYS", "RIGOR", "ESTER", "LYRES", "ABACK", "GLUES", "LOTUS", "LURID", "RUNGS", "HUTCH", "THYME", "VALET", "TOMMY", "YOKES", "EPICS", "TRILL", "PIKES", "OZONE", "CAPER", "CHIME", "FREES", "FAMED", "LEECH", "SMITE", "NEIGH", "ERODE", "ROBED", "HOARD", "SALVE", "CONIC", "GAWKY", "CRAZE", "JACKS", "GLOAT", "MUSHY", "RUMPS", "FETUS", "WINCE", "PINKS", "SHALT", "TOOTS", "GLENS", "COOED", "RUSTS", "STEWS", "SHRED", "PARKA", "CHUGS", "WINKS", "CLOTS", "SHREW", "BOOED", "FILMY", "JUROR", "DENTS", "GUMMY", "GRAYS", "HOOKY", "BUTTE", "DOGIE", "POLED", "REAMS", "FIFES", "SPANK", "GAYER", "TEPID", "SPOOK", "TAINT", "FLIRT", "ROGUE", "SPIKY", "OPALS", "MISER", "COCKY", "COYLY", "BALMY", "SLOSH", "BRAWL", "APHID", "FAKED", "HYDRA", "BRAGS", "CHIDE", "YANKS", "ALLAY", "VIDEO", "ALTOS", "EASES", "METED", "CHASM", "LONGS", "EXCEL", "TAFFY", "IMPEL", "SAVOR", "KOALA", "QUAYS", "DAWNS", "PROXY", "CLOVE", "DUETS", "DREGS", "TARDY", "BRIAR", "GRIMY", "ULTRA", "MEATY", "HALVE", "WAILS", "SUEDE", "MAUVE", "ENVOY", "ARSON", "COVES", "GOOEY", "BREWS", "SOFAS", "CHUMS", "AMAZE", "ZOOMS", "ABBOT", "HALOS", "SCOUR", "SUING", "CRIBS", "SAGAS", "ENEMA", "WORDY", "HARPS", "COUPE", "MOLAR", "FLOPS", "WEEPS", "MINTS", "ASHEN", "FELTS", "ASKEW", "MUNCH", "MEWED", "DIVAN", "VICES", "JUMBO", "BLOBS", "BLOTS", "SPUNK", "ACRID", "TOPAZ", "CUBED", "CLANS", "FLEES", "SLURS", "GNAWS", "WELDS", "FORDS", "EMITS", "AGATE", "PUMAS", "MENDS", "DARKS", "DUKES", "PLIES", "CANNY", "HOOTS", "OOZES", "LAMED", "FOULS", "CLEFS", "NICKS", "MATED", "SKIMS", "BRUNT", "TUBER", "TINGE", "FATES", "DITTY", "THINS", "FRETS", "EIDER", "BAYOU", "MULCH", "FASTS", "AMASS", "DAMPS", "MORNS", "FRIAR", "PALSY", "VISTA", "CROON", "CONCH", "UDDER", "TACOS", "SKITS", "MIKES", "QUITS", "PREEN", "ASTER", "ADDER", "ELEGY", "PULPY", "SCOWS", "BALED", "HOVEL", "LAVAS", "CRAVE", "OPTIC", "WELTS", "BUSTS", "KNAVE", "RAZED", "SHINS", "TOTES", "SCOOT", "DEARS", "CROCK", "MUTES", "TRIMS", "SKEIN", "DOTED", "SHUNS", "VEERS", "FAKES", "YOKED", "WOOED", "HACKS", "SPRIG", "WANDS", "LULLS", "SEERS", "SNOBS", "NOOKS", "PINED", "PERKY", "MOOED", "FRILL", "DINES", "BOOZE", "TRIPE", "PRONG", "DRIPS", "ODDER", "LEVEE", "ANTIC", "SIDLE", "PITHY", "CORKS", "YELPS", "JOKER", "FLECK", "BUFFS", "SCRAM", "TIERS", "BOGEY", "DOLED", "IRATE", "VALES", "COPED", "HAILS", "ELUDE", "BULKS", "AIRED", "VYING", "STAGS", "STREW", "COCCI", "PACTS", "SCABS", "SILOS", "DUSTS", "YODEL", "TERSE", "JADED", "BASER", "JIBES", "FOILS", "SWAYS", "FORGO", "SLAYS", "PREYS", "TREKS", "QUELL", "PEEKS", "ASSAY", "LURKS", "EJECT", "BOARS", "TRITE", "BELCH", "GNASH", "WANES", "LUTES", "WHIMS", "DOSED", "CHEWY", "SNIPE", "UMBRA", "TEEMS", "DOZES", "KELPS", "UPPED", "BRAWN", "DOPED", "SHUSH", "RINDS", "SLUSH", "MORON", "VOILE", "WOKEN", "FJORD", "SHEIK", "JESTS", "KAYAK", "SLEWS", "TOTED", "SANER", "DRAPE", "PATTY", "RAVES", "SULFA", "GRIST", "SKIED", "VIXEN", "CIVET", "VOUCH", "TIARA", "HOMEY", "MOPED", "RUNTS", "SERGE", "KINKY", "RILLS", "CORNS", "BRATS", "PRIES", "AMBLE", "FRIES", "LOONS", "TSARS", "DATUM", "MUSKY", "PIGMY", "GNOME", "RAVEL", "OVULE", "ICILY", "LIKEN", "LEMUR", "FRAYS", "SILTS", "SIFTS", "PLODS", "RAMPS", "TRESS", "EARLS", "DUDES", "WAIVE", "KARAT", "JOLTS", "PEONS", "BEERS", "HORNY", "PALES", "WREAK", "LAIRS", "LYNCH", "STANK", "SWOON", "IDLER", "ABORT", "BLITZ", "ENSUE", "ATONE", "BINGO", "ROVES", "KILTS", "SCALD", "ADIOS", "CYNIC", "DULLS", "MEMOS", "ELFIN", "DALES", "PEELS", "PEALS", "BARES", "SINUS", "CRONE", "SABLE", "HINDS", "SHIRK", "ENROL", "WILTS", "ROAMS", "DUPED", "CYSTS", "MITTS", "SAFES", "SPATS", "COOPS", "FILET", "KNELL", "REFIT", "COVEY", "PUNKS", "KILNS", "FITLY", "ABATE", "TALCS", "HEEDS", "DUELS", "WANLY", "RUFFS", "GAUSS", "LAPEL", "JAUNT", "WHELP", "CLEAT", "GAUZY", "DIRGE", "EDITS", "WORMY", "MOATS", "SMEAR", "PRODS", "BOWEL", "FRISK", "VESTS", "BAYED", "RASPS", "TAMES", "DELVE", "EMBED", "BEFIT", "WAFER", "CEDED", "NOVAS", "FEIGN", "SPEWS", "LARCH", "HUFFS", "DOLES", "MAMAS", "HULKS", "PRIED", "BRIMS", "IRKED", "ASPIC", "SWIPE", "MEALY", "SKIMP", "BLUER", "SLAKE", "DOWDY", "PENIS", "BRAYS", "PUPAS", "EGRET", "FLUNK", "PHLOX", "GRIPE", "PEONY", "DOUSE", "BLURS", "DARNS", "SLUNK", "LEFTS", "CHATS", "INANE", "VIALS", "STILT", "RINKS", "WOOFS", "WOWED", "BONGS", "FROND", "INGOT", "EVICT", "SINGE", "SHYER", "FLIED", "SLOPS", "DOLTS", "DROOL", "DELLS", "WHELK", "HIPPY", "FETED", "ETHER", "COCOS", "HIVES", "JIBED", "MAZES", "TRIOS", "SIRUP", "SQUAB", "LATHS", "LEERS", "PASTA", "RIFTS", "LOPES", "ALIAS", "WHIRS", "DICED", "SLAGS", "LODES", "FOXED", "IDLED", "PROWS", "PLAIT", "MALTS", "CHAFE", "COWER", "TOYED", "CHEFS", "KEELS", "STIES", "RACER", "ETUDE", "SUCKS", "SULKS", "MICAS", "CZARS", "COPSE", "AILED", "ABLER", "RABID", "GOLDS", "CROUP", "SNAKY", "VISAS", "PALLS", "MOPES", "BONED", "WISPY", "RAVED", "SWAPS", "JUNKY", "DOILY", "PAWNS", "TAMER", "POACH", "BAITS", "DAMNS", "GUMBO", "DAUNT", "PRANK", "HUNKS", "BUXOM", "HERES", "HONKS", "STOWS", "UNBAR", "IDLES", "ROUTS", "SAGES", "GOADS", "REMIT", "COPES", "DEIGN", "CULLS", "GIRDS", "HAVES", "LUCKS", "STUNK", "DODOS", "SHAMS", "SNUBS", "ICONS", "USURP", "DOOMS", "HELLS", "SOLED", "COMAS", "PAVES", "MATHS", "PERKS", "LIMPS", "WOMBS", "BLURB", "DAUBS", "COKES", "SOURS", "STUNS", "CASED", "MUSTS", "COEDS", "COWED", "APING", "ZONED", "RUMMY", "FETES", "SKULK", "QUAFF", "RAJAH", "DEANS", "REAPS", "GALAS", "TILLS", "ROVED", "KUDOS", "TONED", "PARED", "SCULL", "VEXES", "PUNTS", "SNOOP", "BAILS", "DAMES", "HAZES", "LORES", "MARTS", "VOIDS", "AMEBA", "RAKES", "ADZES", "HARMS", "REARS", "SATYR", "SWILL", "HEXES", "COLIC", "LEEKS", "HURLS", "YOWLS", "IVIES", "PLOPS", "MUSKS", "PAPAW", "JELLS", "BUSED", "CRUET", "BIDED", "FILCH", "ZESTS", "ROOKS", "LAXLY", "RENDS", "LOAMS", "BASKS", "SIRES", "CARPS", "POKEY", "FLITS", "MUSES", "BAWLS", "SHUCK", "VILER", "LISPS", "PEEPS", "SORER", "LOLLS", "PRUDE", "DIKED", "FLOSS", "FLOGS", "SCUMS", "DOPES", "BOGIE", "PINKY", "LEAFS", "TUBAS", "SCADS", "LOWED", "YESES", "BIKED", "QUALM", "EVENS", "CANED", "GAWKS", "WHITS", "WOOLY", "GLUTS", "ROMPS", "BESTS", "DUNCE", "CRONY", "JOIST", "TUNAS", "BONER", "MALLS", "PARCH", "AVERS", "CRAMS", "PARES", "DALLY", "BIGOT", "KALES", "FLAYS", "LEACH", "GUSHY", "POOCH", "HUGER", "SLYER", "GOLFS", "MIRES", "FLUES", "LOAFS", "ARCED", "ACNES", "NEONS", "FIEFS", "DINTS", "DAZES", "POUTS", "CORED", "YULES", "LILTS", "BEEFS", "MUTTS", "FELLS", "COWLS", "SPUDS", "LAMES", "JAWED", "DUPES", "DEADS", "BYLAW", "NOONS", "NIFTY", "CLUED", "VIREO", "GAPES", "METES", "CUTER", "MAIMS", "DROLL", "CUPID", "MAULS", "SEDGE", "PAPAS", "WHEYS", "EKING", "LOOTS", "HILTS", "MEOWS", "BEAUS", "DICES", "PEPPY", "RIPER", "FOGEY", "GISTS", "YOGAS", "GILTS", "SKEWS", "CEDES", "ZEALS", "ALUMS", "OKAYS", "ELOPE", "GRUMP", "WAFTS", "SOOTS", "BLIMP", "HEFTS", "MULLS", "HOSED", "CRESS", "DOFFS", "RUDER", "PIXIE", "WAIFS", "OUSTS", "PUCKS", "BIERS", "GULCH", "SUETS", "HOBOS", "LINTS", "BRANS", "TEALS", "GARBS", "PEWEE", "HELMS", "TURFS", "QUIPS", "WENDS", "BANES", "NAPES", "ICIER", "SWATS", "BAGEL", "HEXED", "OGRES", "GONER", "GILDS", "PYRES", "LARDS", "BIDES", "PAGED", "TALON", "FLOUT", "MEDIC", "VEALS", "PUTTS", "DIRKS", "DOTES", "TIPPY", "BLURT", "PITHS", "ACING", "BARER", "WHETS", "GAITS", "WOOLS", "DUNKS", "HEROS", "SWABS", "DIRTS", "JUTES", "HEMPS", "SURFS", "OKAPI", "CHOWS", "SHOOS", "DUSKS", "PARRY", "DECAL", "FURLS", "CILIA", "SEARS", "NOVAE", "MURKS", "WARPS", "SLUES", "LAMER", "SARIS", "WEANS", "PURRS", "DILLS", "TOGAS", "NEWTS", "MEANY", "BUNTS", "RAZES", "GOONS", "WICKS", "RUSES", "VENDS", "GEODE", "DRAKE", "JUDOS", "LOFTS", "PULPS", "LAUDS", "MUCKS", "VISES", "MOCHA", "OILED", "ROMAN", "ETHYL", "GOTTA", "FUGUE", "SMACK", "GOURD", "BUMPY", "RADIX", "FATTY", "BORAX", "CUBIT", "CACTI", "GAMMA", "FOCAL", "AVAIL", "PAPAL", "GOLLY", "ELITE", "VERSA", "BILLY", "ADIEU", "ANNUM", "HOWDY", "RHINO", "NORMS", "BOBBY", "AXIOM", "SETUP", "YOLKS", "TERNS", "MIXER", "GENRE", "KNOLL", "ABODE", "JUNTA", "GORGE", "COMBO", "ALPHA", "OVERT", "KINDA", "SPELT", "PRICK", "NOBLY", "EPHOD", "AUDIO", "MODAL", "VELDT", "WARTY", "FLUKE", "BONNY", "BREAM", "ROSIN", "BOLLS", "DOERS", "DOWNS", "BEADY", "MOTIF", "HUMPH", "FELLA", "MOULD", "CREPE", "KERNS", "ALOHA", "GLYPH", "AZURE", "RISER", "BLEST", "LOCUS", "LUMPY", "BERYL", "WANNA", "BRIER", "TUNER", "ROWDY", "MURAL", "TIMER", "CANST", "KRILL", "QUOTH", "LEMME", "TRIAD", "TENON", "AMPLY", "DEEPS", "PADRE", "LEANT", "PACER", "OCTAL", "DOLLY", "TRANS", "SUMAC", "FOAMY", "LOLLY", "GIVER", "QUIPU", "CODEX", "MANNA", "UNWED", "VODKA", "FERNY", "SALON", "DUPLE", "BORON", "REVUE", "CRIER", "ALACK", "INTER", "DILLY", "WHIST", "CULTS", "SPAKE", "RESET", "LOESS", "DECOR", "MOVER", "VERVE", "ETHIC", "GAMUT", "LINGO", "DUNNO", "ALIGN", "SISSY", "INCUR", "REEDY", "AVANT", "PIPER", "WAXER", "CALYX", "BASIL", "COONS", "SEINE", "PINEY", "LEMMA", "TRAMS", "WINCH", "WHIRR", "SAITH", "IONIC", "HEADY", "HAREM", "TUMMY", "SALLY", "SHIED", "DROSS", "FARAD", "SAVER", "TILDE", "JINGO", "BOWER", "SERIF", "FACTO", "BELLE", "INSET", "BOGUS", "CAVED", "FORTE", "SOOTY", "BONGO", "TOVES", "CREDO", "BASAL", "YELLA", "AGLOW", "GLEAN", "GUSTO", "HYMEN", "ETHOS", "TERRA", "BRASH", "SCRIP", "SWASH", "ALEPH", "TINNY", "ITCHY", "WANTA", "TRICE", "JOWLS", "GONGS", "GARDE", "BORIC", "TWILL", "SOWER", "HENRY", "AWASH", "LIBEL", "SPURN", "SABRE", "REBUT", "PENAL", "OBESE", "SONNY", "QUIRT", "MEBBE", "TACIT", "GREEK", "XENON", "HULLO", "PIQUE", "ROGER", "NEGRO", "HADST", "GECKO", "BEGET", "UNCUT", "ALOES", "LOUIS", "QUINT", "CLUNK", "RAPED", "SALVO", "DIODE", "MATEY", "HERTZ", "XYLEM", "KIOSK", "APACE", "CAWED", "PETER", "WENCH", "COHOS", "SORTA", "GAMBA", "BYTES", "TANGO", "NUTTY", "AXIAL", "ALECK", "NATAL", "CLOMP", "GORED", "SIREE", "BANDY", "GUNNY", "RUNIC", "WHIZZ", "RUPEE", "FATED", "WIPER", "BARDS", "BRINY", "STAID", "HOCKS", "OCHRE", "YUMMY", "GENTS", "SOUPY", "ROPER", "SWATH", "CAMEO", "EDGER", "SPATE", "GIMME", "EBBED", "BREVE", "THETA", "DEEMS", "DYKES", "SERVO", "TELLY", "TABBY", "TARES", "BLOCS", "WELCH", "GHOUL", "VITAE", "CUMIN", "DINKY", "BRONC", "TABOR", "TEENY", "COMER", "BORER", "SIRED", "PRIVY", "MAMMY", "DEARY", "GYROS", "SPRIT", "CONGA", "QUIRE", "THUGS", "FUROR", "BLOKE", "RUNES", "BAWDY", "CADRE", "TOXIN", "ANNUL", "EGGED", "ANION", "NODES", "PICKY", "STEIN", "JELLO", "AUDIT", "ECHOS", "FAGOT", "LETUP", "EYRIE", "FOUNT", "CAPED", "AXONS", "AMUCK", "BANAL", "RILED", "PETIT", "UMBER", "MILER", "FIBRE", "AGAVE", "BATED", "BILGE", "VITRO", "FEINT", "PUDGY", "MATER", "MANIC", "UMPED", "PESKY", "STREP", "SLURP", "PYLON", "PUREE", "CARET", "TEMPS", "NEWEL", "YAWNS", "SEEDY", "TREED", "COUPS", "RANGY", "BRADS", "MANGY", "LONER", "CIRCA", "TIBIA", "AFOUL", "MOMMY", "TITER", "CARNE", "KOOKY", "MOTES", "AMITY", "SUAVE", "HIPPO", "CURVY", "SAMBA", "NEWSY", "ANISE", "IMAMS", "TULLE", "AWAYS", "LIVEN", "HALLO", "WALES", "OPTED", "CANTO", "IDYLL", "BODES", "CURIO", "WRACK", "HIKER", "CHIVE", "YOKEL", "DOTTY", "DEMUR", "CUSPS", "SPECS", "QUADS", "LAITY", "TONER", "DECRY", "WRITS", "SAUTE", "CLACK", "AUGHT", "LOGOS", "TIPSY", "NATTY", "DUCAL", "BIDET", "BULGY", "METRE", "LUSTS", "UNARY", "GOETH", "BALER", "SITED", "SHIES", "HASPS", "BRUNG", "HOLED", "SWANK", "LOOKY", "MELEE", "HUFFY", "LOAMY", "PIMPS", "TITAN", "BINGE", "SHUNT", "FEMUR", "LIBRA", "SEDER", "HONED", "ANNAS", "COYPU", "SHIMS", "ZOWIE", "JIHAD", "SAVVY", "NADIR", "BASSO", "MONIC", "MANED", "MOUSY", "OMEGA", "LAVER", "PRIMA", "PICAS", "FOLIO", "MECCA", "REALS", "TROTH", "TESTY", "BALKY", "CRIMP", "CHINK", "ABETS", "SPLAT", "ABACI", "VAUNT", "CUTIE", "PASTY", "MORAY", "LEVIS", "RATTY", "ISLET", "JOUST", "MOTET", "VIRAL", "NUKES", "GRADS", "COMFY", "VOILA", "WOOZY", "BLUED", "WHOMP", "SWARD", "METRO", "SKEET", "CHINE", "AERIE", "BOWIE", "TUBBY", "EMIRS", "COATI", "UNZIP", "SLOBS", "TRIKE", "FUNKY", "DUCAT", "DEWEY", "SKOAL", "WADIS", "OOMPH", "TAKER", "MINIM", "GETUP", "STOIC", "SYNOD", "RUNTY", "FLYBY", "BRAZE", "INLAY", "VENUE", "LOUTS", "PEATY", "ORLON", "HUMPY", "RADON", "BEAUT", "RASPY", "UNFED", "CRICK", "NAPPY", "VIZOR", "YIPES", "REBUS", "DIVOT", "KIWIS", "VETCH", "SQUIB", "SITAR", "KIDDO", "DYERS", "COTTA", "MATZO", "LAGER", "ZEBUS", "CRASS", "DACHA", "KNEED", "DICTA", "FAKIR", "KNURL", "RUNNY", "UNPIN", "JULEP", "GLOBS", "NUDES", "SUSHI", "TACKY", "STOKE", "KAPUT", "BUTCH", "HULAS", "CROFT", "ACHOO", "GENII", "NODAL", "OUTGO", "SPIEL", "VIOLS", "FETID", "CAGEY", "FUDGY", "EPOXY", "LEGGY", "HANKY", "LAPIS", "FELON", "BEEFY", "COOTS", "MELBA", "CADDY", "SEGUE", "BETEL", "FRIZZ", "DREAR", "KOOKS", "TURBO", "HOAGY", "MOULT", "HELIX", "ZONAL", "ARIAS", "NOSEY", "PAEAN", "LACEY", "BANNS", "SWAIN", "FRYER", "RETCH", "TENET", "GIGAS", "WHINY", "OGLED", "RUMEN", "BEGOT", "CRUSE", "ABUTS", "RIVEN", "BALKS", "SINES", "SIGMA", "ABASE", "ENNUI", "GORES", "UNSET", "AUGUR", "SATED", "ODIUM", "LATIN", "DINGS", "MOIRE", "SCION", "HENNA", "KRAUT", "DICKS", "LIFER", "PRIGS", "BEBOP", "GAGES", "GAZER", "FANNY", "GIBES", "AURAL", "TEMPI", "HOOCH", "RAPES", "SNUCK", "HARTS", "TECHS", "EMEND", "NINNY", "GUAVA", "SCARP", "LIEGE", "TUFTY", "SEPIA", "TOMES", "CAROB", "EMCEE", "PRAMS", "POSER", "VERSO", "HUBBA", "JOULE", "BAIZE", "BLIPS", "SCRIM", "CUBBY", "CLAVE", "WINOS", "REARM", "LIENS", "LUMEN", "CHUMP", "NANNY", "TRUMP", "FICHU", "CHOMP", "HOMOS", "PURTY", "MASER", "WOOSH", "PATSY", "SHILL", "RUSKS", "AVAST", "SWAMI", "BODED", "AHHHH", "LOBED", "NATCH", "SHISH", "TANSY", "SNOOT", "PAYER", "ALTHO", "SAPPY", "LAXER", "HUBBY", "AEGIS", "RILES", "DITTO", "JAZZY", "DINGO", "QUASI", "SEPTA", "PEAKY", "LORRY", "HEERD", "BITTY", "PAYEE", "SEAMY", "APSES", "IMBUE", "BELIE", "CHARY", "SPOOF", "PHYLA", "CLIME", "BABEL", "WACKY", "SUMPS", "SKIDS", "KHANS", "CRYPT", "INURE", "NONCE", "OUTEN", "FAIRE", "HOOEY", "ANOLE", "KAZOO", "CALVE", "LIMBO", "ARGOT", "DUCKY", "FAKER", "VIBES", "GASSY", "UNLIT", "NERVY", "FEMME", "BITER", "FICHE", "BOORS", "GAFFE", "SAXES", "RECAP", "SYNCH", "FACIE", "DICEY", "OUIJA", "HEWER", "LEGIT", "GURUS", "EDIFY", "TWEAK", "CARON", "TYPOS", "RERUN", "POLLY", "SURDS", "HAMZA", "NULLS", "HATER", "LEFTY", "MOGUL", "MAFIA", "DEBUG", "PATES", "BLABS", "SPLAY", "TALUS", "PORNO", "MOOLA", "NIXED", "KILOS", "SNIDE", "HORSY", "GESSO", "JAGGY", "TROVE", "NIXES", "CREEL", "PATER", "IOTAS", "CADGE", "SKYED", "HOKUM", "FURZE", "ANKHS", "CURIE", "NUTSY", "HILUM", "REMIX", "ANGST", "BURLS", "JIMMY", "VEINY", "TRYST", "CODON", "BEFOG", "GAMED", "FLUME", "AXMAN", "DOOZY", "LUBES", "RHEAS", "BOZOS", "BUTYL", "KELLY", "MYNAH", "JOCKS", "DONUT", "AVIAN", "WURST", "CHOCK", "QUASH", "QUALS", "HAYED", "BOMBE", "CUSHY", "SPACY", "PUKED", "LEERY", "THEWS", "PRINK", "AMENS", "TESLA", "INTRO", "FIVER", "FRUMP", "CAPOS", "OPINE", "CODER", "NAMER", "JOWLY", "PUKES", "HALED", "CHARD", "DUFFS", "BRUIN", "REUSE", "WHANG", "TOONS", "FRATS", "SILTY", "TELEX", "CUTUP", "NISEI", "NEATO", "DECAF", "SOFTY", "BIMBO", "ADLIB", "LOONY", "SHOED", "AGUES", "PEEVE", "NOWAY", "GAMEY", "SARGE", "RERAN", "EPACT", "POTTY", "CONED", "UPEND", "NARCO", "IKATS", "WHORL", "JINKS", "TIZZY", "WEEPY", "POSIT", "MARGE", "VEGAN", "CLOPS", "NUMBS", "REEKS", "RUBES", "ROWER", "BIPED", "TIFFS", "HOCUS", "HAMMY", "BUNCO", "FIXIT", "TYKES", "CHAWS", "YUCKY", "HOKEY", "RESEW", "MAVEN", "ADMAN", "SCUZZ", "SLOGS", "SOUSE", "NACHO", "MIMED", "MELDS", "BOFFO", "DEBIT", "PINUP", "VAGUS", "GULAG", "RANDY", "BOSUN", "EDUCE", "FAXES", "AURAS", "PESTO", "ANTSY", "BETAS", "FIZZY", "DORKY", "SNITS", "MOXIE", "THANE", "MYLAR", "NOBBY", "GAMIN", "GOUTY", "ESSES", "GOYIM", "PANED", "DRUID", "JADES", "REHAB", "GOFER", "TZARS", "OCTET", "HOMED", "SOCKO", "DORKS", "EARED", "ANTED", "ELIDE", "FAZES", "OXBOW", "DOWSE", "SITUS", "MACAW", "SCONE", "DRILY", "HYPER", "SALSA", "MOOCH", "GATED", "UNJAM", "LIPID", "MITRE", "VENAL", "KNISH", "RITZY", "DIVAS", "TORUS", "MANGE", "DIMER", "RECUT", "MESON", "WINED", "FENDS", "PHAGE", "FIATS", "CAULK", "CAVIL", "PANTY", "ROANS", "BILKS", "HONES", "BOTCH", "ESTOP", "SULLY", "SOOTH", "GELDS", "AHOLD", "RAPER", "PAGER", "FIXER", "INFIX", "HICKS", "TUXES", "PLEBE", "TWITS", "ABASH", "TWIXT", "WACKO", "PRIMP", "NABLA", "GIRTS", "MIFFS", "EMOTE", "XEROX", "REBID", "SHAHS", "RUTTY", "GROUT", "GRIFT", "DEIFY", "BIDDY", "KOPEK", "SEMIS", "BRIES", "ACMES", "PITON", "HUSSY", "TORTS", "DISCO", "WHORE", "BOOZY", "GIBED", "VAMPS", "AMOUR", "SOPPY", "GONZO", "DURST", "WADER", "TUTUS", "PERMS", "CATTY", "GLITZ", "BRIGS", "NERDS", "BARMY", "GIZMO", "OWLET", "SAYER", "MOLLS", "SHARD", "WHOPS", "COMPS", "CORER", "COLAS", "MATTE", "DROID", "PLOYS", "VAPID", "CAIRN", "DEISM", "MIXUP", "YIKES", "PROSY", "RAKER", "FLUBS", "WHISH", "REIFY", "CRAPS", "SHAGS", "CLONE", "HAZED", "MACHO", "RECTO", "REFIX", "DRAMS", "BIKER", "AQUAS", "PORKY", "DOYEN", "EXUDE", "GOOFS", "DIVVY", "NOELS", "JIVED", "HULKY", "CAGER", "HARPY", "OLDIE", "VIVAS", "ADMIX", "CODAS", "ZILCH", "DEIST", "ORCAS", "RETRO", "PILAF", "PARSE", "RANTS", "ZINGY", "TODDY", "CHIFF", "MICRO", "VEEPS", "GIRLY", "NEXUS", "DEMOS", "BIBBS", "ANTES", "LULUS", "GNARL", "ZIPPY", "IVIED", "EPEES", "WIMPS", "TROMP", "GRAIL", "YOYOS", "POUFS", "HALES", "ROUST", "CABAL", "RAWER", "PAMPA", "MOSEY", "KEFIR", "BURGS", "UNMET", "CUSPY", "BOOBS", "BOONS", "HYPES", "DYNES", "NARDS", "LANAI", "YOGIS", "SEPAL", "QUARK", "TOKED", "PRATE", "AYINS", "HAWED", "SWIGS", "VITAS", "TOKER", "DOPER", "BOSSA", "LINTY", "FOIST", "MONDO", "STASH", "KAYOS", "TWERP", "ZESTY", "CAPON", "WIMPY", "REWED", "FUNGO", "TAROT", "FROSH", "KABOB", "PINKO", "REDID", "MIMEO", "HEIST", "TARPS", "LAMAS", "SUTRA", "DINAR", "WHAMS", "BUSTY", "SPAYS", "MAMBO", "NABOB", "PREPS", "ODOUR", "CABBY", "CONKS", "SLUFF", "DADOS", "HOURI", "SWART", "BALMS", "GUTSY", "FAXED", "EGADS", "PUSHY", "RETRY", "AGORA", "DRUBS", "DAFFY", "CHITS", "MUFTI", "KARMA", "LOTTO", "TOFFS", "BURPS", "DEUCE", "ZINGS", "KAPPA", "CLADS", "DOGGY", "DUPER", "SCAMS", "OGLER", "MIMES", "THROE", "ZETAS", "WALED", "PROMO", "BLATS", "MUFFS", "OINKS", "VIAND", "COSET", "FINKS", "FADDY", "MINIS", "SNAFU", "SAUNA", "USURY", "MUXES", "CRAWS", "STATS", "CONDO", "COXES", "LOOPY", "DORMS", "ASCOT", "DIPPY", "EXECS", "DOPEY", "ENVOI", "UMPTY", "GISMO", "FAZED", "STROP", "JIVES", "SLIMS", "BATIK", "PINGS", "SONLY", "LEGGO", "PEKOE", "PRAWN", "LUAUS", "CAMPY", "OODLE", "PREXY", "PROMS", "TOUTS", "OGLES", "TWEET", "TOADY", "NAIAD", "HIDER", "NUKED", "FATSO", "SLUTS", "OBITS", "NARCS", "TYROS", "DELIS", "WOOER", "HYPED", "POSET", "BYWAY", "TEXAS", "SCROD", "AVOWS", "FUTON", "TORTE", "TUPLE", "CAROM", "KEBAB", "TAMPS", "JILTS", "DUALS", "ARTSY", "REPRO", "MODEM", "TOPED", "PSYCH", "SICKO", "KLUTZ", "TARNS", "COXED", "DRAYS", "CLOYS", "ANDED", "PIKER", "AIMER", "SURAS", "LIMOS", "FLACK", "HAPAX", "DUTCH", "MUCKY", "SHIRE", "KLIEG", "STAPH", "LAYUP", "TOKES", "AXING", "TOPER", "DUVET", "COWRY", "PROFS", "BLAHS", "ADDLE", "SUDSY", "BATTY", "COIFS", "SUETY", "GABBY", "HAFTA", "PITAS", "GOUDA", "DEICE", "TAUPE", "TOPES", "DUCHY", "NITRO", "CARNY", "LIMEY", "ORALS", "HIRER", "TAXER", "ROILS", "RUBLE", "ELATE", "DOLOR", "WRYER", "SNOTS", "QUAIS", "COKED", "GIMEL", "GORSE", "MINAS", "GOEST", "AGAPE", "MANTA", "JINGS", "ILIAC", "ADMEN", "OFFEN", "CILLS", "OFFAL", "LOTTA", "BOLAS", "THWAP", "ALWAY", "BOGGY", "DONNA", "LOCOS", "BELAY", "GLUEY", "BITSY", "MIMSY", "HILAR", "OUTTA", "VROOM", "FETAL", "RATHS", "RENAL", "DYADS", "CROCS", "VIRES", "CULPA", "KIVAS", "FEIST", "TEATS", "THATS", "YAWLS", "WHENS", "ABACA", "OHHHH", "APHIS", "FUSTY", "ECLAT", "PERDU", "MAYST", "EXEAT", "MOLLY", "SUPRA", "WETLY", "PLASM", "BUFFA", "SEMEN", "PUKKA", "TAGUA", "PARAS", "STOAT", "SECCO", "CARTE", "HAUTE", "MOLAL", "SHADS", "FORMA", "OVOID", "PIONS", "MODUS", "BUENO", "RHEUM", "SCURF", "PARER", "EPHAH", "DOEST", "SPRUE", "FLAMS", "MOLTO", "DIETH", "CHOOS", "MIKED", "BRONX", "GOOPY", "BALLY", "PLUMY", "MOONY", "MORTS", "YOURN", "BIPOD", "SPUME", "ALGAL", "AMBIT", "MUCHO", "SPUED", "DOZER", "HARUM", "GROAT", "SKINT", "LAUDE", "THRUM", "PAPPY", "ONCET", "RIMED", "GIGUE", "LIMED", "PLEIN", "REDLY", "HUMPF", "LITES", "SEEST", "GREBE", "ABSIT", "THANX", "PSHAW", "YAWPS", "PLATS", "PAYED", "AREAL", "TILTH", "YOUSE", "GWINE", "THEES", "WATSA", "LENTO", "SPITZ", "YAWED", "GIPSY", "SPRAT", "CORNU", "AMAHS", "BLOWY", "WAHOO", "LUBRA", "MECUM", "WHOOO", "COQUI", "SABRA", "EDEMA", "MRADS", "DICOT", "ASTRO", "KITED", "OUZEL", "DIDOS", "GRATA", "BONNE", "AXMEN", "KLUNK", "SUMMA", "LAVES", "PURLS", "YAWNY", "TEARY", "MASSE", "LARGO", "BAZAR", "PSSST", "SYLPH", "LULAB", "TOQUE", "FUGIT", "PLUNK", "ORTHO", "LUCRE", "COOCH", "WHIPT", "FOLKY", "TYRES", "WHEEE", "CORKY", "INJUN", "SOLON", "DIDOT", "KERFS", "RAYED", "WASSA", "CHILE", "BEGAT", "NIPPY", "LITRE", "MAGNA", "REBOX", "HYDRO", "MILCH", "BRENT", "GYVES", "LAZED", "FEUED", "MAVIS", "INAPT", "BAULK", "CASUS", "SCRUM", "WISED", "FOSSA", "DOWER", "KYRIE", "BHOYS", "SCUSE", "FEUAR", "OHMIC", "JUSTE", "UKASE", "BEAUX", "TUSKY", "ORATE", "MUSTA", "LARDY", "INTRA", "QUIFF", "EPSOM", "NEATH", "OCHER", "TARED", "HOMME", "MEZZO", "CORMS", "PSOAS", "BEAKY", "TERRY", "INFRA", "SPIVS", "TUANS", "BELLI", "BERGS", "ANIMA", "WEIRS", "MAHUA", "SCOPS", "MANSE", "TITRE", "CURIA", "KEBOB", "CYCAD", "TALKY", "FUCKS", "TAPIS", "AMIDE", "DOLCE", "SLOES", "JAKES", "RUSSE", "BLASH", "TUTTI", "PRUTA", "PANGA", "BLEBS", "TENCH", "SWARF", "HEREM", "MISSY", "MERSE", "PAWKY", "LIMEN", "VIVRE", "CHERT", "UNSEE", "TIROS", "BRACK", "FOOTS", "WELSH", "FOSSE", "KNOPS", "ILEUM", "NOIRE", "FIRMA", "PODGY", "LAIRD", "THUNK", "SHUTE", "ROWAN", "SHOJI", "POESY", "UNCAP", "FAMES", "GLEES", "COSTA", "TURPS", "FORES", "SOLUM", "IMAGO", "BYRES", "FONDU", "CONEY", "POLIS", "DICTU", "KRAAL", "SHERD", "MUMBO", "WROTH", "CHARS", "UNBOX", "VACUO", "SLUED", "WEEST", "HADES", "WILED", "SYNCS", "MUSER", "EXCON", "HOARS", "SIBYL", "PASSE", "JOEYS", "LOTSA", "LEPTA", "SHAYS", "BOCKS", "ENDUE", "DARER", "NONES", "ILEUS", "PLASH", "BUSBY", "WHEAL", "BUFFO", "YOBBO", "BILES", "POXES", "ROOTY", "LICIT", "TERCE", "BROMO", "HAYEY", "DWEEB", "IMBED", "SARAN", "BRUIT", "PUNKY", "SOFTS", "BIFFS", "LOPPY", "AGARS", "AQUAE", "LIVRE", "BIOME", "BUNDS", "SHEWS", "DIEMS", "GINNY", "DEGUM", "POLOS", "DESEX", "UNMAN", "DUNGY", "VITAM", "WEDGY", "GLEBE", "APERS", "RIDGY", "ROIDS", "WIFEY", "VAPES", "WHOAS", "BUNKO", "YOLKY", "ULNAS", "REEKY", "BODGE", "BRANT", "DAVIT", "DEQUE", "LIKER", "JENNY", "TACTS", "FULLS", "TREAP", "LIGNE", "ACKED", "REFRY", "VOWER", "AARGH", "CHURL", "MOMMA", "GAOLS", "WHUMP", "ARRAS", "MARLS", "TILER", "GROGS", "MEMES", "MIDIS", "TIDED", "HALER", "DUCES", "TWINY", "POSTE", "UNRIG", "PRISE", "DRABS", "QUIDS", "FACER", "SPIER", "BARIC", "GEOID", "REMAP", "TRIER", "GUNKS", "STENO", "STOMA", "AIRER", "OVATE", "TORAH", "APIAN", "SMUTS", "POCKS", "YURTS", "EXURB", "DEFOG", "NUDER", "BOSKY", "NIMBI", "MOTHY", "JOYED", "LABIA", "PARDS", "JAMMY", "BIGLY", "FAXER", "HOPPY", "NURBS", "COTES", "DISHY", "VISED", "CELEB", "PISMO", "CASAS", "WITHS", "DODGY", "SCUDI", "MUNGS", "MUONS", "UREAS", "IOCTL", "UNHIP", "KRONE", "SAGER", "VERST", "EXPAT", "GRONK", "UVULA", "SHAWM", "BILGY", "BRAES", "CENTO", "WEBBY", "LIPPY", "GAMIC", "LORDY", "MAZED", "TINGS", "SHOAT", "FAERY", "WIRER", "DIAZO", "CARER", "RATER", "GREPS", "RENTE", "ZLOTY", "VIERS", "UNAPT", "POOPS", "FECAL", "KEPIS", "TAXON", "EYERS", "WONTS", "SPINA", "STOAE", "YENTA", "POOEY", "BURET", "JAPAN", "BEDEW", "HAFTS", "SELFS", "OARED", "HERBY", "PRYER", "OAKUM", "DINKS", "TITTY", "SEPOY", "PENES", "FUSEE", "WINEY", "GIMPS", "NIHIL", "RILLE", "GIBER", "OUSEL", "UMIAK", "CUPPY", "HAMES", "SHITS", "AZINE", "GLADS", "TACET", "BUMPH", "COYER", "HONKY", "GAMER", "GOOKY", "WASPY", "SEDGY", "BENTS", "VARIA", "DJINN", "JUNCO", "PUBIC", "WILCO", "LAZES", "IDYLS", "LUPUS", "RIVES", "SNOOD", "SCHMO", "SPAZZ", "FINIS", "NOTER", "PAVAN", "ORBED", "BATES", "PIPET", "BADDY", "GOERS", "SHAKO", "STETS", "SEBUM", "SEETH", "LOBAR", "RAVER", "AJUGA", "RICED", "VELDS", "DRIBS", "VILLE", "DHOWS", "UNSEW", "HALMA", "KRONA", "LIMBY", "JIFFS", "TREYS", "BAUDS", "PFFFT", "MIMER", "PLEBS", "CANER", "JIBER", "CUPPA", "WASHY", "CHUFF", "UNARM", "YUKKY", "STYES", "WAKER", "FLAKS", "MACES", "RIMES", "GIMPY", "GUANO", "LIRAS", "KAPOK", "SCUDS", "BWANA", "ORING", "AIDER", "PRIER", "KLUGY", "MONTE", "GOLEM", "VELAR", "FIRER", "PIETA", "UMBEL", "CAMPO", "UNPEG", "FOVEA", "ABEAM", "BOSON", "ASKER", "GOTHS", "VOCAB", "VINED", "TROWS", "TIKIS", "LOPER", "INDIE", "BOFFS", "SPANG", "GRAPY", "TATER", "ICHOR", "KILTY", "LOCHS", "SUPES", "DEGAS", "FLICS", "TORSI", "BETHS", "WEBER", "RESAW", "LAWNY", "COVEN", "MUJIK", "RELET", "THERM", "HEIGH", "SHNOR", "TRUED", "ZAYIN", "LIEST", "BARFS", "BASSI", "QOPHS", "ROILY", "FLABS", "PUNNY", "OKRAS", "HANKS", "DIPSO", "NERFS", "FAUNS", "CALLA", "PSEUD", "LURER", "MAGUS", "OBEAH", "ATRIA", "TWINK", "PALMY", "POCKY", "PENDS", "RECTA", "PLONK", "SLAWS", "KEENS", "NICAD", "PONES", "INKER", "WHEWS", "GROKS", "MOSTS", "TREWS", "ULNAR", "GYPPY", "COCAS", "EXPOS", "ERUCT", "OILER", "VACUA", "DRECK", "DATER", "ARUMS", "TUBAL", "VOXEL", "DIXIT", "BEERY", "ASSAI", "LADES", "ACTIN", "GHOTI", "BUZZY", "MEADS", "GRODY", "RIBBY", "CLEWS", "CREME", "EMAIL", "PYXIE", "KULAK", "BOCCI", "RIVED", "DUDDY", "HOPER", "LAPIN", "WONKS", "PETRI", "PHIAL", "FUGAL", "HOLON", "BOOMY", "DUOMO", "MUSOS", "SHIER", "HAYER", "PORGY", "HIVED", "LITHO", "FISTY", "STAGY", "LUVYA", "MARIA", "SMOGS", "ASANA", "YOGIC", "SLOMO", "FAWNY", "AMINE", "WEFTS", "GONAD", "TWIRP", "BRAVA", "PLYER", "FERMI", "LOGES", "NITER", "REVET", "UNATE", "GYVED", "TOTTY", "ZAPPY", "HONER", "GIROS", "DICER", "CALKS", "LUXES", "MONAD", "CRUFT", "QUOIN", "FUMER", "AMPED", "SHLEP", "VINCA", "YAHOO", "VULVA", "ZOOEY", "DRYAD", "NIXIE", "MOPER", "IAMBS", "LUNES", "NUDIE", "LIMNS", "WEALS", "NOHOW", "MIAOW", "GOUTS", "MYNAS", "MAZER", "KIKES", "OXEYE", "STOUP", "JUJUS", "DEBAR", "PUBES", "TAELS", "DEFUN", "RANDS", "BLEAR", "PAVER", "GOOSY", "SPROG", "OLEOS", "TOFFY", "PAWER", "MACED", "CRITS", "KLUGE", "TUBED", "SAHIB", "GANEF", "SCATS", "SPUTA", "VANED", "ACNED", "TAXOL", "PLINK", "OWETH", "TRIBS", "RESAY", "BOULE", "THOUS", "HAPLY", "GLANS", "MAXIS", "BEZEL", "ANTIS", "PORKS", "QUOIT", "ALKYD", "GLARY", "BEAMY", "HEXAD", "BONKS", "TECUM", "KERBS", "FILAR", "FRIER", "REDUX", "ABUZZ", "FADER", "SHOER", "COUTH", "TRUES", "GUYED", "GOONY", "BOOKY", "FUZES", "HURLY", "GENET", "HODAD", "CALIX", "FILER", "PAWLS", "IODIC", "UTERO", "HENGE", "UNSAY", "LIERS", "PIING", "WEALD", "SEXED", "FOLIC", "POXED", "CUNTS", "ANILE", "KITHS", "BECKS", "TATTY", "PLENA", "REBAR", "ABLED", "TOYER", "ATTAR", "TEAKS", "AIOLI", "AWING", "ANENT", "FECES", "REDIP", "WISTS", "PRATS", "MESNE", "MUTER", "SMURF", "OWEST", "BAHTS", "LOSSY", "FTPED", "HUNKY", "HOERS", "SLIER", "SICKS", "FATLY", "DELFT", "HIVER", "HIMBO", "PENGO", "BUSKS", "LOXES", "ZONKS", "ILIUM", "APORT", "IKONS", "MULCT", "REEVE", "CIVVY", "CANNA", "BARFY", "KAIAK", "SCUDO", "KNOUT", "GAPER", "BHANG", "PEASE", "UTERI", "LASES", "PATEN", "RASAE", "AXELS", "STOAS", "OMBRE", "STYLI", "GUNKY", "HAZER", "KENAF", "AHOYS", "AMMOS", "WEENY", "URGER", "KUDZU", "PAREN", "BOLOS", "FETOR", "NITTY", "TECHY", "LIETH", "SOMAS", "DARKY", "VILLI", "GLUON", "JANES", "CANTS", "FARTS", "SOCLE", "JINNS", "RUING", "SLILY", "RICER", "HADDA", "WOWEE", "RICES", "NERTS", "CAULS", "SWIVE", "LILTY", "MICKS", "ARITY", "PASHA", "FINIF", "OINKY", "GUTTY", "TETRA", "WISES", "WOLDS", "BALDS", "PICOT", "WHATS", "SHIKI", "BUNGS", "SNARF", "LEGOS", "DUNGS", "STOGY", "BERMS", "TANGS", "VAILS", "ROODS", "MOREL", "SWARE", "ELANS", "LATUS", "GULES", "RAZER", "DOXIE", "BUENA", "OVERS", "GUTTA", "ZINCS", "NATES", "KIRKS", "TIKES", "DONEE", "JERRY", "MOHEL", "CEDER", "DOGES", "UNMAP", "FOLIA", "RAWLY", "SNARK", "TOPOI", "CEILS", "IMMIX", "YORES", "DIEST", "BUBBA", "POMPS", "FORKY", "TURDY", "LAWZY", "POOHS", "WORTS", "GLOMS", "BEANO", "MULEY", "BARKY", "TUNNY", "AURIC", "FUNKS", "GAFFS", "CORDY", "CURDY", "LISLE", "TORIC", "SOYAS", "REMAN", "MUNGY", "CARPY", "APISH", "OATEN", "GAPPY", "AURAE", "BRACT", "ROOKY", "AXLED", "BURRY", "SIZER", "PROEM", "TURFY", "IMPRO", "MASHY", "MIENS", "NONNY", "OLIOS", "GROOK", "SATES", "AGLEY", "CORGI", "DASHY", "DOSER", "DILDO", "APSOS", "XORED", "LAKER", "PLAYA", "SELAH", "MALTY", "DULSE", "FRIGS", "DEMIT", "WHOSO", "RIALS", "SAWER", "SPICS", "BEDIM", "SNUGS", "FANIN", "AZOIC", "ICERS", "SUERS", "WIZEN", "KOINE", "TOPOS", "SHIRR", "RIFER", "FERAL", "LADED", "LASED", "TURDS", "SWEDE", "EASTS", "COZEN", "UNHIT", "PALLY", "AITCH", "SEDUM", "COPER", "RUCHE", "GEEKS", "SWAGS", "ETEXT", "ALGIN", "OFFED", "NINJA", "HOLER", "DOTER", "TOTER", "BESOT", "DICUT", "MACER", "PEENS", "PEWIT", "REDOX", "POLER", "YECCH", "FLUKY", "DOETH", "TWATS", "CRUDS", "BEBUG", "BIDER", "STELE", "HEXER", "WESTS", "GLUER", "PILAU", "ABAFT", "WHELM", "LACER", "INODE", "TABUS", "GATOR", "CUING", "REFLY", "LUTED", "CUKES", "BAIRN", "BIGHT", "ARSES", "CRUMP", "LOGGY", "BLINI", "SPOOR", "TOYON", "HARKS", "WAZOO", "FENNY", "NAVES", "KEYER", "TUFAS", "MORPH", "RAJAS", "TYPAL", "SPIFF", "OXLIP", "UNBAN", "MUSSY", "FINNY", "RIMER", "LOGIN", "MOLAS", "CIRRI", "HUZZA", "AGONE", "UNSEX", "UNWON", "PEATS", "TOILE", "ZOMBI", "DEWED", "NOOKY", "ALKYL", "IXNAY", "DOVEY", "HOLEY", "CUBER", "AMYLS", "PODIA", "CHINO", "APNEA", "PRIMS", "LYCRA", "JOHNS", "PRIMO", "FATWA", "EGGER", "HEMPY", "SNOOK", "HYING", "FUZED", "BARMS", "CRINK", "MOOTS", "YERBA", "RHUMB", "UNARC", "DIRER", "MUNGE", "ELAND", "NARES", "WRIER", "NODDY", "ATILT", "JUKES", "ENDER", "THENS", "UNFIX", "DOGGO", "ZOOKS", "DIDDY", "SHMOO", "BRUSK", "PREST", "CURER", "PASTS", "KELPY", "BOCCE", "KICKY", "TAROS", "LINGS", "DICKY", "NERDY", "ABEND", "STELA", "BIGGY", "LAVED", "BALDY", "PUBIS", "GOOKS", "WONKY", "STIED", "HYPOS", "ASSED", "SPUMY", "OSIER", "ROBLE", "RUMBA", "BIFFY", "PUPAL"};
    List<string> allWordList = new List<string>();
    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    List<Vector3> rotations = new List<Vector3>();
    List<Vector3> rotations2 = new List<Vector3>();
    int firstRotation;
    public int lettersTyped = 0, wordsEntered = 0;
    public string typedWord = "";
    public string theWord = "";
    float cntdnw = 120.0f, xTimer = 3.0F, roundTimer = 3.0F, smooth, letterSpawn = 0.4F;
    GameObject timer, flg, flg2;
    TMPro.TextMeshProUGUI timerText;
    bool isPlayTime, flag, xActive, nextRound, canType;
    int currentRound;
    public AudioSource audio, audio2;
    string sideWord = "WORDLERUSH";
    Color sideColor;
    // Start is called before the first frame update
    void Start()
    {
        theWord = wordList[Random.Range(0, wordList.Length)];
        timer = GameObject.Find("Timer");
        timerText = timer.GetComponent<TMPro.TextMeshProUGUI>();
        isPlayTime = false;
        flag = false;
        xActive = false;
        nextRound = false;
        currentRound = 1;
        canType = true;
        audio.Play();
        for (int i = 0; i < allWordListSource.Length; i++)
        {
            allWordList.Add(allWordListSource[i]);
        }
        for (int i = 0; i < wordList.Length; i++)
        {
            if (!allWordList.Contains(wordList[i].ToUpper()))
            {
                allWordList.Add(wordList[i].ToUpper());
            }
        }
        flg = GameObject.Find("FallingLetterGroup");
        flg2 = GameObject.Find("FallingLetterGroup2");
        smooth = Time.deltaTime * 15.0F;
        firstRotation = Random.Range(-360, 360);
        Application.targetFrameRate = 100;
        sideColor = new Color(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            if (!audio2.isPlaying)
            {
                audio2.Play();
            }
        }
        if (!audio2.isPlaying)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        if (nextRound)
        {
            if (roundTimer > 0)
            {
                roundTimer -= Time.deltaTime;
            } else
            {
                nextRound = false;
                currentRound++;
                isPlayTime = true;
                resetBoard();
                GameObject roundObj = GameObject.Find("Round");
                TMPro.TextMeshProUGUI roundText = roundObj.GetComponent<TMPro.TextMeshProUGUI>();
                roundText.text = roundText.text.Substring(0, roundText.text.IndexOf(" ") + 1) + currentRound.ToString();
            }
        }
        if (xActive)
        {
            if (xTimer > 0)
            {
                xTimer -= Time.deltaTime;
                GameObject X = GameObject.Find("Cross");
                TMPro.TextMeshProUGUI XText = X.GetComponent<TMPro.TextMeshProUGUI>();
                XText.alpha -= .4F * Time.deltaTime;

            } else
            {
                xActive = false;

            }
        }
        if (letterSpawn > 0)
        {
            letterSpawn -= Time.deltaTime;
        } else
        {
            letterSpawn = 0.4F;
            GameObject newLetter = new GameObject();
            newLetter.AddComponent<TMPro.TextMeshProUGUI>();
            newLetter.GetComponent<TMPro.TextMeshProUGUI>().text = alphabet[Random.Range(0, 26)];
            newLetter.transform.SetParent(GameObject.Find("FallingLetterGroup").transform);
            newLetter.transform.position = new Vector3(GameObject.Find("Reference").transform.position.x, 585, 0);
            newLetter.AddComponent<SpriteRenderer>();
            RectTransform rt = newLetter.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(50, 50);
            newLetter.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            newLetter.GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            newLetter.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 48;
            newLetter.GetComponent<TMPro.TextMeshProUGUI>().color = sideColor;
            if (sideWord.Length > 0)
            {
                newLetter.GetComponent<TMPro.TextMeshProUGUI>().text = sideWord.Substring(0, 1);
            }
            GameObject newLetter2 = new GameObject();
            newLetter2.transform.position = new Vector3(-1 * GameObject.Find("Reference").transform.position.x, 585, 0);
            newLetter2.AddComponent<TMPro.TextMeshProUGUI>();
            newLetter2.GetComponent<TMPro.TextMeshProUGUI>().text = alphabet[Random.Range(0, 26)];
            newLetter2.transform.SetParent(GameObject.Find("FallingLetterGroup2").transform);
            newLetter2.AddComponent<SpriteRenderer>();
            RectTransform rt2 = newLetter.GetComponent<RectTransform>();
            rt2.sizeDelta = new Vector2(50, 50);
            newLetter2.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            newLetter2.GetComponent<TMPro.TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            newLetter2.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 48;
            newLetter2.GetComponent<TMPro.TextMeshProUGUI>().color = sideColor;
            if (sideWord.Length > 0)
            {
                newLetter2.GetComponent<TMPro.TextMeshProUGUI>().text = sideWord.Substring(0, 1);
                if (sideWord.Length == 1)
                {
                    sideWord = "";
                    sideColor = new Color(1, 1, 1);
                } else
                {
                    sideWord = sideWord.Substring(1, sideWord.Length - 1);
                }
            }
            //newLetter.transform.localScale = new Vector3(55, 69, 1);
            rotations.Add(new Vector3(0, 0, Random.Range(-360, 360)));
            rotations2.Add(new Vector3(0, 0, Random.Range(-360, 360)));
        }
        updatePosition();
        if (isPlayTime)
        {
            if (cntdnw > 0)
            {
                cntdnw -= Time.deltaTime;
            }
            int b = (int) System.Math.Round(cntdnw, 0);
            int minute = b / 60;
            int second = b % 60;
            string seconds = second.ToString();
            if (second < 10)
            {
                seconds = "0" + seconds;
            }
            timerText.text = minute.ToString() + ":" + seconds;
            if (cntdnw < 0)
            {
                GameObject box = GameObject.Find("Correctness");
                TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
                text.text = "FAILURE\n\nWord: " + theWord.ToUpper();
                sideWord = "FAILURE";
                sideColor = new Color(1, 0, 0);
                text.color = new Color(256, 0, 0);
                isPlayTime = false;
                canType = false;
                flag = true;
            }
        }
        UpdateText();

    }

    void UpdateText()
    {
        if (canType)
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
                    if (isWord() == true)
                    {
                        GameObject box = GameObject.Find("Correctness");
                        TMPro.TextMeshProUGUI text = box.GetComponent<TMPro.TextMeshProUGUI>();
                        checkLetters();
                        if (typedWord.ToLower().Equals(theWord))
                        {
                            text.text = "Correct!";
                            sideColor = new Color(0, 1, 0);
                            sideWord = "CORRECT";
                            text.color = new Color(0, 256, 0);
                            nextRound = true;
                            isPlayTime = false;
                        }
                        else
                        {
                            if (wordsEntered == 5)
                            {
                                text.text = "FAILURE\n\nWord: " + theWord.ToUpper();
                                sideWord = "FAILURE";
                                sideColor = new Color(1, 0, 0);
                                text.color = new Color(256, 0, 0);
                                isPlayTime = false;
                            }
                            else
                            {
                                typedWord = "";
                                lettersTyped = 0;
                                wordsEntered++;
                            }
                        }
                    }
                    else
                    {
                        GameObject X = GameObject.Find("Cross");
                        TMPro.TextMeshProUGUI XText = X.GetComponent<TMPro.TextMeshProUGUI>();
                        XText.alpha = 1;
                        xTimer = 3.0F;
                        GameObject lineUp = GameObject.Find(wordsEntered.ToString() + "-" + 0.ToString());
                        X.transform.position = new Vector2(X.transform.position.x, lineUp.transform.position.y);
                        xActive = true;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentRound = 1;
            resetBoard();
            isPlayTime = false;
            canType = true;
        }
    }

    void typeText(string letterToType)
    {
        if (flag == false)
        {
            isPlayTime = true;
        }
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
            string boxNum = wordsEntered + "-" + (i);
            GameObject box = GameObject.Find(boxNum);
            SpriteRenderer sprite = box.GetComponent<SpriteRenderer>();
            if (letterTested.Equals(theWord.Substring(i, 1)))
            {
                sprite.color = new Color(0, 256, 0);
                letterStatus = 1;
            }
            else if (isLetterInWord)
            {
                sprite.color = new Color(.83F, .83F, 0);
                letterStatus = 2;
            } else
            {
                sprite.color = new Color(.58F, .23F, .23F);
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
                    sprite1.color = new Color(.83F, .83F, 0);
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
        GameObject box1 = GameObject.Find("Correctness");
        TMPro.TextMeshProUGUI text1 = box1.GetComponent<TMPro.TextMeshProUGUI>();
        text1.text = "";
        flag = false;
        if (120.0F - currentRound * 5 < 60)
        {
            cntdnw = 60.0F;
        }
        else
        {
            cntdnw = 120.0F - (currentRound - 1) * 5;
        }
        timerText.text = "2:00";
        GameObject X = GameObject.Find("Cross");
        TMPro.TextMeshProUGUI XText = X.GetComponent<TMPro.TextMeshProUGUI>();
        XText.alpha = 0;
        roundTimer = 3.0F;
        GameObject roundObj = GameObject.Find("Round");
        TMPro.TextMeshProUGUI roundText = roundObj.GetComponent<TMPro.TextMeshProUGUI>();
        roundText.text = roundText.text.Substring(0, roundText.text.IndexOf(" ") + 1) + currentRound.ToString();
    }

    bool isWord()
    {
        for (int i = 0; i < allWordList.Count; i++)
        {
            if (typedWord.Equals(allWordList[i]))
            {
                return true;
            }
        }
        return false;
    }

    void updatePosition()
    {
        for (int i = 0; i < flg.transform.childCount; i++)
        {
            GameObject Go = flg.transform.GetChild(i).gameObject;
            Go.transform.position = new Vector3(Go.transform.position.x, Go.transform.position.y - (170F * Time.deltaTime), 1);
            Vector3 position = Go.GetComponent<SpriteRenderer>().bounds.center;
            if (i <= rotations.Count && i > 0)
            {
                Go.transform.RotateAround(position, rotations[i - 1], smooth);
            } else if (i == 0)
            {
                Go.transform.RotateAround(position, new Vector3(0, 0, firstRotation), smooth);
            }
            if (Go.transform.position.y < -600)
            {
                Destroy(Go);
                rotations.RemoveAt(0);
            }
        }
        for (int i = 0; i < flg2.transform.childCount; i++)
        {
            GameObject Go = flg2.transform.GetChild(i).gameObject;
            Go.transform.position = new Vector3(Go.transform.position.x, Go.transform.position.y - (170F * Time.deltaTime), 1);
            Vector3 position = Go.GetComponent<SpriteRenderer>().bounds.center;
            if (i <= rotations2.Count && i > 0)
            {
                Go.transform.RotateAround(position, rotations2[i - 1], smooth);
            }
            else if (i == 0)
            {
                Go.transform.RotateAround(position, new Vector3(0, 0, -firstRotation), smooth);
            }
            if (Go.transform.position.y < -600)
            {
                Destroy(Go);
                rotations2.RemoveAt(0);
            }
        }
    }
}