using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Transformer
    {
        public virtual int wheels { get; set; }
        public virtual int maxSpeed { get; set; }

        public enum Environment { Air, Sea, Land };

        public Transformer()
        {
            wheels = 0;
            maxSpeed = 100;
        }

        public virtual string Run()
        {
            return string.Format("Transformer: no. of wheels = {0}, max speed = {1}", wheels, maxSpeed);
        }
    }

    class Jet : Transformer
    {
        public override int wheels { get; set; }
        public override int maxSpeed { get; set; }

        public Jet()
        {
            wheels = 8;
            maxSpeed = 900;
        }

        public override string Run()
        {
            return string.Format("Jet Transformer: no. of wheels = {0}, max speed = {1}", wheels, maxSpeed);
        }
    }

    class Boat : Transformer
    {
        public override int wheels { get; set; }
        public override int maxSpeed { get; set; }

        public Boat()
        {
            wheels = 0;
            maxSpeed = 200;
        }

        public override string Run()
        {
            return string.Format("Boat Transformer: no. of wheels = {0}, max speed = {1}", wheels, maxSpeed);
        }
    }

    class Train : Transformer
    {
        public override int wheels { get; set; }
        public override int maxSpeed { get; set; }

        public Train()
        {
            wheels = 20;
            maxSpeed = 200;
        }

        public override string Run()
        {
            return string.Format("Train Transformer: no. of wheels = {0}, max speed = {1}", wheels, maxSpeed);
        }
    }
}
