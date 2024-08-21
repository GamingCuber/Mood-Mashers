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
     

        private void Awake()
        {
            textHolder = GetComponent<TMP_Text>();

            var coroutine = StartCoroutine(WriteText(input, textHolder));
        }
    }
}
