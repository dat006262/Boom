using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUP : MonoBehaviour
{
    public enum ItemType 
    {
        ExtraBomp,
        BlastRadius,
        ExtraSpeed,
    }
    public ItemType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Itempickup(collision.gameObject);
            Destroy(this.gameObject);
        }    
    }
    private void Itempickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomp:
                player.GetComponent<BoomController>().AddBoom();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<BoomController>()._ExplotionRadius++;
                break;
            case ItemType.ExtraSpeed:
                player.GetComponent<MovePlayer>().speed +=2;

                break;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
