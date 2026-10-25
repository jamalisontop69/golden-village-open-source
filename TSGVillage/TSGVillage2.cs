using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Entities;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TSGVillage;

public class TSGVillage2 : BloonsTD6Mod
{
	private class BaseTower100 : ModDisplay
	{
		public override string BaseDisplay => "27a416b898a395b47b371788b2913eaf";

		public override void ModifyDisplayNode(UnityDisplayNode node)
		{
			((ModDisplay)this).SetMeshTexture(node, "100");
		}
	}

	private class BaseTower200 : ModDisplay
	{
		public override string BaseDisplay => "27a416b898a395b47b371788b2913eaf";

		public override void ModifyDisplayNode(UnityDisplayNode node)
		{
			((ModDisplay)this).SetMeshTexture(node, "200");
		}
	}

	public class TSGVillage : ModTower
	{
		public override TowerSet TowerSet => (TowerSet)8;

		public override string BaseTower => "MonkeyVillage-100";

		public override int Cost => 100000;

		public override string Portrait => "df307dbea1cab0e4285be3949c4d949a";

		public override string DisplayName => "Sun God Village";

		public override int TopPathUpgrades => 5;

		public override int MiddlePathUpgrades => 5;

		public override int BottomPathUpgrades => 0;

		public override string Description => "For all your god-buffing needs. Replicates the buff of a 4xx Support Temple";

