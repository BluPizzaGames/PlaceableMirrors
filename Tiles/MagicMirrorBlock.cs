using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PlaceableMirrors.Tiles
{
	public class MagicMirrorBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileSolid[Type] = true;

			TileID.Sets.AllBlocksWithSmoothBordersToResolveHalfBlockIssue[Type] = true;
			TileID.Sets.GemsparkFramingTypes[Type] = Type;

			DustType = DustID.MagicMirror;
			ItemDrop = ModContent.ItemType<Items.MagicMirrorBlock>();

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("{$Mods.PlaceableMirrors.Tiles.MagicMirrorBlock}");
			AddMapEntry(new Color(151, 221, 229), name);
		}

		public override void ModifyLight(int x, int y, ref float r, ref float g, ref float b)
		{
			r = 0.2f;
			g = 0.4f;
			b = 0.5f;
		}

		public override void MouseOver(int x, int y)
		{
			PlaceableMirrors.MouseOverMirrors(x, y, ItemID.MagicMirror);
		}

		public override bool RightClick(int x, int y)
		{
			return PlaceableMirrors.ToSpawn(x, y, 0);
		}

		public override bool TileFrame(int x, int y, ref bool resetFrame, ref bool noBreak)
		{
			Framing.SelfFrame8Way(x, y, Main.tile[x, y], resetFrame);
			return false;
		}
	}
}