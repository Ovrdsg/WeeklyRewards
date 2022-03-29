using UnityEngine;

namespace Rewards
{
    internal class CurrencyView : MonoBehaviour
    {
        private const string WoodKey = nameof(WoodKey);
        private const string DiamondKey = nameof(DiamondKey);
        private const string FoodKEy = nameof(FoodKEy);

        public static CurrencyView Instance;

        [SerializeField] private CurrencySlotView _currencyWood;
        [SerializeField] private CurrencySlotView _currentDiamond;
        [SerializeField] private CurrencySlotView _currentFood;

        private int Wood
        {
            get => PlayerPrefs.GetInt(WoodKey, 0);
            set => PlayerPrefs.SetInt(WoodKey, value);
        }

        private int Diamond
        {
            get => PlayerPrefs.GetInt(DiamondKey, 0);
            set => PlayerPrefs.SetInt(DiamondKey, value);
        }

        private int Food
        {
            get => PlayerPrefs.GetInt(FoodKEy, 0);
            set => PlayerPrefs.SetInt(FoodKEy, value);
        }


        private void Awake() =>
            Instance = this;

        private void OnDestroy() =>
            Instance = null;

        private void Start() =>
            RefreshText();


        public void AddWood(int value)
        {
            Wood += value;
            RefreshText();
        }

        public void AddDiamond(int value)
        {
            Diamond += value;
            RefreshText();
        }

        public void AddFood(int value)
        {
            Food += value;
            RefreshText();
        }


        private void RefreshText()
        {
            _currencyWood.SetData(Wood);
            _currentDiamond.SetData(Diamond);
            _currentFood.SetData(Food);
        }
    }
}
