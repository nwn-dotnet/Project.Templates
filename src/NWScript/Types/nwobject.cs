using System;
using System.Collections.Generic;
using NWN.Enums;
using Object = NWN.NWNX.Object;

namespace NWN {
  public class NWObject : NWObjectBase {
    public NWObject(uint oid) : base(oid) {
    }

    public virtual string uuid => NWScript.GetObjectUUID(this);

    public virtual bool IsValidType => true;

    public virtual float Facing {
      get => NWScript.GetFacing(this);
      set => AssignCommand(() => NWScript.SetFacing(value));
    }

    public virtual Vector Position {
      get => NWScript.GetPosition(this);
      set => Object.SetPosition(this, value);
    }

    public virtual Location Location {
      get => NWScript.GetLocation(this);
      set => AssignCommand(() => NWScript.JumpToLocation(value));
    }

    public virtual NWArea Area => NWScript.GetArea(this).AsArea();
    public virtual bool HasInventory => NWScript.GetHasInventory(this) == 1;

    public virtual bool IsPlot {
      get => NWScript.GetPlotFlag(this);
      set => NWScript.SetPlotFlag(this, value);
    }

    public virtual bool IsInConversation => NWScript.IsInConversation(this);

    public virtual bool IsListening {
      get => NWScript.GetIsListening(this);
      set => NWScript.SetListening(this, value);
    }

    public virtual int CurrentHP {
      get => NWScript.GetCurrentHitPoints(this);
      set => Object.SetCurrentHitPoints(this, value);
    }

    public virtual int MaxHP {
      get => NWScript.GetMaxHitPoints(this);
      set => Object.SetMaxHitPoints(this, value);
    }

    public virtual string Description {
      get => NWScript.GetDescription(this);
      set => NWScript.SetDescription(this, value);
    }

    public virtual string OriginalDescription => NWScript.GetDescription(this, true);

    public virtual string Dialog {
      get => Object.GetDialogResref(this);
      set => Object.SetDialogResref(this, value);
    }

    public virtual int Portrait {
      get => NWScript.GetPortraitId(this);
      set => NWScript.SetPortraitId(this, value);
    }

    public virtual int Appearance {
      get => Object.GetAppearance(this);
      set => Object.SetAppearance(this, value);
    }

    public virtual IEnumerable<NWItem> InventoryItems {
      get {
        for (var item = NWScript.GetFirstItemInInventory(this).AsItem();
          item;
          item = NWScript.GetNextItemInInventory(this).AsItem())
          yield return item;
      }
    }

    public virtual IEnumerable<Effect> Effects {
      get {
        for (var effect = NWScript.GetFirstEffect(this);
          NWScript.GetIsEffectValid(effect) == 1;
          effect = NWScript.GetNextEffect(this))
          yield return effect;
      }
    }

    public bool HasVFX(int nVFX) {
      return Object.GetHasVisualEffect(this, nVFX) == 1;
    }

    public void Destroy(float delay = 0.0f) {
      NWScript.DestroyObject(this, delay);
    }

    public void AddToArea(NWArea area, Vector pos) {
      Object.AddToArea(this, area, pos);
    }

    public void ClearInventory() {
      foreach (var item in InventoryItems) {
        if (item.HasInventory)
          foreach (var item2 in item.InventoryItems)
            item2.Destroy();
        item.Destroy();
      }

      if (ObjectType != ObjectType.Creature) return;
      foreach (var currentSlot in Enum.GetValues(typeof(InventorySlot)))
        NWScript.DestroyObject(NWScript.GetItemInSlot((InventorySlot) currentSlot!, this));
    }
  }
}