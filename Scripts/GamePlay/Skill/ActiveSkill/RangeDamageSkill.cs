﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 简单范围型技能：
///     将对一个范围内的敌人造成一定的伤害
/// </summary>
public class RangeDamageSkill : ActiveSkill{

    public override bool IsMustDesignation {
        get {
            return false;
        }
    }

    public override void Execute(CharacterMono speller, Vector3 position) {

        base.Execute(speller,position);

        Collider[] targetList = Physics.OverlapSphere(position,SkillInfluenceRadius - (0.12f*(skillInfluenceRadius/0.5f)));
        foreach (var collider in targetList) {
            CharacterMono characterMono = collider.GetComponent<CharacterMono>();
            if (characterMono != null) {
                characterMono.characterModel.Damaged(new Damage(0,PlusDamage));
            }
        }
    }
}
