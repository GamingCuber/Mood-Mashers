using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {

        public bool finished { get; private set; }


        protected IEnumerator WriteText(string input, TMP_Text textHolder, float delay, float delayBetweenLines)
        {
           
            for (int i = 0; i < input.Length; i++)
            {
              
                textHolder.text += input[i];
                yield return new WaitForSeconds(delay);
            }

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.anyKeyDown);
            finished = true;
        }
    }
}
