#region C#raft License
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chraft.Entity.Items;
using Chraft.Net;
using Chraft.Utilities;
using Chraft.Utilities.Blocks;
using Chraft.Utilities.Coords;
using Chraft.Utilities.Misc;
using Chraft.World;

namespace Chraft.Entity.Mobs
{
    public class Cow: Animal
    {
        public override string Name
        {
            get { return "Cow"; }
        }

        public override short MaxHealth { get { return 10; } }

        internal Cow(Chraft.World.WorldManager world, int entityId, Chraft.Net.MetaData data = null)
            : base(world, entityId, MobType.Cow, data)
        {
        }

        protected override void DoDeath(EntityBase killedBy)
        {
            sbyte count = (sbyte)Server.Rand.Next(2);
            if (count > 0)
            {
                var item = ItemHelper.GetInstance(BlockData.Items.Leather);
                item.Count = count;
                item.Durability = 0;
                Server.DropItem(World, UniversalCoords.FromAbsWorld(Position.X, Position.Y, Position.Z), item);
            }
            base.DoDeath(killedBy);
        }
    }
}
