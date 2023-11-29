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
    //public float playTime = 1.3f;
    //public AudioSource PlaySound;
    public audiomanager audiomanager;

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
    public string nikogreet;
    [TextArea(2, 10)]
    public string[] rebelgreet;
    [TextArea(2, 10)]
    public string nikoaccepted;
    [TextArea(2, 10)]
    public string nikodenied;
    [TextArea(2, 10)]
    public string[] bossGoodEnd;
    [TextArea(2, 10)]
    public string[] bossBadEnd;
    [TextArea(2, 10)]
    public string[] bossFiredEnd;
    [TextArea(2, 10)]
    public string[] bossArrestedEnd;

    private int rand;
    private bool finishDialogue;

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
        //if (PlaySound.time > 1.3f)
        //{
        //    PlaySound.Stop();
        //}
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
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeGreet());
        //textObject.text = string.Empty;
    }

    public void SymptomDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeSymptom());
    }

    public void AcceptedDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeAccepted());
    }

    public void DeniedDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeDenied());
    }

    public void NikoStartDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        if(singleton.Instance.currentday!=5){
            StartCoroutine(TypeNikoGreet());
        }
        else{
            StartCoroutine(TypeRebelGreet());
        }
    }

    public void NikoAcceptedDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeNikoAccepted());
    }

    public void NikoDeniedDialogue()
    {
        audiomanager.PlaySFX("PencilScratch");
        StartCoroutine(TypeNikoDenied());
    }

    public void BossDialogue()
    {
        if(singleton.Instance.totalDetainPercentage == 1)
            StartCoroutine(TypeBossFired());
        else if(singleton.Instance.totalApprovePercentage == 1)
            StartCoroutine(TypeBossArrested());
        else
        {
            if (singleton.Instance.performanceScore > 0)
            {
                StartCoroutine(TypeBossGood());
            }
            else
                StartCoroutine(TypeBossBad());
        }
    }



    IEnumerator TypeGreet()
    {
        finishDialogue = false;
        rand = Random.Range(0, greet.Length);
        foreach (char c in greet[rand].ToCharArray())
        {
            if (finishDialogue)
            {
                break;
            }
            textObject.text += c;
            yield return null;
        }
        finishDialogue = true;
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
        if (!finishDialogue)
        {
            textObject.text = "";
            textObject.text = greet[rand];
            finishDialogue = true;
        }
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
        if (!finishDialogue)
        {
            textObject.text = "";
            textObject.text = greet[rand];
            finishDialogue = true;
        }
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

    IEnumerator TypeNikoGreet()
    {
        finishDialogue = false;
        foreach (char c in nikogreet.ToCharArray())
        {
            if (finishDialogue)
            {
                break;
            }
            textObject.text += c;
            yield return null;
        }
        finishDialogue = true;
    }

    IEnumerator TypeRebelGreet(){
        finishDialogue = false;
        for (int i = 0; i < rebelgreet.Length; i++) {
            audiomanager.PlaySFX("PencilScratch");
            foreach (char c in rebelgreet[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            if (i < rebelgreet.Length - 1)
                textObject.text += "\n\n";
        }
        finishDialogue = true;
    }

    IEnumerator TypeNikoAccepted()
    {
        if (!finishDialogue)
        {
            StopCoroutine(TypeNikoGreet());
            textObject.text = "";
            textObject.text = nikogreet;
            finishDialogue = true;
        }
        textObject.text += "\n\n";
        foreach (char c in nikoaccepted.ToCharArray())
        {
            textObject.text += c;
        }
        //animator.ChangeAnimation("ScriptedNPCApproved");
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }

    IEnumerator TypeNikoDenied()
    {
        if (!finishDialogue)
        {
            StopCoroutine(TypeNikoGreet());
            textObject.text = "";
            textObject.text = nikogreet;
            finishDialogue = true;
        }
        textObject.text += "\n\n";
        finishDialogue = false;
        foreach (char c in nikodenied.ToCharArray())
        {
            textObject.text += c;
        }
        //animator.ChangeAnimation("ScriptedNPCDenied");
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }

    IEnumerator TypeBossGood()
    {
        for (int i = 0; i < bossGoodEnd.Length; i++) {
            audiomanager.PlaySFX("PencilScratch");
            foreach (char c in bossGoodEnd[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            if (i < bossGoodEnd.Length - 1)
                textObject.text += "\n\n";
        }
        yield return new WaitForSeconds(5);
        SceneManager.Ending();
    }

    IEnumerator TypeBossBad()
    {
        for (int i = 0; i < bossBadEnd.Length; i++)
        {
            audiomanager.PlaySFX("PencilScratch");
            foreach (char c in bossBadEnd[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            if (i < bossBadEnd[i].Length - 1)
                textObject.text += "\n\n";
        }
        yield return new WaitForSeconds(5);
        SceneManager.Ending();
    }

    IEnumerator TypeBossFired()
    {
        for (int i = 0; i < bossFiredEnd.Length; i++)
        {
            audiomanager.PlaySFX("PencilScratch");
            foreach (char c in bossFiredEnd[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            if (i < bossFiredEnd.Length - 1)
                textObject.text += "\n\n";
        }
        yield return new WaitForSeconds(5);
        SceneManager.Ending();
    }

    IEnumerator TypeBossArrested()
    {
        for (int i = 0; i < bossArrestedEnd.Length; i++)
        {
            audiomanager.PlaySFX("PencilScratch");
            foreach (char c in bossArrestedEnd[i].ToCharArray())
            {
                textObject.text += c;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            if (i < bossArrestedEnd.Length - 1)
                textObject.text += "\n\n";
        }
        yield return new WaitForSeconds(5);
        SceneManager.Ending();
    }

    IEnumerator Denied()
    {
        animator.ChangeAnimation(DENIED);
        yield return new WaitForSeconds(4.5f);
        manager.NextNPC();
    }

    //IEnumerator PlayWritingSound()
    //{
       
    //        audiomanager.PlaySFX("PencilScratch");
    //        yield return new WaitForSeconds(playTime);
     
    //}
}
