using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace WorldZ
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldFactory Earth = new WorldFactory(new Earth());
            WorldFactory Venus = new WorldFactory(new Venus());
            WorldFactory Mars = new WorldFactory(new Mars());
            Earth.createWorld();
            Venus.createWorld();
            Mars.createWorld();
            Earth.showFoodChain();
            Venus.showFoodChain();
            Mars.showFoodChain();
        }
        abstract class Plant
        {
            public abstract void Growth();
        }
        abstract class Herbivore
        {
            public abstract void eatPlant();
        }
        abstract class Predator
        {
            public abstract void eatHerbivore();
        }
        class Sunflower : Plant
        {
            public override void Growth()
            {
                WriteLine("\tHello, im Sunflower. Im from Earth. Dont eat me!!!");
            }
        }
        class Chamomile : Plant
        {
            public override void Growth()
            {
                WriteLine("\tHello, im Chamomile. Im from Venus. I taste good!!!");
            }
        }
        class Blowball : Plant
        {
            public override void Growth()
            {
                WriteLine("\tHello, im Blowball!!! Im from Mars!");
            }
        }
        class Rabbit : Herbivore
        {
            public override void eatPlant()
            {
                WriteLine("\tIm Rabbit, Im from Earth. I eat Sunflower!!!");
            }
        }
        class Deer : Herbivore
        {
            public override void eatPlant()
            {
                WriteLine("\tIm Deer, Im from Venus. I eat Chamomoli!!!");
            }
        }
        class Beaver : Herbivore
        {
            public override void eatPlant()
            {
                WriteLine("\tIm Beaver, Im from Mars. I eat Blowball!!!");
            }
        }
        class Tiger : Predator
        {
            public override void eatHerbivore()
            {
                WriteLine("\tIm Tiger, Im from Earth. I eat Rabbits!!!");
            }
        }
        class Lion : Predator
        {
            public override void eatHerbivore()
            {
                WriteLine("\tIm Lion, Im from Venus. I eat Deers");
            }
        }
        class Wolf : Predator
        {
            public override void eatHerbivore()
            {
                WriteLine("\tIm Wolf, Im from Mars. I eat Beavers");
            }
        }
        abstract class AbstractPlanet
        {
            public abstract Plant createPlant();
            public abstract Herbivore createHerbivore();
            public abstract Predator createPredator();
        }
        class Earth : AbstractPlanet
        {
            public override Plant createPlant()
            {
                return new Sunflower();
            }
            public override Herbivore createHerbivore()
            {
                return new Rabbit();
            }
            public override Predator createPredator()
            {
                return new Tiger();
            }
        }
        class Venus : AbstractPlanet
        {
            public override Plant createPlant()
            {
                return new Chamomile();
            }
            public override Herbivore createHerbivore()
            {
                return new Deer();
            }
            public override Predator createPredator()
            {
                return new Lion();
            }
        }
        class Mars : AbstractPlanet
        {
            public override Plant createPlant()
            {
                return new Blowball();
            }
            public override Herbivore createHerbivore()
            {
                return new Beaver();
            }
            public override Predator createPredator()
            {
                return new Wolf();
            }
        }
        class WorldFactory
        {
            Plant plant;
            Herbivore herbivore;
            Predator predator;
            AbstractPlanet planet;
            public WorldFactory(AbstractPlanet planet)
            {
                this.planet = planet;
            }
            public void createWorld()
            {
                plant = planet.createPlant();
                herbivore = planet.createHerbivore();
                predator = planet.createPredator();
            }
            public void showFoodChain()
            {
                plant.Growth();
                herbivore.eatPlant();
                predator.eatHerbivore();
            }
        }
    }
}
