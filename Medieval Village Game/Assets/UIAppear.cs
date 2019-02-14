using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
  public Dialogue dialogue;

  void OnTriggerEnter(Collider other){
    if (other.CompareTag("Player")) {
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
  }
  void OnTriggerExit(Collider other){
    if (other.CompareTag("Player")) {
      FindObjectOfType<DialogueManager>().EndDialogue();
    }
  }
}
