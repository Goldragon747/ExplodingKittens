using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingKittensLib.Models.Cards
{
    public class BeardedCat : Pair
    {
        public BeardedCat(Game game, int id)
            : base(game, id, "Bearded Cat")
        {
        }
    }
}
