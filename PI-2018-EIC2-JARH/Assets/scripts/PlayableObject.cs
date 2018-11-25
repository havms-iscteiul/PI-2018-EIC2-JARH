using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableObject : MonoBehaviour {

    private GameObject playableObject;

    private int life;
    public int Life => this.life;

    private int min_attack;
    public int Min_Attack => this.min_attack;

    private int max_attack;
    public int Max_Attack => this.max_attack;

    private int defence;
    public int Defence => this.defence;

    PlayableObject(int life, int min_attack, int max_attack, int defence, GameObject playableObject) { 
        this.life = life;
        this.min_attack = min_attack;
        this.max_attack = max_attack;
        this.defence = defence;
        this.playableObject = playableObject;
    }

    public void gainLife(int lifeGained)
    {
        this.life += lifeGained;
    }

    public void loseLife(int lifeLost)
    {
        this.life -= lifeLost;
    }

    public void gainedMinAttack(int minAttackGained)
    {
        this.min_attack += minAttackGained;
    }

    public void loseMinAttack(int minAttackLost)
    {
        this.min_attack -= minAttackLost;
    }

    public void gainedMaxAttack(int maxAttackGained)
    {
        this.max_attack += maxAttackGained;
    }

    public void loseMaxAttack(int maxAttackLost)
    {
        this.max_attack -= maxAttackLost;
    }

    public void gainDefence(int defenceGained)
    {
        this.defence += defenceGained;
    }

    public void loseDefence(int defenceLost)
    {
        this.defence -= defenceLost;
    }
}
