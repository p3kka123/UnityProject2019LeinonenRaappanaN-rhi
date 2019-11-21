using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{

    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance; } }

    private PlayerStats stats;
    public PlayerStats Stats { get => stats; set => stats = value; }
    public Equipment PlayerEquipment { get => playerEquipment; set => playerEquipment = value; }
    public GameObject AttackHitBox { get => attackHitBox; set => attackHitBox = value; }

    private Equipment playerEquipment;

    [SerializeField]
    private GameObject attackHitBox;

    //[HideInInspector]
    [SerializeField]
    private Item fist;


    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this);

        if(stats == null) {
            stats = new PlayerStats(100,10,10);
            stats.StatPoints = 10;
            if(stats.Name == null)
                stats.Name = "Sloppis";
        }


        if(PlayerEquipment == null) {
            playerEquipment = new Equipment();  
            playerEquipment.RightWeapon = fist;
        }
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Start() {
        Inventory.Instance.AddItemToInventory(fist);
        //Inventory.Instance.EquipWeapon(Inventory.Instance.GetItemFromInventory(fist) as Weapon);
        Inventory.Instance.EquipWeapon(fist as Weapon);
    }


    private void OnSceneLoad(Scene scene,LoadSceneMode mode) {
        attackHitBox = Gamemanager.Instance.AttackHitBox;      
        //playerEquipment.EquipPlayer();
    }
    


    public class Equipment
    {
        private Item head;
        private Item body;
        private Item legs;
        private Item feet;
        private Item hands;
        private Item leftHand;
        private Item rightWeapon;
        private Item amulet;
        private Item ring1;
        private Item ring2;

        public Item Head { get => head; set => head = value; }
        public Item Body { get => body; set => body = value; }
        public Item Legs { get => legs; set => legs = value; }
        public Item Hands { get => hands; set => hands = value; }
        public Item LeftHand { get => leftHand; set => leftHand = value; }
        public Item RightWeapon { get => rightWeapon; set => rightWeapon = value; }
        public Item Amulet { get => amulet; set => amulet = value; }
        public Item Ring1 { get => ring1; set => ring1 = value; }
        public Item Ring2 { get => ring2; set => ring2 = value; }
        public Item Feet { get => feet; set => feet = value; }

        public void EquipPlayer() {
            Inventory.Instance.EquipWeapon(rightWeapon as Weapon);
        }

    }

}
