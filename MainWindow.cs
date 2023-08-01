using PokemonBDSPRNGLibrary.Generators;
using PokemonPRNG.XorShift128;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;
using static PokemonStandardLibrary.Gen8.Pokemon;

namespace Project_extrema
{
    public partial class MainForm : Form
    {
        private static readonly string[] SinnohSubLegs = { "ユクシー", "アグノム", "ヒードラン", "レジギガス" };
        private static readonly uint[] SinnohSubLegsLv = { 50, 50, 70, 70 };
        private static readonly string[] SinnohLegsMyths = { "ディアルガ", "パルキア", "ギラティナ", "ダークライ", "シェイミ", "アルセウス" };
        private static readonly uint[] SinnohLegsMythsLv = { 47, 47, 70, 50, 30, 80 };
        private static readonly string[] Roamers = { "エムリット", "クレセリア" };
        private static readonly uint[] RoamersLv = { 50, 50 };

        private static readonly string[] RamanasSubLegs = { "フリーザー", "サンダー", "ファイヤー", "ライコウ", "エンティ", "スイクン", "レジロック", "レジアイス", "レジスチル", "ラティアス", "ラティオス" };
        private static readonly uint[] RamanasSubLegsLv = { 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70 };
        private static readonly string[] RamanasLegs = { "ミュウツー", "ルギア", "ホウオウ", "カイオーガ", "グラードン", "レックウザ" };
        private static readonly uint[] RamanasLegsLv = { 70, 70, 70, 70, 70, 70 };

        private static readonly string[][] spieciesNamesArray = new string[][] { SinnohSubLegs, SinnohLegsMyths, Roamers, RamanasSubLegs, RamanasLegs };
        private static readonly uint[][] spieciesLvsArray = new uint[][] { SinnohSubLegsLv, SinnohLegsMythsLv, RoamersLv, RamanasSubLegsLv, RamanasLegsLv };

        public MainForm()
        {
            InitializeComponent();
            //基本情報内のコンボボックスを初期化
            //イベントリスナーの登録
            SymbolTypeComboBox.TextChanged += SymbolTypeComboBox_TextChanged;

            //検索条件内のコンボボックスを初期化
            //性格
            var naturelist = new List<string>();
            foreach (Nature ntr in Enum.GetValues(typeof(Nature))) naturelist.Add(ntr.ToJapanese());
            NatureComboBox.Items.Clear();
            NatureComboBox.Items.AddRange(naturelist.ToArray());

            SynchronizeComboBox.Items.Clear();
            SynchronizeComboBox.Items.AddRange(naturelist.ToArray()[0..^1]);
            //各コンボボックスのインデックスリセット
            SynchronizeComboBox.SelectedIndex = 0;
            NatureComboBox.SelectedIndex = NatureComboBox.Items.Count - 1;
            GenderComboBox.SelectedIndex = GenderComboBox.Items.Count - 1;
            ShinyComboBox.SelectedIndex = ShinyComboBox.Items.Count - 1;
        }

        private void SymbolTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            var STidx = SymbolTypeComboBox.SelectedIndex;
            if (STidx == -1) return;

            //分類に対応するポケモン名一覧に更新
            SpeciesComboBox.Items.Clear();
            SpeciesComboBox.Items.AddRange(spieciesNamesArray[STidx]);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var stidx = SymbolTypeComboBox.SelectedIndex;
            var spidx = SpeciesComboBox.SelectedIndex;
            if ((stidx == -1) || (spidx == -1)) return;

            //seed0/seed1をs0/s1/s2/s3に直す
            //textboxのBaseSeedからstateを取得
            var x0 = Convert.ToUInt64(seed0.Text, 16);
            var x1 = Convert.ToUInt64(seed1.Text, 16);
            if (x0 == 0 && x1 == 0) return;

            var state = ((uint)(x0 >> 32), (uint)(x0 & 0xFFFFFFFF), (uint)(x1 >> 32), (uint)(x1 & 0xFFFFFFFF));

            //検索範囲の最小値だけstateを進める
            state.Advance((uint)Math.Min(MinSearchRange.Value, MaxSearchRange.Value));
            //追加でdelay分進める
            state.Advance((uint)Delay.Value);

            //Advanceの相対基準 (delayを含めない)
            var initadv = (uint)(Math.Min(MinSearchRange.Value, MaxSearchRange.Value));

            var searchRange = (uint)(Math.Abs(MaxSearchRange.Value - MinSearchRange.Value));

            var pokename = SpeciesComboBox.Text;
            var pokeLv = spieciesLvsArray[stidx][spidx];
            StaticSymbolGenerator generator = new StaticSymbolGenerator(pokename, pokeLv, 3);

            Synchronize sync = new Synchronize(SynchronizeComboBox.Text.ConvertToNature());

            var results = new List<string[]>();
            for (uint i = 0; i < searchRange; i++, state.Advance())
            {
                var pk = UseSynchronize.Checked ? generator.Generate(state, sync) : generator.Generate(state);
                //絞り込み
                //性格
                if (NatureComboBox.Text != "---")
                {
                    var targetNature = NatureComboBox.Text.ConvertToNature();
                    if (pk.Nature != targetNature) continue;
                }
                //性別
                if (GenderComboBox.Text != "-")
                {
                    var targetGender = (Gender)GenderComboBox.SelectedIndex;
                    if (pk.Gender != targetGender) continue;
                }
                //色違い
                if (ShinyComboBox.Text != "-")
                {
                    if (ShinyComboBox.Text == "☆&◇")
                    {
                        if (pk.Shiny == ShinyType.NotShiny) continue;
                    }
                    else
                    {
                        var targetShinyType = (ShinyType)ShinyComboBox.SelectedIndex;
                        if (pk.Shiny != targetShinyType) continue;
                    }
                }
                //高さ
                var minheight = (uint)MinHeight.Value;
                var maxheight = (uint)MaxHeight.Value;
                if (minheight > maxheight)
                {
                    (minheight, maxheight) = (maxheight, minheight);
                }
                if (pk.HeightScale < minheight) continue;
                if (maxheight < pk.HeightScale) continue;


                //重さ
                var minweight = (uint)MinWeight.Value;
                var maxweight = (uint)MaxWeight.Value;
                if (minweight > maxweight)
                {
                    (minweight, maxweight) = (maxweight, minweight);
                }
                if (pk.WeightScale < minweight) continue;
                if (maxweight < pk.WeightScale) continue;

                var advance = initadv + i;
                results.Add(Misc.ToResultArray(advance, pk));
                if (results.Count >= 1000)
                {
                    //TODO:なんかモーダルメッセージを出して打ち切る
                    break;
                }
            }
            //TODO:アホなことしてる気がするのでどうにかしたい
            dataGridView1.Rows.Clear();
            foreach (var row in results) dataGridView1.Rows.Add(row);


        }

        private void UseSynchronize_CheckedChanged(object sender, EventArgs e)
        {
            SynchronizeComboBox.Enabled = UseSynchronize.Checked;
            if (UseSynchronize.Checked)
            {
                NatureComboBox.SelectedIndex = NatureComboBox.Items.Count - 1;
                NatureComboBox.Enabled = false;
            }
            else
            {
                NatureComboBox.Enabled = true;
            }
        }


    }
}