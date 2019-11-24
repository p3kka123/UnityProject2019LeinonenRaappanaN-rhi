using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;

    public static Gamemanager Instance { get { return _instance; } }


    private GameObject player;
    private GameObject inventoryGrid;
    private GameObject playerRightHandAnchor;
    private GameObject inventory;
    private GameObject attackHitBox;
    private GameObject notification;
    private GameObject toolTip;
    private TextMeshProUGUI money;
    private UIJournalStatsInvController uiJSIcontroller;
    private UIFader deathScreen;
    private string prevSceneName;

    private List<PlayerSpawnPoint> spawnPoints = new List<PlayerSpawnPoint>();

    [SerializeField] private Texture2D baseCursor;
    [SerializeField] private Texture2D interactableCursor;
    [SerializeField] private Texture2D attackCursor;


    public GameState CurrentState { get => currentState;
        set {
            lastState = currentState;
            currentState = value;
        }
    }

    public GameState LastState { get => lastState;}
    public GameObject Player { get => player; set => player = value; }
    public GameObject InventoryGrid { get => inventoryGrid; set => inventoryGrid = value; }
    public GameObject PlayerRightHandAnchor { get => playerRightHandAnchor; set => playerRightHandAnchor = value; }
    public GameObject InventoryGO { get => inventory; set => inventory = value; }
    public GameObject AttackHitBox { get => attackHitBox; set => attackHitBox = value; }
    public GameObject Notification { get => notification; set => notification = value; }
    public List<PlayerSpawnPoint> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
    public string PrevSceneName { get => prevSceneName; set => prevSceneName = value; }
    public UIJournalStatsInvController UiJSIcontroller { get => uiJSIcontroller; set => uiJSIcontroller = value; }
    public Texture2D InteractableCursor { get => interactableCursor; set => interactableCursor = value; }
    public Texture2D BaseCursor { get => baseCursor; set => baseCursor = value; }
    public GameObject ToolTip { get => toolTip; set => toolTip = value; }
    public TextMeshProUGUI Money { get => money; set => money = value; }
    public Texture2D AttackCursor { get => attackCursor; set => attackCursor = value; }
    public UIFader DeathScreen { get => deathScreen; set => deathScreen = value; }

    public enum GameState
    {
        Normal,
        Dialog,
        Combat,
        Menu,
        Pause,
        Dead
    }

    private GameState lastState;
    private GameState currentState;

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        Cursor.SetCursor(BaseCursor, Vector2.zero, CursorMode.Auto);

        DontDestroyOnLoad(this);

        //SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene,LoadSceneMode mode) {
        notification.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1,1,1,0);
    }

    private Save CreateSaveGame() {
        Save save = new Save();

        save.charisma = PlayerManager.Instance.Stats.Charisma;
        save.constitution = PlayerManager.Instance.Stats.Constitution;
        save.currHealth = PlayerManager.Instance.Stats.CurrHealth;
        save.currMana = PlayerManager.Instance.Stats.CurrMana;
        save.dexterity = PlayerManager.Instance.Stats.Dexterity;
        save.exp = PlayerManager.Instance.Stats.Exp;
        save.health = PlayerManager.Instance.Stats.Health;
        save.intelligence = PlayerManager.Instance.Stats.Intelligence;
        save.level = PlayerManager.Instance.Stats.Level;
        save.mana = PlayerManager.Instance.Stats.Mana;
        save.name = PlayerManager.Instance.Stats.Name;
        save.statPoints = PlayerManager.Instance.Stats.StatPoints;
        save.strength = PlayerManager.Instance.Stats.Strength;
        save.wisdom = PlayerManager.Instance.Stats.Wisdom;



        //save.activeQuests = QuestManager.Instance.activeQuests;
        //save.completedQuests = QuestManager.Instance.completedQuests;

        save.money = Inventory.Instance.Money;
        //save.items = Inventory.Instance.InventoryItems;
        foreach(Item item in Inventory.Instance.InventoryItems) {
            save.items.Add(item.ItemName, item.AmountInInventory);
            print(item.ItemName + " Saved");
        }

        save.currScene = SceneManager.GetActiveScene().name;

        return save;
    }

    public void SaveGame() {
        Save save = CreateSaveGame();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("game saved to path " + Application.persistentDataPath);
    }

    public void LoadGame() {
        if(File.Exists(Application.persistentDataPath + "/gamesave.save")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(save.currScene);

            //StartCoroutine(SceneFader.Instance.FadeAndLoadScene(SceneFader.FadeDirection.In,save.currScene));



            Inventory.Instance.ClearInventory();

            PlayerManager.Instance.Stats.Charisma = save.charisma;
            PlayerManager.Instance.Stats.Constitution = save.constitution;
            PlayerManager.Instance.Stats.CurrHealth = save.currHealth;
            PlayerManager.Instance.Stats.CurrMana = save.currMana;
            PlayerManager.Instance.Stats.Dexterity = save.dexterity;
            PlayerManager.Instance.Stats.Exp = save.exp;
            PlayerManager.Instance.Stats.Health = save.health;
            PlayerManager.Instance.Stats.Intelligence = save.intelligence;
            PlayerManager.Instance.Stats.Level = save.level;
            PlayerManager.Instance.Stats.Mana = save.mana;
            PlayerManager.Instance.Stats.Name = save.name;
            PlayerManager.Instance.Stats.StatPoints = save.statPoints;
            PlayerManager.Instance.Stats.Strength = save.strength;
            PlayerManager.Instance.Stats.Wisdom = save.wisdom;

            //Inventory.Instance.InventoryItems = save.items;


            



            foreach(var item in save.items) {
                Item itemObject = Resources.Load<Item>(item.Key);

                if(itemObject.ItemName == "Fist")
                    itemObject.AmountInInventory = 0;
                else
                    itemObject.AmountInInventory = item.Value - 1;
        
                Inventory.Instance.AddItemToInventory(itemObject);
            }

            Inventory.Instance.Money = save.money;

            //QuestManager.Instance.activeQuests = save.activeQuests;
            //QuestManager.Instance.completedQuests = save.completedQuests;




            print("game loaded");
        }
    }

    public Transform GetPlayerSpawnPosition() {
        foreach(PlayerSpawnPoint spawnPoint in spawnPoints) {
            if(spawnPoint.PreviousScene == prevSceneName) {
                return spawnPoint.transform;
            }
        }
        return SpawnPoints[0].transform;
    }

    public void DisplayNotification(string message) {
        notification.GetComponentInChildren<TextMeshProUGUI>().text = message;
        StartCoroutine(FadeImage(false));
        StartCoroutine(WaitForX(3f));
    }

    IEnumerator WaitForX(float time) {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeImage(true));
    }

    public IEnumerator FadeImage(bool fadeAway) {
        // fade from opaque to transparent
        if(fadeAway) {
            // loop over 1 second backwards
            for(float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                notification.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1,1,1,i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for(float i = 0; i <= 1; i += Time.deltaTime) {
                // set color with i as alpha
                notification.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1,1,1,i);
                yield return null;
            }
        }
    }

}
