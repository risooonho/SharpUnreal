﻿using System;
using System.Collections.Generic;

namespace UnrealEngine
{
    public class ProjectileMovementComponent : MovementComponent
    {
        public float InitialSpeed
        {
            get;
            set;
        }

        public bool RotationFollowsVelocity
        {
            get;
            set;
        }

        public bool ShouldBounce
        {
            get;
            set;
        }

        public bool InitialVelocityInLocalSpace
        {
            get;
            set;
        }

        public bool ForceSubStepping
        {
            get;
            set;
        }

        public bool IsHomingProjectile
        {
            get;
            set;
        }

        public bool BounceAngleAffectsFriction
        {
            get;
            set;
        }

        public bool IsSliding
        {
            get;
            set;
        }

        public float PreviousHitTime
        {
            get;
            set;
        }

        public Vector PreviousHitNormal
        {
            get;
            set;
        }

        public float ProjectileGravityScale
        {
            get;
            set;
        }

        public float Buoyancy
        {
            get;
            set;
        }

        public float Bounciness
        {
            get;
            set;
        }

        public float Friction
        {
            get;
            set;
        }

        public float BounceVelocityStopSimulatingThreshold
        {
            get;
            set;
        }
    }
}
