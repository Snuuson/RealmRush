using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DamageType
    {
        basic,
        frost,
        fire,
        dark,
        chaos

    }
public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int cost = 75;
    public int Cost{get{return cost;}}
    [SerializeField] float refundPercent = 0.25f;
    public float RefundPercent{get{return refundPercent;}}
    [SerializeField] float buildDelay = 1f;
    [SerializeField] int damage = 1;
    public int Damage{get{return damage;}}
    [SerializeField] DamageType damageType = DamageType.basic;
    public DamageType DamageType{get{return damageType;}}
    
    void Start()
    {
        StartCoroutine(Build());
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateTower(Tower tower,Vector3 position) 
    {
        Audio audio = FindObjectOfType<Audio>();
        
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) 
        {
            return null;
        }
        if (bank.CurrentBalance >= cost)
        {
            bank.Withdraw(cost);
            GameObject resultTower = Instantiate(tower.gameObject, position, Quaternion.identity);
            return resultTower;
        }
        else 
        {
            //Play Sound 
            audio.PlayNotEnoughMinerals();
            
        }

        return null;
        
    }

    
    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            
            foreach(Transform grandChild in child)
            {
                child.gameObject.SetActive(false);
                foreach(Transform grandGrandChild in child)
                {
                    grandGrandChild.gameObject.SetActive(false);
                }
                
            }
        }

        foreach(Transform child in transform)
        {
            
            foreach(Transform grandChild in child)
            {
                child.gameObject.SetActive(true);
                foreach(Transform grandGrandChild in child)
                {
                    grandGrandChild.gameObject.SetActive(true);
                    yield return new WaitForSeconds(buildDelay);
                }
                
                
            }
        }
    }

   
}
