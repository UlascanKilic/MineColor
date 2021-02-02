using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSystem : MonoBehaviour
{

    [SerializeField]
    ScoreManager scoresys;

    [SerializeField]
    Button skill1, skill2;

    [SerializeField]
    MineCartMovement minecartmovement;

    [SerializeField]
    public float skillTwoCost;

    bool isSkillsUsable;

    public float multiplier;
    void Start()
    {
        isSkillsUsable = true;
        skill1.image.enabled = false;
        skill2.image.enabled = false;
        StartCoroutine(CoolDown(0f));
    }
    void Update()
    {
        if (minecartmovement.currentHealth > 20)
        {
            skill1.image.enabled = true;
        }
        if (scoresys.scoreCount > skillTwoCost)
        {
            skill2.image.enabled = true;
        }
    }

    public void SkillOne()
    {
        if (isSkillsUsable)
        {
            if (minecartmovement.currentHealth > 20)
            {
                minecartmovement.currentHealth -= 20; 
                scoresys.pointsPerSecond *= multiplier;
                ControlSkills();
                StartCoroutine(CoolDown(5f));
            }                   
        }     
    }
    public void SkillTwo()
    {
        if (isSkillsUsable)
        {         
            scoresys.scoreCount -= skillTwoCost;
            ControlSkills();

            minecartmovement.currentHealth = 100;
            StartCoroutine(CoolDown(7f));

        }
      
    }

    private void ControlSkills()
    {
        if (scoresys.scoreCount < 50)
        {
            skill1.image.enabled = false;
        }
        if (scoresys.scoreCount < skillTwoCost)
        {
            skill2.image.enabled = false;
        }
    }

    IEnumerator CoolDown(float cooldown)
    {
       
        isSkillsUsable = false;
       
        yield return new WaitForSeconds(cooldown);

        if(scoresys.pointsPerSecond > 5)
        {
            scoresys.pointsPerSecond /= multiplier;
        }
        isSkillsUsable = true;
        
    }
}
