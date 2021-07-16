using UnityEngine;
using UnityEngine.UI;

public class ResourceLine : MonoBehaviour
{
    [SerializeField] private Text _textField;
    [SerializeField] private Image _iconField;
    private string itemName;

    public void Render(IItem item)
    {
        itemName = item.Name;
        _textField.text = item.ItemCount.ToString();
        _iconField.sprite = item.UIIcon;
    }

    public void ClickButton()
    {
        itemName = itemName.Replace("Seed", "");
        PlayerResources.Instance.currentFarmingCrop = itemName;
        UIManager.Instance.Action();
        FindObjectOfType<ResourcePanel>().gameObject.SetActive(false);
    }
}
