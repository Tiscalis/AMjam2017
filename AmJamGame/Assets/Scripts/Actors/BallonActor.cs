﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonActor : Actor
{
    public override string Move(directionType direction)
    {
        string result = string.Empty;

        WorldManager.Instance.soundManager.PlayEffect(AudioLibrary.soundEffects.StepBalon);
        while (result == string.Empty)
        {
            result = base.Move(direction);
        }

        return result;
    }
}
