using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//acesso de elementos do cavas

public class DialogueControl : MonoBehaviour
{
   [Header("Components")]
   
   public GameObject dialogueObj; //janela do dialogo 
   public Image profile; 
   public Text speechText; // texto
   public Text actorNameText; // quem tá falando
   [Header("Settings")]
   public float typingSpeed;//velocidade do texto aparecendo
   private string[] sentences;
   private int index;
   public void Speech(Sprite p, string[] txt, string actorName){//chamado do npc pro dialogo
      dialogueObj.SetActive(true);
      profile.sprite = p;//p = profile
      sentences = txt;//texto
      actorNameText.text = actorName; //quem tá falando  
      StartCoroutine(TypeSentence());
   }
   IEnumerator TypeSentence(){//digitação de letra por letra
      foreach(char letter in sentences[index].ToCharArray()){
         speechText.text += letter;
         yield return new WaitForSeconds(typingSpeed);
      }
      
   }
   public void NextSentence(){//botao de skip
      if(speechText.text == sentences[index]){
         if(index < sentences.Length - 1 ){//ainda tem texto para ser lido
          
         index++;
         speechText.text = "";
         StartCoroutine(TypeSentence());
       
         }
         else{//todos os textos lidos
         speechText.text = "";
         index = 0;
          dialogueObj.SetActive(false);
           
         

         }
        
      }
   }
}
