﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chraft.PluginSystem.Blocks;
using Chraft.Utilities;

namespace Chraft.PluginSystem
{
    public interface IEntityBase
    {
        int EntityId { get; }
        bool NoClip { get; set; }
        BoundingBox BoundingBox { get; set; }
        bool HasCollided { get; set; }
        bool HasCollidedHorizontally { get; set; }
        bool HasCollidedVertically { get; set; }
        bool OnGround { get; set; }
        float FallDistance { get; set; }
        float Height { get; set; }
        float Width { get; set; }
        bool Collidable { get; }
        bool Pushable { get; }

        bool PreventMobSpawning { get; }

        double Pitch { get; set; }

        double Yaw { get; set; }

        sbyte PackedPitch { get; }
        sbyte PackedYaw { get; }
        AbsWorldCoords Position { get; set; }
        UniversalCoords BlockPosition { get; }

        BoundingBox? GetCollisionBox(IEntityBase entity);

        IWorldManager GetWorld();
        IServer GetServer();
        List<IStructBlock> GetNearbyBlocks();

        AbsWorldCoords ApplyVelocity(Vector3 velocity);

        void Fall(float distance);

        void MoveTo(AbsWorldCoords absCoords);

        bool TeleportTo(AbsWorldCoords absCoords);

        void RotateTo(float yaw, float pitch);

        void MoveTo(AbsWorldCoords absCoords, float yaw, float pitch);
    }
}
