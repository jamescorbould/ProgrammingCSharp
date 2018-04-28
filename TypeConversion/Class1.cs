using System;

namespace TypeConversion
{
    public class ClassA
    {
        public virtual string name { get; set; }
    }

    public class ClassB : ClassA
    {
        public override string name { get => base.name; set => base.name = value; }
    }
}
