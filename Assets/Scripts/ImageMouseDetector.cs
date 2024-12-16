using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageMouseDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name;
    public string description;

    [SerializeField] private GameObject _showBoxPrefab;
    private GameObject _showBoxObject;
    [SerializeField] private Canvas _canvas;

    public void Start()
    {
        _showBoxObject = GameObject.Instantiate(_showBoxPrefab);

        GameObject header = _showBoxObject.transform.Find("Header").gameObject;
        _showBoxObject.transform.SetParent(_canvas.transform, false);
        _showBoxObject.transform.localScale = Vector3.one;
        _showBoxObject.transform.localPosition = new Vector3(1720 /2, 200, 0);
        header.GetComponent<TextMeshProUGUI>().text = name;
        GameObject body = _showBoxObject.transform.Find("Body").gameObject;
        body.GetComponent<TextMeshProUGUI>().text = description;
        _showBoxObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _showBoxObject.SetActive(true);
        Debug.Log("Вошёл");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _showBoxObject.SetActive(false);
        Debug.Log("Вышел");
    }

}
