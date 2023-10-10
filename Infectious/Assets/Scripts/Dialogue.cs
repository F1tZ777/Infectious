using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class Dialogue : MonoBehaviour
{
    public SceneManager SceneManager;
    public gamemanager manager;
    public npcAnimation animator;

    public TextMeshProUGUI textObject;
    [TextArea(2, 10)]
    public string[] greet;
    [TextArea(2, 10)]
    public string[] symptoms;
    [TextArea(2, 10)]
    public string[] accepted;
    [TextArea(2, 10)]
    public string[] denied;
    [TextArea(2, 10)]
    public string[] boss;

    private int rand;

    const string APPROVED = "NPCAccept";
    const string DENIED = "NPCDeny";

    // Start is called before the first frame update
    void Start()
    {
        textObject.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0))
        {
            if (textObject.text == string.Empty)
            {
                StartDialogue();
            }
            if (textObject.text == greet[rand])
            {
                textObject.text += "\n\n";
                SymptomDialogue();
            }
        }*/

        /*if (textObject.text == denied[rand].ToString())
        {
            StartCoroutine(Denied());
        }*/
    }

    public void StartDialogue()
    {
        //textObject.text = string.Empty;
        StartCoroutine(TypeGreet());
    }

    public void SymptomDialogue()
    {
        StartCoroutine(TypeSymptom());
    }

    public void AcceptedDialogue()
    {
        StartCoroutine(TypeAccepted());
        
    }

    public void DeniedDialogue()
    {
        StartCoroutine(TypeDenied());
        
    }

    public void BossDialogue()
    {
        StartCoroutine(TypeBoss());
    }



    IEnumerator TypeGreet()
    {
        rand = Random.Range(0, greet.Length);
        foreach (char c in greet[rand].ToCharArray())
        {
            textObject.text += c;
            yield return null;
        }
    }

    IEnumerator TypeSymptom()
    {
        foreach (char c in symptoms[1].ToCharArray())
        {
            textObject.text += c;
            yield return null;
        }
    }

    IEnumerator TypeAccepted()
    {
        rand = Random.Range(0, accepted.Length);
        textObject.text += "\n\n";
        foreach (char c in accepted[rand].ToCharArray())
        {
            textObject.text += c;
            //yield return null;
        }
        animator.ChangeAnimation(APPROVED);
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }

    IEnumerator TypeDenied()
    {
        rand = Random.Range(0, denied.Length);
        textObject.text += "\n\n";
        foreach (char c in denied[rand].ToCharArray())
        {
            textObject.text += c;
            yield return null;
        }
        animator.ChangeAnimation(DENIED);
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }

    IEnumerator TypeBoss()
    {
        for (int i = 0; i < boss.Length; i++) {
            foreach (char c in boss[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            textObject.text += "\n\n";
        }
        yield return new WaitForSeconds(5);
        SceneManager.End();
    }

    IEnumerator Denied()
    {
        animator.ChangeAnimation(DENIED);
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }
}
