using UnityEngine;

public class PlaneGameSkin : MonoBehaviour
{
    [SerializeField] private GameObject _plane;
    [SerializeField] private Sprite[] _sprites;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedAirplane", 0);
        _plane.GetComponent<SpriteRenderer>().sprite = _sprites[index];
        _plane.AddComponent<PolygonCollider2D>().isTrigger = true;
    }
}