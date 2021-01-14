using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("FX prefab")] [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scoreValue = 10;
    [SerializeField] int hitPoints = 1;

    ScoreBoard scoreBoard;
    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollder();
    }

    void AddNonTriggerBoxCollder() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void Update() {

    }

    public void handleWeaponDamage(GameObject weapon) {
        WeaponController weaponController = weapon.GetComponent<WeaponController>();
        hitPoints -= weaponController.getDamage();
        if (hitPoints <= 0) {
            GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
            scoreBoard.IncreaseScore(scoreValue);
            scoreBoard.AdjustMult(1);
        }
    }

    private void OnParticleCollision(GameObject other) {
        print("Particles collided with " + other.name);
        if (other.tag == "weapon") handleWeaponDamage(other);
    }
}
