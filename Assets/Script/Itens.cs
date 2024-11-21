using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Itens : MonoBehaviour
{
    public bool podePegar = false;
    public PlayerController player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnMouseEnter()
    {
        if (podePegar)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0);
        }
    }

    private void OnMouseExit()
    {
        if (podePegar)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
    }

    private void OnMouseDown()
    {
        if (podePegar)
        {
            Destroy(this.gameObject);
            player.ColocaRoupa();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            podePegar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            podePegar = false;
        }
    }
}
