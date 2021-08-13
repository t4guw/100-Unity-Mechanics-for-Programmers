using UnityEngine;
using UnityEngine.UI;

public class GravityBehavior : MonoBehaviour
{
    public Dropdown planetDropdown;
    public string planet;
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
    }

    // Update is called once per frame
    void Update()
    {
        switch(planet)
        {
            case ("Earth"):
                Physics2D.gravity = new Vector2(0, -9.81f);
                break;
            case ("Moon"):
                Physics2D.gravity = new Vector2(0, -1.62f);
                break;
            case ("Mars"):
                Physics2D.gravity = new Vector2(0, -3.77f);
                break;
            case ("Jupiter"):
                Physics2D.gravity = new Vector2(0, -25.95f);
                break;
            case ("Pluto"):
                Physics2D.gravity = new Vector2(0, -0.42f);
                break;
            default:
                Physics2D.gravity = new Vector2(0, -9.81f);
                break;
        }            
    }

    public void PlanetChanged()
    {
        planet = planetDropdown.options[planetDropdown.value].text;
    }
}
