using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pageswiper : MonoBehaviour, IDragHandler, IEndDragHandler {
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 4;
    private int currentPage = 1;
	// Use this for initialization
	void Start () {
        panelLocation = transform.position;
	}

    //start drag
  
    public void OnDrag(PointerEventData data)
    {
        Debug.Log(data.pressPosition - data.position);
        float difference = data.pressPosition.x -data.position.x;
        //modifing the position of oanel holder acordin to swipe
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    //end drag
    public void OnEndDrag(PointerEventData data)
    {
        //percentage i move respect to screen width
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        //panelLocation = transform.position;

        //create diferrents pages to change between them
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage<totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }else if(percentage < 0 && currentPage>1)
            {
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            //with no transition
            // transform.position = newLocation;

            //with transition
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
    
            panelLocation = newLocation;

        }
        else
        {
            //with no transition
            //transform.position = panelLocation;

            //with transition
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));

        }
    }

    //Creating a transition
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }


}
