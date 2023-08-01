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
}
