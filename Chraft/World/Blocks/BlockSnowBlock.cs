﻿#region C#raft License
// This file is part of C#raft. Copyright C#raft Team 
// 
// C#raft is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
#endregion
using System.Collections.Generic;
using Chraft.Entity;
using Chraft.Interfaces;
using Chraft.PluginSystem.Blocks;
using Chraft.Utilities;

namespace Chraft.World.Blocks
{
    class BlockSnowBlock : BlockBase
    {
        public BlockSnowBlock()
        {
            Name = "SnowBlock";
            Type = BlockData.Blocks.Snow_Block;
            IsSolid = true;
        }

        protected override void DropItems(EntityBase entity, StructBlock block, List<ItemStack> overridedLoot = null)
        {
            // SnowBlock requires 9 snowballs to craft and drops 4-6 snowballs upon destruction.
            // No tools required.
            overridedLoot = new List<ItemStack>();
            overridedLoot.Add(new ItemStack((short)BlockData.Items.Snowball, (sbyte)(4 + block.World.Server.Rand.Next(2))));
            base.DropItems(entity, block, overridedLoot);
        }
    }
}
