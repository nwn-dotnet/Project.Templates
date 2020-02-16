using System;
using System.Collections.Generic;

namespace NWN
{
    public class NWObject : NWObjectBase
    {
        public NWObject(uint oid) : base(oid) {}

        public virtual bool IsValidType => true;

        public virtual float Facing
        {
            get => NWScript.GetFacing(this);
            set => AssignCommand(() => NWScript.SetFacing(value));
        }
        public virtual Vector Position
        {
            get => NWScript.GetPosition(this);
            set => NWNX.Object.SetPosition(this, value);
        }
        public virtual Location Location
        {
            get => NWScript.GetLocation(this);
            set => AssignCommand(() => NWScript.JumpToLocation(value));
        }
        public virtual NWArea Area => NWScript.GetArea(this).AsArea();
        public virtual bool HasInventory => NWScript.GetHasInventory(this) == 1;
        public virtual bool IsPlot
        {
            get => NWScript.GetPlotFlag(this) == 1;
            set => NWScript.SetPlotFlag(this, value ? 1 : 0);
        }
        public virtual bool IsInConversation => NWScript.IsInConversation(this) == 1;
        public virtual bool IsListening
        {
            get => NWScript.GetIsListening(this) == 1;
            set => NWScript.SetListening(this, value ? 1 : 0);
        }
        public virtual int CurrentHP
        {
            get => NWScript.GetCurrentHitPoints(this);
            set => NWNX.Object.SetCurrentHitPoints(this, value);
        }
        public virtual int MaxHP
        {
            get => NWScript.GetMaxHitPoints(this);
            set => NWNX.Object.SetMaxHitPoints(this, value);
        }
        public virtual string Description
        {
            get => NWScript.GetDescription(this);
            set => NWScript.SetDescription(this, value);
        }
        public virtual string OriginalDescription => NWScript.GetDescription(this, 1);
        public virtual string Dialog
        {
            get => NWNX.Object.GetDialogResref(this);
            set => NWNX.Object.SetDialogResref(this, value);
        }
        // public virtual string Portrait
        // {
        //     get => NWNX.Object.GetPortrait(this);
        //     set => NWNX.Object.SetPortrait(this, value);
        // }
        public virtual int Appearance
        {
            get => NWNX.Object.GetAppearance(this);
            set => NWNX.Object.SetAppearance(this, value);
        }
        public virtual IEnumerable<NWItem> InventoryItems
        {
            get
            {
                for (NWItem item = NWScript.GetFirstItemInInventory(this).AsItem();
                     item;
                     item = NWScript.GetNextItemInInventory(this).AsItem())
                {
                    yield return item;
                }
            }
        }
        public virtual IEnumerable<Effect> Effects
        {
            get
            {
                for (Effect effect = NWScript.GetFirstEffect(this);
                     NWScript.GetIsEffectValid(effect) == 1;
                     effect = NWScript.GetNextEffect(this))
                {
                    yield return effect;
                }
            }
        }
        public bool HasVFX(int nVFX)
        {
            return NWNX.Object.GetHasVisualEffect(this, nVFX) == 1;
        }
        public void Destroy(float delay=0.0f)
        {
            NWScript.DestroyObject(this, delay);
        }
        public void AddToArea(NWArea area, Vector pos)
        {
            NWNX.Object.AddToArea(this, area, pos);
        }
        public void ClearInventory()
        {
            foreach (NWItem item in InventoryItems)
            {
                if (item.HasInventory)
                    foreach (NWItem item2 in item.InventoryItems) item2.Destroy();
                item.Destroy();
            }
            if (ObjectType == ObjectType.Creature)
                for (int i = 0; i < NWScript.NUM_INVENTORY_SLOTS; i++)
                    NWScript.DestroyObject(NWScript.GetItemInSlot(i, this));
        }
    }

}
