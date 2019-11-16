using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenSwitch : MonoBehaviour
{
    [SerializeField] List<Transform> trs = new List<Transform>();
    [SerializeField] SpriteRenderer SR;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;
    private bool onOff = true;
    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (onOff) Rotation();
    }
    private void Rotation()
    {
        foreach(Transform tr in trs)
        {
            tr.eulerAngles += new Vector3(0, 0, rotationSpeed);
        }
    }
    public void SetOnOff()
    {
        onOff = !onOff;
        if (onOff)
        {
            SR.sprite = onSprite;
        }
        else
        {
            SR.sprite = offSprite;
        }
    }
}
