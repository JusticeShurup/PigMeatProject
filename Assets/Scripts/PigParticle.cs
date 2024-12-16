using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PigParticle : MonoBehaviour
{
    public string name;
    public string description;
    [SerializeField] private Canvas _interCanvas;


    [SerializeField] private GameObject _showBoxPrefab;
    private GameObject _showBoxObject;

    private Material _ownMaterial;
    private Color _activeColor;
    private Color _idleColor;


    public void Start()
    {
        _ownMaterial = transform.gameObject.GetComponent<Renderer>().material;
        _activeColor = Color.yellow;
        _idleColor = _ownMaterial.color;

        _showBoxObject = GameObject.Instantiate(_showBoxPrefab);

        GameObject header = _showBoxObject.transform.Find("Header").gameObject;
        _showBoxObject.transform.SetParent(_interCanvas.transform, false);
        _showBoxObject.transform.localScale = Vector3.one;
        _showBoxObject.transform.localPosition = new Vector3(500, 100, 0);
        header.GetComponent<TextMeshProUGUI>().text = name;
        GameObject body = _showBoxObject.transform.Find("Body").gameObject;
        body.GetComponent<TextMeshProUGUI>().text = description;
        GameObject image = _showBoxObject.transform.Find("Image").gameObject;
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Images/{name}");

        _showBoxObject.SetActive(false);
    }

    public void Focus()
    {
        _ownMaterial.color = _activeColor;
        _showBoxObject.SetActive(true);
    }

    public void UnFocus()
    {
        _ownMaterial.color = _idleColor;
        _showBoxObject.SetActive(false);
    }
}
