using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    Vector3 panelLocation;
    float percentThreshold = 0.2f;
    float easing = 0.5f;
    public int totalPages;
    int currentPage = 1;
    public float heightDivider;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data) 
    {
        float difference = data.pressPosition.y - data.position.y;
        transform.position = panelLocation - new Vector3(0, difference, 0); 
    }

    public void OnEndDrag(PointerEventData data) 
    {
        float percentage = (data.position.y - data.pressPosition.y) / Screen.height;

        if(Mathf.Abs(percentage) >= percentThreshold) {
            Vector3 newLocation = panelLocation;

            if(percentage > 0 && currentPage < totalPages) {
                currentPage++;
                newLocation += new Vector3(0, Screen.height/heightDivider, 0);
            } else if (percentage < 0 && currentPage > 1) {
                currentPage--;
                newLocation += new Vector3(0, -Screen.height/heightDivider, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        } else {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds) {
        float t = 0f;
        while(t <= 1.0){
            t+= Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
