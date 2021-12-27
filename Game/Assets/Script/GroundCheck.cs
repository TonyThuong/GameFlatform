using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }

    private void onTriggerStay2D(Collider2D collision)
    {
       // if (conllision.isTrigger == false || collision.CompareTag("water"))
        player.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (conllision.isTrigger == false || collision.CompareTag("water"))
        player.grounded = false;
    }
    
}
