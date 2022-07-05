using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Best : MonoBehaviour
{
    int count = 0;
    public void BestTime()
    {
        if (count < 1)
        {
            ++count;
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            transform.DOJump(pos, 0.5f, 1, 0.5f).SetUpdate(true);
        }

    }
}
