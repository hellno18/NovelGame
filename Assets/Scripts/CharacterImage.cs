using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImage : MonoBehaviour
{
    public Sprite[] spriteList;
    public int spriteIndex = 0;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteIndex < 0)
        {
            image.sprite = null;
        }
        else
        {
            image.sprite = spriteList[Mathf.Min(spriteIndex, spriteList.Length - 1)];
        }
    }
}
