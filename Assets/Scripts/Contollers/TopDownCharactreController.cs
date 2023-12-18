using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharactreController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnDashEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler Stats {  get; private set; }

    protected virtual void Awake()
    {
        Stats =  GetComponent<CharacterStatsHandler>(); 
    }

    protected virtual void Update() 
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay() 
    {
        if (Stats.CurrentStats.attackSO == null) return;

        if(_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay) {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay) {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 direction) 
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction) 
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallDashEvent()
    {
        OnDashEvent?.Invoke();
    }

    public void CallAttackEvent(AttackSO attackSO) 
    {
        OnAttackEvent?.Invoke(attackSO);

    }



}

////[SerializeField] private float speed = 5f;

//// Start is called before the first frame update
//void Start() {

//}

//// Update is called once per frame
//void Update() {
//    //float x = Input.GetAxisRaw("Horizontal");
//    //float y = Input.GetAxisRaw("Vertical");

//    //transform.position += new Vector3(x, y) * Time.deltaTime * speed;
//}