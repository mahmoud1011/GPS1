using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSlimeBallOld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.HealingBlob();
            Destroy(gameObject);
        }
    }
}
