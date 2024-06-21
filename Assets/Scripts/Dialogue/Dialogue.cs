using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textspeed;
    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    private void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
          gameObject.SetActive(false);
        }
    }
}
