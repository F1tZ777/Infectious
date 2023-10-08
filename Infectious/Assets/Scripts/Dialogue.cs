using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textObject;
    [TextArea(2, 10)]
    public string[] greet;
    [TextArea(2, 10)]
    public string[] symptoms;
    [TextArea(2, 10)]
    public string[] accepted;
    [TextArea(2, 10)]
    public string[] denied;

    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        //textObject.text = string.Empty;
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
    }

    public void StartDialogue()
    {
        textObject.text = string.Empty;
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
        foreach (char c in accepted[rand].ToCharArray())
        {
            textObject.text += c;
            yield return null;
        }
    }

    IEnumerator TypeDenied()
    {
        rand = Random.Range(0, denied.Length);
        foreach (char c in denied[rand].ToCharArray())
        {
            textObject.text += c;
            yield return null;
        }
    }
}
