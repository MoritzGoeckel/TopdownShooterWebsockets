using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopdownShooterSever
{
    class Map
    {
        public List<Actor> actors = new List<Actor>();
        public Dictionary<string, Actor> changedActors = new Dictionary<string, Actor>();

        public Dictionary<string, List<Actor>> actorsViaType = new Dictionary<string, List<Actor>>();

        public void addActor(Actor actor)
        {
            actors.Add(actor);
            changedActors.Add(actor.id, actor);

            if (actorsViaType.ContainsKey(actor.typ) == false)
                actorsViaType.Add(actor.typ, new List<Actor>());

            actorsViaType[actor.typ].Add(actor);
        }

        public void setActorChanged(Actor actor)
        {
            if(changedActors.ContainsKey(actor.id) == false)
                changedActors.Add(actor.id, actor);
        }

        public void resetChangedActors()
        {
            changedActors.Clear();
        }

        public void checkBulletCollision()
        {
            foreach(Actor player in actorsViaType[TypNames.Player])
            {
                foreach (Actor bullet in actorsViaType[TypNames.Bullet])
                {
                    if((player.position - bullet.position).Length() < 1)
                    {
                        player.extras["live"] -= bullet.extras["demage"];
                        setActorChanged(player);

                        bullet.remove = true;
                        setActorChanged(bullet);
                    }
                }
            }
        }
    }
}
