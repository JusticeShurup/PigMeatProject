using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CookTechnologiesSceneManager : MonoBehaviour
{
    private List<List<Sprite>> _cookReceipts;
    private Sprite _plusSprite;
    private int _currentIndex = 0;
    private List<GameObject> _currentImageObjects = new List<GameObject>();
    private List<GameObject> _currentPlusObjects = new List<GameObject>();
    [SerializeField] private Canvas _canvas;


    public void Start()
    {
        _plusSprite = Resources.Load<Sprite>("Images/plus");

        _cookReceipts = new List<List<Sprite>>();
        _cookReceipts.Add(new List<Sprite>()
        {
            Resources.Load<Sprite>("Images/сковородка"),
            Resources.Load<Sprite>("Images/шея")
        });

        _cookReceipts.Add(new List<Sprite>()
        {
            Resources.Load<Sprite>("Images/мангал"),
            Resources.Load<Sprite>("Images/шампуры"),
            Resources.Load<Sprite>("Images/шея"),
        });
        _currentIndex = 0;
        ShowImages();
    }

    public void OnClickBackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OnClickNext()
    {
        _currentIndex = (_currentIndex + 1) % _cookReceipts.Count;
        ShowImages();
    }

    public void OnClickPrev()
    {
        _currentIndex -= 1;
        if (_currentIndex < 0)
        {
            _currentIndex = _cookReceipts.Count - 1;
        }
        ShowImages();
    }

    public void ShowImages()
    {
        List<GameObject> objectToDestroy = _currentImageObjects.Concat(_currentPlusObjects).ToList();
        foreach (var item in objectToDestroy)
        {
            Destroy(item);
        }
        _currentImageObjects.Clear();
        _currentPlusObjects.Clear();

        for (int i = 0; i < _cookReceipts[_currentIndex].Count; i++)
        {
            GameObject imageObject = new GameObject();
            imageObject.name = "CookReceiptImage";
            Image cookImage = imageObject.AddComponent<Image>();
            cookImage.sprite = _cookReceipts[_currentIndex][i];
            imageObject.transform.SetParent(_canvas.transform);
            imageObject.transform.localPosition = new Vector2((-_canvas.pixelRect.width / 2) + _canvas.pixelRect.width / (2 * _cookReceipts[_currentIndex].Count) + _canvas.pixelRect.width / _cookReceipts[_currentIndex].Count * i, 0);
            _currentImageObjects.Add(imageObject);
        }

        for (int i = 0; i < Mathf.Ceil(_currentImageObjects.Count / 2f); i++)
        {
            GameObject currentImageObject = _currentImageObjects[i];
            GameObject nextImageObject = _currentImageObjects[i + 1];
            Image currentImage = currentImageObject.GetComponent<Image>();
            Image nextImage = nextImageObject.GetComponent<Image>();

            GameObject imageObject = new GameObject();
            imageObject.name = "PlusImage";
            Image plus = imageObject.AddComponent<Image>();
            plus.sprite = _plusSprite;
            imageObject.transform.SetParent(_canvas.transform);
            imageObject.transform.localPosition = new Vector2((currentImage.transform.localPosition.x + nextImage.transform.localPosition.x) / 2, 0);
            _currentPlusObjects.Add(imageObject);

        }
    }


}
