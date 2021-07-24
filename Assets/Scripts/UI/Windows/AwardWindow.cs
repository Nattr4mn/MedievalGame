using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AwardWindow : MonoBehaviour
{
    [SerializeField] private Text _number;
    [SerializeField] private Image _awardIcon;

    public void Init(string number, Sprite icon)
    {
        _number.text = number;
        _awardIcon.sprite = icon;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        Vector3 endPos = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
        gameObject.GetComponent<RectTransform>().position = endPos;
        endPos.y += 40f;
        while (gameObject.GetComponent<RectTransform>().position.y <= endPos.y)
        {
            gameObject.GetComponent<RectTransform>().Translate(Vector3.up * 0.7f);
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(gameObject);
    }
}
