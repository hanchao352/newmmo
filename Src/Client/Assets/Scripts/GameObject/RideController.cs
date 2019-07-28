﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillBridge.Message;
using UnityEngine;


public class RideController : MonoBehaviour
{
    
    public Transform mountPoint;
    public EntityController rider;
    public Vector3 offset;
    private Animator anim;

    private void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }
    private void Update()
    {
        if (this.mountPoint == null || this.rider == null) return;

        this.rider.SetRidePotision(this.mountPoint.position + this.mountPoint.TransformDirection(this.offset)) ;
    }

    internal void SetRider(EntityController rider)
    {
        this.rider = rider;
    }

    internal void OnEntityEvent(EntityEvent entityEvent, int param)
    {
        switch (entityEvent)
        {
           
            case EntityEvent.Idle:
                anim.SetBool("Move",false);
                anim.SetTrigger("Idle");
                break;
            case EntityEvent.MoveFwd:
                anim.SetBool("Move", true);              
                break;
            case EntityEvent.MoveBack:
                anim.SetBool("Move", true);
                break;
            case EntityEvent.Jump:
                anim.SetBool("Jump", true);
                break;                   
        }
    }

  
}

