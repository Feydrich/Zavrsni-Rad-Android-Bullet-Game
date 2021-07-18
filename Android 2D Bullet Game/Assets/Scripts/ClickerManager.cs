using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ClickerManager : MonoBehaviour
{
     
    private float startPosX, startPosY;
    private bool isBeingHeld = false;
    public Text tekst;
    public dungeonType Type;
    private SpriteRenderer Selection;
    public static GameObject Selected;
    public GameObject holder, Pin;
    public GameObject[] neighbour;
    public GameObject light;
    public float lightX, lightY;

    void Start()
    {
        holder.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Selection = GetComponent<SpriteRenderer>();
        Selected = holder;
        
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.position = new Vector2(this.transform.position.x + lightX, this.transform.position.y + lightY);

        if (Selected.gameObject == this.gameObject && Pin.GetComponent<PinManager>().currentLocation != Selected)
        {
            Selection.color = new Color(0.9f, 0.9f, 0.9f, 1);
        }
        else {
            Selection.color = new Color(1, 1, 1, 1);
        }


        if (Input.touchCount > 0)
        {
           // Touch touched = Input.GetTouch(0);
            isBeingHeld = true;
        }

        if (Input.touchCount <= 0 && Input.GetMouseButtonDown(0) == false) {
            isBeingHeld = false;
        }


        if (isBeingHeld == true) {

            Vector3 mousePos;
            if (Input.touchCount > 0)
            {
                
                mousePos = Input.GetTouch(0).position;
                
                // The ray to the touched object in the world
                Ray ray = Camera.main.ScreenPointToRay(mousePos);

                // The raycast handling
                RaycastHit2D vHit = Physics2D.Raycast(ray.origin, ray.direction);
                if (vHit.transform.name == this.name)
                {
                    Selected = this.gameObject;
                    Pin.GetComponent<PinManager>().selected = Selected;

                    Pin.GetComponent<PinManager>().Line.GetComponent<LineDrawer>().isSelected = true;
                }



            }
            else {
                tekst.text = "You pressed the mouse!";

                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.z = 0;

                Selected = this.gameObject;
                Pin.GetComponent<PinManager>().selected = Selected;


                Pin.GetComponent<PinManager>().Line.GetComponent<LineDrawer>().isSelected = true;

            }

            

            tekst.text = this.gameObject.name;
            


        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isBeingHeld = true;
        }
       
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }






}
