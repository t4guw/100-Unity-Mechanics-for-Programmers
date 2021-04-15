using UnityEngine;

public class changeCursor : MonoBehaviour
{
    public Sprite defaultCursor;
    public Sprite tempCursor;
    [SerializeField]cursorControl cursor;

    private void OnMouseEnter()
    {
        cursor.rend.sprite = tempCursor;
    }

    private void OnMouseExit()
    {
        cursor.rend.sprite = defaultCursor;
    }
}
