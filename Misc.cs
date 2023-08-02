using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;
using static PokemonStandardLibrary.Gen8.Pokemon;
namespace Project_extrema
{
    public static class Misc
    {
        public static string[] ToResultArray (uint advance, Individual pk)
        {
            var result = new List<string>();
            result.Add (advance.ToString ());
            result.Add(pk.Nature.ToJapanese());
            result.Add(pk.Ability.ToString());
            foreach(var iv in pk.IVs)result.Add(iv.ToString());
            result.Add(pk.Gender.ToSymbol());
            result.Add(pk.Shiny.ToSymbol());
            result.Add(pk.HeightScale.ToString());
            result.Add(pk.WeightScale.ToString());
            
            return result.ToArray ();
        }
    }

    internal enum GenderCondition
    {
        Male,
        Female,
        Genderless,
        Any
    }
    internal enum ShinyCondition
    {
        StarSquare,
        Star,
        Square,
        Any
    }
    class SearchCondition
    {
        private readonly Nature nature;
        private readonly GenderCondition genderCondition;
        private readonly ShinyCondition shinyCondition;
        
        private readonly byte minHeight;
        private readonly byte maxHeight;
        private readonly byte minWeight;
        private readonly byte maxWeight;

        public SearchCondition(Nature nature, GenderCondition gender, ShinyCondition shinyType, byte minHeight, byte maxHeight, byte minWeight, byte maxWeight)
        {
            this.nature = nature;
            this.genderCondition = gender;
            this.shinyCondition = shinyType;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;


            if (this.minHeight > this.maxHeight)
            {
                (this.minHeight, this.maxHeight) = (this.maxHeight, this.minHeight);
            }


            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
        }

        public bool Validate(Individual pk)
        {
            //絞り込み(頻度の低そうな物を優先する
            //色違い
            if (shinyCondition != ShinyCondition.Any)
            {
                if (shinyCondition == ShinyCondition.StarSquare)
                {
                    if (pk.Shiny == ShinyType.NotShiny) return false;
                }
                else
                {
                    var targetShinyType = (ShinyType)shinyCondition;
                    if (pk.Shiny != targetShinyType) return false;
                }
            }

            //高さ
            if (pk.HeightScale < minHeight) return false;
            if (maxHeight < pk.HeightScale) return false;

            //重さ
            if (pk.WeightScale < minWeight) return false;
            if (maxWeight < pk.WeightScale) return false;
            //性格
            if (nature != Nature.other)
            {
                if (pk.Nature != nature) return false;
            }
            //性別
            if (genderCondition != GenderCondition.Any)
            {
                var gender = (Gender)genderCondition;
                if (pk.Gender != gender) return false;
            }
            return true;
        }
    }
}
