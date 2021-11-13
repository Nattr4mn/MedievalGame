using MedievalGame.Enum;
using MedievalGame.Interface;
using UnityEngine;

namespace MedievalGame.Product
{
    [CreateAssetMenu(menuName = "Product/Meat Product")]
    public class MeatProduct : ScriptableObject, IProduct, IItem
    {
        public MeatEnum MeatType => _meatType;
        public float BasePrice => _basePrice;
        public Sprite ItemSprite => _meatPreviewSprite;

        [SerializeField] private MeatEnum _meatType;
        [SerializeField] private float _basePrice = 0f;
        [SerializeField] private Sprite _meatPreviewSprite;
    }
}
