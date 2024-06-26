﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityGameLibrary
{
    public enum CollisionAction
    {
        IncreaseHealth,
        DecreaseHealth,
        ReverseMovement,
        DecreasePlayerHealthByBullet,
        DecreaseEnemyHealthByBullet,
        Kill
    }
}
