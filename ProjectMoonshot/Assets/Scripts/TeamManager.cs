using Data;
using DG.Tweening;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public Transform playerSpawn;
    public PlayerController player;
    public GameObject walls;
    public GameObject itemPool;
    public GameObject ground;
    public GameObject uiPanel;

    [SerializeField] private CraftingItemData data;
    [Range(0, 100)] [SerializeField] private float completionPercentage;
    private UI _ui;

    #region UI

    public struct UI
    {
        public struct Crafting
        {
            private Transform _parent;
            public Image _leftArrow;
            private Image _rightArrow;
            public Item item;

            public struct Item
            {
                private TextMeshProUGUI _name;

                public Item(Component item)
                {
                    _name = item.GetComponentInChildren<TextMeshProUGUI>();
                }

                public void ChangeItem(CraftingItemData.Item item)
                {
                    _name.SetText(item.name);
                }
            }
            
            public Crafting(Transform crafting)
            {
                _parent = crafting;
                _leftArrow = crafting.GetChild(1).GetComponent<Image>();
                _rightArrow = crafting.GetChild(1).GetComponent<Image>();
                item = new Item(crafting.GetChild(0));
            }

            public void MoveLeft(CraftingItemData data)
            {
                _leftArrow.rectTransform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.InOutBack);
                item.ChangeItem(data.craftingItems[5 - 1]);
            }
            
            public void MoveRight(CraftingItemData data)
            {
                _rightArrow.rectTransform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.InOutBack);
                item.ChangeItem(data.craftingItems[5 + 1]);
            }

            public void ToggleCrafting()
            {
                // _leftArrow.rectTransform.DOLocalMoveX(1f, 0.5f).SetEase(Ease.InOutBack);
                _parent.gameObject.SetActive(!_parent.gameObject.activeSelf);
            }
        }

        private Image _progress;
        public Crafting crafting;
        
        public UI(GameObject ui)
        {
            _progress = ui.transform.GetChild(0).GetChild(2).GetComponent<Image>();
            crafting = new Crafting(ui.transform.GetChild(1));
        }

        public void Fill(float percentage) => _progress.fillAmount = percentage / 100f;
    }

    #endregion

    #region Events
    
    public void CallToggleCrafting()
    {
        _ui.crafting.ToggleCrafting();
    }

    private void Awake()
    {
        data = Resources.Load<CraftingItemData>("CraftingItems");
        _ui = new UI(uiPanel);
        _ui.crafting.item.ChangeItem(data.craftingItems[4]);
        walls.SetActive(false);
        itemPool.SetActive(false);
        ground.SetActive(false);
    }
    
    private void Update()
    {
        if (!player.enabled) return;
        _ui.Fill(completionPercentage);
    }

    #endregion

    #region Spawns

    public void SpawnWalls()
    {
        walls.SetActive(true);
    }
    
    public void SpawnItemPool()
    {
        itemPool.SetActive(true);
    }
    
    public void SpawnGround()
    {
        ground.SetActive(true);
    }
    
    public void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.gameObject.SetActive(true);
    }

    #endregion
}