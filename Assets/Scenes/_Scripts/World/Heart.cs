using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Heart : MonoBehaviour
{
    [SerializeField] private float _cycleLength = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(90, 0f, 10), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DOShakePosition(_cycleLength, 0.3f, 3).SetLoops(-1, LoopType.Yoyo);
        transform.DOScaleY(4.8f, _cycleLength).SetLoops(-1, LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
