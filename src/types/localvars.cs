using static NWN.NWScript;
using System.Collections.Generic;

namespace NWN
{
    public abstract class Locals<T>
    {
        protected NWObjectBase Object;
        public Locals(NWObjectBase obj)
        {
            Object = obj;
        }

        public abstract T Get(string key);
        public abstract void Set(string key, T value);
        public abstract void Delete(string key);

        public T this[string key]
        {
            get => Get(key);
            set => Set(key, value);
        }
    }

    public class LocalInts : Locals<int>
    {
        public LocalInts(NWObjectBase o) : base(o) { }
        public override int Get(string key)             { return GetLocalInt(Object, key); }
        public override void Set(string key, int value) { SetLocalInt(Object, key, value); }
        public override void Delete(string key)         { DeleteLocalInt(Object, key);}
    }

    public class LocalStrings : Locals<string>
    {
        public LocalStrings(NWObjectBase o) : base(o) { }
        public override string Get(string key)             { return GetLocalString(Object, key); }
        public override void Set(string key, string value) { SetLocalString(Object, key, value); }
        public override void Delete(string key)            { DeleteLocalString(Object, key);}
    }

    public class LocalFloats : Locals<float>
    {
        public LocalFloats(NWObjectBase o) : base(o) { }
        public override float Get(string key)             { return GetLocalFloat(Object, key); }
        public override void Set(string key, float value) { SetLocalFloat(Object, key, value); }
        public override void Delete(string key)           { DeleteLocalFloat(Object, key);}
    }

    public class LocalObjects : Locals<NWObjectBase>
    {
        public LocalObjects(NWObjectBase o) : base(o) { }
        public override NWObjectBase Get(string key)             { return GetLocalObject(Object, key).AsObject(); }
        public override void Set(string key, NWObjectBase value) { SetLocalObject(Object, key, value); }
        public override void Delete(string key)                  { DeleteLocalObject(Object, key);}
    }
    
    public class LocalLocations : Locals<Location>
    {
        public LocalLocations(NWObjectBase o) : base(o) { }
        public override Location Get(string key)             { return GetLocalLocation(Object, key); }
        public override void Set(string key, Location value) { SetLocalLocation(Object, key, value); }
        public override void Delete(string key)                { DeleteLocalLocation(Object, key);}
    }

    public class AllLocals
    {
        protected NWObjectBase objbase;
        public LocalInts Int;
        public LocalStrings String;
        public LocalFloats Float;
        public LocalObjects Object;
        public LocalLocations Location;

        public AllLocals(NWObjectBase o)
        {
            Int = new LocalInts(o);
            String = new LocalStrings(o);
            Float = new LocalFloats(o);
            Object = new LocalObjects(o);
            Location = new LocalLocations(o);
        }

        public IEnumerable<NWNX.Object.LocalVariable> All
        {
            get
            {
                int count = NWNX.Object.GetLocalVariableCount(objbase);
                for (int i = 0; i < count; i++)
                {
                    yield return NWNX.Object.GetLocalVariable(objbase, i);
                }
            }
        }
    }
}
