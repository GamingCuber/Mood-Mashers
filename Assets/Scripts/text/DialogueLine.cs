using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        
        private TMP_Text textHolder;

        [Header("Text Option")]
        [SerializeField] private string input;

        [Header("Timing Text")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageholder;

        private void Awake()
        {
            textHolder = GetComponent<TMP_Text>();
            textHolder.text = "";

            imageholder.sprite = characterSprite;
            imageholder.preserveAspect = true;  
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay, delayBetweenLines)); 
        }
    }
}