		public override void ModifyBaseTowerModel(TowerModel towerModel)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			TowerModelExt.ApplyDisplay<BaseTower100>(towerModel);
			RangeSupportModel behavior = TowerModelBehaviorExt.GetBehavior<RangeSupportModel>(towerModel);
			((SupportModel)behavior).showBuffIcon = true;
			((SupportModel)behavior).buffIconName = "MonkeyIcons[MonkeyVillageIcon]";
			behavior.multiplier = 0.2f;
			DamageSupportModel support = new DamageSupportModel("DamageSupportModel", true, 2f, "TSGdamage", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, false, 0f);
			PierceSupportModel support2 = new PierceSupportModel("PierceSupportModel", true, 2f, "TSGpierce", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, "SuperMonkeyTemple", "BuffIconTempleSunGod4xx");
			RateSupportModel support3 = new RateSupportModel("RateSupportModel", 0.81f, true, "TSGrate", false, 5, Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), "no", "no", false, (DisplayModel)null);
			BonusCashZoneModel val = new BonusCashZoneModel("BonusCashZoneModel", 1.5f, "TSGzone", "TSGzone", 2);
			AddParagonVariant(towerModel, (SupportModel)(object)support);
			AddParagonVariant(towerModel, (SupportModel)(object)support2);
			AddParagonVariant(towerModel, (SupportModel)(object)support3);
			TowerModelBehaviorExt.AddBehavior<BonusCashZoneModel>(towerModel, val);
		}

		public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
		{
			return towerSet.First((TowerDetailsModel model) => model.towerId == TowerType.SpikeFactory).towerIndex + 1;
		}
	}

	public class ToughUrchins : ModUpgrade<TSGVillage>
	{
		public override int Path => 0;

		public override int Tier => 1;

		public override string DisplayName => "True Sun God Village";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 100000;

		public override string Description => "Replicates the buff of a True Sun God";

		public override void ApplyUpgrade(TowerModel tower)
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			TowerModelExt.ApplyDisplay<BaseTower100>(tower);
			tower.range += 5f;
			RangeSupportModel val = ModelExt.Duplicate<RangeSupportModel>(TowerModelBehaviorExt.GetBehavior<RangeSupportModel>(tower));
			val.mutatorId += 2;
			((Model)val).name = ((Model)val).name + 2;
			DamageSupportModel support = new DamageSupportModel("DamageSupportModel2", true, 2f, "TSGdamage2", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, false, 0f);
			PierceSupportModel support2 = new PierceSupportModel("PierceSupportModel2", true, 3f, "TSGpierce2", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, "SuperMonkeyTemple", "BuffIconTrueSunGod5xx");
			RateSupportModel support3 = new RateSupportModel("RateSupportModel2", 0.81f, true, "TSGrate2", false, 5, Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), "no", "no", false, (DisplayModel)null);
			BonusCashZoneModel val2 = new BonusCashZoneModel("BonusCashZoneModel2", 1.5f, "TSGzone2", "TSGzone", 2);
			AddParagonVariant(tower, (SupportModel)(object)val);
			AddParagonVariant(tower, (SupportModel)(object)support);
			AddParagonVariant(tower, (SupportModel)(object)support2);
			AddParagonVariant(tower, (SupportModel)(object)support3);
			TowerModelBehaviorExt.AddBehavior<BonusCashZoneModel>(tower, val2);
		}
	}

	public class ToughUrchins3 : ModUpgrade<TSGVillage>
	{
		public override int Path => 0;

		public override int Tier => 2;

		public override string DisplayName => "Vengeful True Sun God Village";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 100000;

		public override string Description => "Replicates most passive buffs in the game, including from heroes and Energizing Totem";

		public override void ApplyUpgrade(TowerModel tower)
		{
			if (buffs.Count == 0)
			{
				foreach (TowerModel item in (Il2CppArrayBase<TowerModel>)(object)Game.instance.model.towers)
				{
					if (((!item.IsHero() || item.tier != 20) && (item.IsHero() || item.tier != 5 || (((Il2CppArrayBase<UpgradePathModel>)(object)item.upgrades).Count != 5 && !((Model)item).name.Contains("Village"))) && !((Model)item).name.Contains("Totem") && !((Model)item).name.Contains("Paragon") && !((Model)item).name.Contains("Mermonkey-500")) || ((Model)item).name.Contains("TSGVillage"))
					{
						continue;
					}
					foreach (SupportModel item2 in Il2CppGenericIEnumerableExt.ToList<SupportModel>(((Model)item).GetDescendants<SupportModel>()))
					{
						buffs.Add((Model)(object)ModelExt.Duplicate<SupportModel>(item2));
					}
					foreach (TowerBehaviorBuffModel item3 in Il2CppGenericIEnumerableExt.ToList<TowerBehaviorBuffModel>(((Model)item).GetDescendants<TowerBehaviorBuffModel>()))
					{
						buffs.Add((Model)(object)ModelExt.Duplicate<TowerBehaviorBuffModel>(item3));
					}
				}
			}
			foreach (Model buff in buffs)
			{
				TowerModelBehaviorExt.AddBehavior<Model>(tower, buff);
			}
		}
	}

	public class GeraldoGoodness : ModUpgrade<TSGVillage>
	{
		public override int Path => 0;

		public override int Tier => 3;

		public override string DisplayName => "Geraldo Goodness";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 50000;

		public override string Description => "Applies a passive buff equal to the effects of max Geraldo Jar of Pickles, Sharpening Stone, and See Invisibility. Does not include Jar of Pickles rate penalty, and Sharpening Stone does not require Sharp type damage";

		public override void ApplyUpgrade(TowerModel tower)
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			DamageSupportModel val = new DamageSupportModel("dmg", false, 2f, "PicklesSharpening", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, false, 100f);
			string buffIconName = (((SupportModel)val).buffLocsName = "BuffIconSharpeningStone");
			((SupportModel)val).buffIconName = buffIconName;
			TowerModelBehaviorExt.AddBehavior<DamageSupportModel>(tower, val);
			RangeSupportModel val2 = new RangeSupportModel("range", false, 1.15f, 0f, "SeeRange", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, "BuffIconJarOfPickles", "BuffIconJarOfPickles");
			TowerModelBehaviorExt.AddBehavior<RangeSupportModel>(tower, val2);
			DamageModifierForTagModel val3 = new DamageModifierForTagModel("DamageModifierFort", "Fortified", 1f, 2f, false, true, false);
			DamageModifierForTagModel val4 = ModelExt.Duplicate<DamageModifierForTagModel>(val3);
			val4.tag = "Camo";
			val4.damageAddative = 1f;
			DamageModifierSupportModel val5 = new DamageModifierSupportModel("supp", false, "CamoBonus", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), false, (DamageModifierModel)(object)val3, false, 0f, false);
			DamageModifierSupportModel val6 = ModelExt.Duplicate<DamageModifierSupportModel>(val5);
			val6.damageModifierModel = (DamageModifierModel)(object)val4;
			TowerModelBehaviorExt.AddBehavior<DamageModifierSupportModel>(tower, val5);
			TowerModelBehaviorExt.AddBehavior<DamageModifierSupportModel>(tower, val6);
		}
	}

	public class StackingSimulator : ModUpgrade<TSGVillage>
	{
		public override int Path => 0;

		public override int Tier => 4;

		public override string DisplayName => "Stacking Simulator";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 30000;

		public override string Description => "Ability - Spawns 5 non-attacking Monkeys that each grant a Shinobi Tactics and Poplust stack.";

		public override void ApplyUpgrade(TowerModel tower)
		{
			AttackModel val = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1]);
			TowerModel tower2 = ProjectileModelBehaviorExt.GetBehavior<CreateTowerModel>(AttackModelExt.GetAllProjectiles(val)[0]).tower;
			((EntityModel)tower2).display = ((EntityModel)Game.instance.model.GetTower("DartMonkey", 0, 0, 0)).display;
			tower2.portrait = Game.instance.model.GetTower("DartMonkey", 0, 0, 0).portrait;
			TowerModelBehaviorExt.RemoveBehavior<AttackModel>(tower2);
			TowerModelBehaviorExt.RemoveBehavior<TowerExpireModel>(tower2);
			tower2.range = 50f;
			tower2.cost = 0f;
			tower2.dontDisplayUpgrades = true;
			((Il2CppArrayBase<WeaponModel>)(object)val.weapons)[0].rate = 1.6f;
			SupportShinobiTacticsModel val2 = ModelExt.Duplicate<SupportShinobiTacticsModel>(TowerModelBehaviorExt.GetBehavior<SupportShinobiTacticsModel>(Game.instance.model.GetTower("NinjaMonkey", 0, 3, 0)));
			TowerModelBehaviorExt.AddBehavior<SupportShinobiTacticsModel>(tower2, val2);
			PoplustSupportModel val3 = ModelExt.Duplicate<PoplustSupportModel>(TowerModelBehaviorExt.GetBehavior<PoplustSupportModel>(Game.instance.model.GetTower("Druid", 0, 0, 4)));
			SupportShinobiTacticsModel val4 = ModelExt.Duplicate<SupportShinobiTacticsModel>(val2);
			((TowerBehaviorBuffModel)val4).buffIconName = ((TowerBehaviorBuffModel)val3).buffIconName;
			((TowerBehaviorBuffModel)val4).buffLocsName = ((TowerBehaviorBuffModel)val3).buffLocsName;
			val4.multiplier = 1.15f;
			((SelfStackingSupportCompoundingModel)val4).mutatorId = val3.mutatorId;
			((SelfStackingSupportCompoundingModel)val4).maxStacks = 5;
			FilterInBaseTowerIdModel val5 = ModelExt.Duplicate<FilterInBaseTowerIdModel>(((Il2CppObjectBase)((Il2CppArrayBase<TowerFilterModel>)(object)((SelfStackingSupportCompoundingModel)val4).filters)[0]).Cast<FilterInBaseTowerIdModel>());
			((Il2CppArrayBase<string>)(object)val5.baseIds)[0] = "Druid";
			((SelfStackingSupportCompoundingModel)val4).filters = Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[1] { (TowerFilterModel)val5 });
			TowerModelBehaviorExt.AddBehavior<SupportShinobiTacticsModel>(tower2, val4);
			AbilityModel val6 = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTower("DartlingGunner", 0, 4, 0)));
			((Il2CppArrayBase<AttackModel>)(object)AbilityModelBehaviorExt.GetBehavior<ActivateAttackModel>(val6).attacks)[0] = val;
			val6.icon = ModContent.GetSpriteReference<TSGVillage2>("StackingSimulator-Icon");
			val6.addedViaUpgrade = ((ModContent)this).Id;
			string text = (((Model)val6)._name = "Stacker");
			string displayName = (((Model)val6).name = text);
			val6.displayName = displayName;
			val6.cooldown = 1f;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, val6);
		}
	}

	public class Selfclock : ModUpgrade<TSGVillage>
	{
		public override int Path => 0;

		public override int Tier => 5;

		public override string DisplayName => "Self Overclock Replica";

		public override int Cost => 100000;

		public override string Description => "Towers in range of the Gold Village gain +10% attack speed every round, stacks up to 50 times. Same as Master Builder";

		public override void ApplyUpgrade(TowerModel tower)
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			RoundBasedAttackSpeedModel val = ModelExt.Duplicate<RoundBasedAttackSpeedModel>(TowerModelBehaviorExt.GetBehavior<RoundBasedAttackSpeedModel>(Game.instance.model.GetParagonTower("EngineerMonkey")));
			AddBehaviorToTowerSupportModel val2 = new AddBehaviorToTowerSupportModel("supp", Il2CppReferenceArray<TowerBehaviorModel>.op_Implicit((TowerBehaviorModel[])(object)new TowerBehaviorModel[1] { (TowerBehaviorModel)val }), "Selfclock", Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]), "", "", false);
			((SupportModel)val2).isCustomRadius = false;
			AddParagonVariant(tower, (SupportModel)(object)val2);
		}
	}

	public class SupportAbilities : ModUpgrade<TSGVillage>
	{
		public override int Path => 1;

		public override int Tier => 2;

		public override string DisplayName => "Include Support Abilities";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 100000;

		public override string Description => "Adds all AoE buff abilities in the game. Includes side effect buffs like Absolute Zero for Ice Monkeys or Level 20 Striker";

		public override void ApplyUpgrade(TowerModel tower)
		{
			TowerModelExt.ApplyDisplay<BaseTower200>(tower);
			foreach (TowerModel item in (Il2CppArrayBase<TowerModel>)(object)Game.instance.model.towers)
			{
				if ((!item.IsHero() || item.tier != 20) && (item.IsHero() || !((Model)item).name.Contains("250")) && (item.IsHero() || !((Model)item).name.Contains("MonkeyVillage-040")))
				{
					continue;
				}
				foreach (AbilityModel behavior in TowerModelBehaviorExt.GetBehaviors<AbilityModel>(item))
				{
					if (AbilityModelBehaviorExt.HasBehavior<AbilityBehaviorBuffModel>(behavior) || AbilityModelBehaviorExt.HasBehavior<CallToArmsModel>(behavior) || (((Model)item).name.Contains("Striker") && AbilityModelBehaviorExt.HasBehavior<ArtilleryCommandModel>(behavior)))
					{
						behavior.addedViaUpgrade = ((ModContent)this).Id;
						TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, ModelExt.Duplicate<AbilityModel>(behavior));
					}
				}
			}
		}
	}

	public class TargettedBuffs : ModUpgrade<TSGVillage>
	{
		public override int Path => 1;

		public override int Tier => 1;

		public override string DisplayName => "Targetted Buffs";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 100000;

		public override string Description => "Adds Acidic Dip, Perma Brew and both Overclock versions";

		public override void ApplyUpgrade(TowerModel tower)
		{
			TowerModel val = ModelExt.Duplicate<TowerModel>(Game.instance.model.GetTower("Alchemist", 5, 0, 0));
			TowerModelBehaviorExt.AddBehavior<AttackModel>(tower, ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(val)[2]));
			foreach (AttackModel attackModel in TowerModelExt.GetAttackModels(tower))
			{
				attackModel.range = tower.range;
			}
			TowerModel val2 = ModelExt.Duplicate<TowerModel>(Game.instance.model.GetTower("EngineerMonkey", 0, 4, 0));
			TowerModelExt.GetAbility(val2).addedViaUpgrade = ((ModContent)this).Id;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, TowerModelBehaviorExt.GetBehavior<AbilityModel>(val2));
			AbilityModel val3 = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTower("EngineerMonkey", 0, 5, 0)));
			val3.addedViaUpgrade = ((ModContent)this).Id;
			AbilityModelBehaviorExt.AddBehavior<OverclockPermanentModel>(val3, ModelExt.Duplicate<OverclockPermanentModel>(AbilityModelBehaviorExt.GetBehavior<OverclockPermanentModel>(val3)));
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, val3);
			TowerModelBehaviorExt.AddBehavior<AttackModel>(tower, ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(val)[1]));
		}
	}

	public class MonkeyBoost : ModUpgrade<TSGVillage>
	{
		public override int Path => 1;

		public override int Tier => 5;

		public override string DisplayName => "Monkey Boost Replica";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 70000;

		public override string Description => "Lets turn it up by an arbitrary number! Ability - Replicates the Monkey Boost Power.";

		public override void ApplyUpgrade(TowerModel tower)
		{
			AbilityModel val = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTowerFromId("AdmiralBrickell 3")));
			val.cooldown = 20f;
			val.displayName = "rateReplica";
			((Model)val).name = "rateReplica";
			((Model)val)._name = "rateReplica";
			val.addedViaUpgrade = ((ModContent)this).Id;
			val.icon = ModContent.GetSpriteReference<TSGVillage2>("MonkeyBoost-Icon");
			AbilityModelBehaviorExt.GetBehavior<ActivateRateSupportZoneModel>(val).mutatorId = "BoostReplica";
			AbilityModelBehaviorExt.GetBehavior<ActivateRateSupportZoneModel>(val).filters = Il2CppReferenceArray<TowerFilterModel>.op_Implicit((TowerFilterModel[])(object)new TowerFilterModel[0]);
			((AbilityBehaviorBuffModel)AbilityModelBehaviorExt.GetBehavior<ActivateRateSupportZoneModel>(val)).isGlobal = true;
			AbilityModelBehaviorExt.GetBehavior<CreateEffectOnAbilityModel>(val).effectModel.assetId.guidRef = "6fad0c8bd5aef8240a5a3765bf11c3c5";
			AbilityModelBehaviorExt.GetBehavior<CreateEffectOnAbilityModel>(val).effectModel.lifespan = 18f;
			AbilityModelBehaviorExt.GetBehavior<CreateEffectOnAbilityModel>(val).effectModel.useCenterPosition = true;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, val);
		}
	}

	public class EmbrittleReplica : ModUpgrade<TSGVillage>
	{
		public override int Path => 1;

		public override int Tier => 4;

		public override string DisplayName => "Embrittle Replica";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 40000;

		public override string Description => "Ability - All Bloons are affected by Embrittlement and Super Embrittlement for the next 60 seconds.";

		public override void ApplyUpgrade(TowerModel tower)
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			AttackModel val = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("DartMonkey", 0, 0, 2))[0]);
			val.range = 999f;
			ProjectileModel val2 = AttackModelExt.GetAllProjectiles(val)[0];
			ProjectileModelExt.GetDamageModel(val2).immuneBloonProperties = (BloonProperties)0;
			ProjectileModelExt.GetDamageModel(val2).maxDamage = 0f;
			AddBonusDamagePerHitToBloonModel val3 = new AddBonusDamagePerHitToBloonModel("bonus", "brittleSim", 5f, 5f, 5, true, true, false, "");
			val2.radius = 999f;
			val2.pierce = 999f;
			ProjectileModelBehaviorExt.AddBehavior<AddBonusDamagePerHitToBloonModel>(val2, val3);
			val2.display.guidRef = "";
			AbilityModel val4 = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTower("DartlingGunner", 0, 4, 0)));
			((Model)val4)._name = "embrittle";
			AbilityModelBehaviorExt.GetBehavior<ActivateAttackModel>(val4).lifespan = 60f;
			val4.addedViaUpgrade = ((ModContent)this).Id;
			((Il2CppArrayBase<AttackModel>)(object)AbilityModelBehaviorExt.GetBehavior<ActivateAttackModel>(val4).attacks)[0] = val;
			val4.icon = ModContent.GetSpriteReference<TSGVillage2>("EmbrittleReplica-Icon");
			string displayName = (((Model)val4).name = "embritlee");
			val4.displayName = displayName;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, val4);
		}
	}

	public class KindaBuffs : ModUpgrade<TSGVillage>
	{
		public override int Path => 1;

		public override int Tier => 3;

		public override string DisplayName => "Kinda Buffs";

		public override string Portrait => "d1a8e86a25c13db478f0408cf3395c7a";

		public override int Cost => 50000;

		public override string Description => "Adds 250 Gluestorm and Firestorm (applies Heat It Up) abilities.";

		public override void ApplyUpgrade(TowerModel tower)
		{
			TowerModel val = ModelExt.Duplicate<TowerModel>(Game.instance.model.GetTower("GlueGunner", 2, 5, 0));
			AbilityModel ability = TowerModelExt.GetAbility(val);
			ability.addedViaUpgrade = ((ModContent)this).Id;
			TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, ability);
			foreach (TowerModel item in (Il2CppArrayBase<TowerModel>)(object)Game.instance.model.towers)
			{
				if (item.IsHero() && item.tier == 20 && ((Model)item).name.Contains("Gwen"))
				{
					AbilityModel val2 = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbilities(item)[1]);
					val2.addedViaUpgrade = ((ModContent)this).Id;
					TowerModelBehaviorExt.AddBehavior<AbilityModel>(tower, val2);
				}
			}
		}
	}

	public static List<Model> buffs = new List<Model>();

	public static void AddParagonVariant(TowerModel tower, SupportModel support)
	{
		try
		{
			TowerModelBehaviorExt.AddBehavior<SupportModel>(tower, ModelExt.Duplicate<SupportModel>(support));
			SupportModel val = ModelExt.Duplicate<SupportModel>(support);
			((Model)val).name = ((Model)val).name + "_Paragon";
			val.onlyAffectParagon = true;
			TowerModelBehaviorExt.AddBehavior<SupportModel>(tower, val);
		}
		catch
		{
		}
	}
}
