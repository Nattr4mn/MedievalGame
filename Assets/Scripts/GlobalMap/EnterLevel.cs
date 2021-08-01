using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelList;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        //if(Input.GetMouseButton(0))
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                _levelList.ForEach(item =>
                {
                    if (hit.collider.tag == item.tag)
                        SceneManager.LoadScene(item.tag);
                });
            }
        }
    }
}
