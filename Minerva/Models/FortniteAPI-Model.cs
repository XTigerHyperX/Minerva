using System;
using System.Collections.Generic;
using System.Diagnostics;
using Fortnite_API.Objects.V2;
using I = Newtonsoft.Json.JsonIgnoreAttribute;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace Minerva.Models
{
	[DebuggerDisplay("{" + nameof(Id) + "}")]
	public class Cosmetics : IEquatable<Cosmetics>
	{

		[J] public string Id { get; private set; }
		[J] public string Name { get; private set; }
		[J] public string Description { get; private set; }
		[J] public string ExclusiveDescription { get; private set; }
		[J] public string UnlockRequirements { get; private set; }
		[J] public string CustomExclusiveCallout { get; private set; }
		[J] public BrCosmeticV2Type Type { get; private set; }
		[J] public BrCosmeticV2Rarity Rarity { get; private set; }
		[J] public BrCosmeticV2Series Series { get; private set; }
		[J] public BrCosmeticV2Set Set { get; private set; }
		[J] public BrCosmeticV2Introduction Introduction { get; private set; }
		[J] public BrCosmeticV2Images Images { get; private set; }
		[J] public List<BrCosmeticV2Variant> Variants { get; private set; }
		[J] public List<string> BuiltInEmoteIds { get; private set; }
		[J] public List<string> GameplayTags { get; private set; } 
		[J] public string DynamicPakId { get; private set; }
		[J] public string DisplayAssetPath { get; private set; }
		[J] public string DefinitionPath { get; private set; }
		[J] public string Path { get; private set; }
		[J] public DateTime Added { get; private set; }
		[J] public List<DateTime> ShopHistory { get; private set; }

		[I] public bool HasSeries => Series != null;
		[I] public bool HasSet => Set != null;
		[I] public bool HasIntroduction => Introduction != null;
		[I] public bool HasVariants => Variants != null && Variants.Count != 0;
		[I] public bool HasBuiltInEmoteIds => BuiltInEmoteIds != null && BuiltInEmoteIds.Count != 0;
		[I] public bool HasGameplayTags => GameplayTags != null && GameplayTags.Count != 0;
		[I] public bool HasDynamicPakId => DynamicPakId != null;
		[I] public bool HasDisplayAssetPath => DisplayAssetPath != null;
		[I] public bool HasDefinitionPath => DefinitionPath != null;
		[I] public bool HasShopHistory => ShopHistory != null;

		public bool Equals(Cosmetics other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Id == other.Id;
		}
	}
}