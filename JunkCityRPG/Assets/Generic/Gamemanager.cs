using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    private UIJournalStatsInvController uiJSIcontroller;
    private string prevSceneName;

    private List<PlayerSpawnPoint> spawnPoints = new List<PlayerSpawnPoint>();

    [SerializeField] private Texture2D baseCursor;
    [SerializeField] private Texture2D interactableCursor;


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
    public GameObject Inventory { get => inventory; set => inventory = value; }
    public GameObject AttackHitBox { get => attackHitBox; set => attackHitBox = value; }
    public GameObject Notification { get => notification; set => notification = value; }
    public List<PlayerSpawnPoint> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
    public string PrevSceneName { get => prevSceneName; set => prevSceneName = value; }
    public UIJournalStatsInvController UiJSIcontroller { get => uiJSIcontroller; set => uiJSIcontroller = value; }
    public Texture2D InteractableCursor { get => interactableCursor; set => interactableCursor = value; }
    public Texture2D BaseCursor { get => baseCursor; set => baseCursor = value; }
    public GameObject ToolTip { get => toolTip; set => toolTip = value; }

    public enum GameState
    {
        Normal,
        Dialog,
        Combat,
        Menu,
        Pause
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
