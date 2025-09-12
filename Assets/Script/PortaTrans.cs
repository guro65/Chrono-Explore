using UnityEngine;
using UnityEngine.UI;

public class PortaTrans : MonoBehaviour
{
    public GameObject porta;
    public Animation animation;
    public bool estaPerto = false;
    public Canvas canvas;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animation = porta.GetComponent<Animation>();
        porta = GameObject.Find("PortaTrans");
        canvas= GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
          //animation.setBool("TrocarCena", true);
        }
    }
}
