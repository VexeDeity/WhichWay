
using UnityEngine;

public class OnClick : MonoBehaviour
{
    
    void OnMouseDown()
    {
        
        GameObject.FindGameObjectWithTag("Pwaypoint").GetComponent<ChoseStar>().StarEffect();
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
    }
}
