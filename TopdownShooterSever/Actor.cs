using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopdownShooterSever
{
    class Actor
    {
        public string typ, id;
        public Vector2 position;

        public bool remove = false;

        public Dictionary<string, double> extras;
    }
}
