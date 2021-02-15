using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
<<<<<<< HEAD
        ScoreTextScript.coinAmount += 1;
=======
>>>>>>> d7f710a20a3871599f493a826d4c771e73a748f5
        Destroy(gameObject);
    }
}
