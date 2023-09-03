using PokemonBDSPRNGLibrary.Generators;
using PokemonPRNG.XorShift128;
using PokemonStandardLibrary;
using PokemonStandardLibrary.CommonExtension;
using static PokemonStandardLibrary.Gen8.Pokemon;

namespace Project_extrema
{
    public partial class BDSPSearchForm : Form
    {
        private static readonly string[] SinnohSubLegs = { "���N�V�[", "�A�O�m��", "�q�[�h����", "���W�M�K�X" };
        private static readonly uint[] SinnohSubLegsLv = { 50, 50, 70, 70 };
        private static readonly string[] SinnohLegsMyths = { "�f�B�A���K", "�p���L�A", "�M���e�B�i", "�_�[�N���C", "�V�F�C�~", "�A���Z�E�X" };
        private static readonly uint[] SinnohLegsMythsLv = { 47, 47, 70, 50, 30, 80 };
        private static readonly string[] Roamers = { "�G�����b�g", "�N���Z���A" };
        private static readonly uint[] RoamersLv = { 50, 50 };

        private static readonly string[] RamanasSubLegs = { "�t���[�U�[", "�T���_�[", "�t�@�C���[", "���C�R�E", "�G���e�C", "�X�C�N��", "���W���b�N", "���W�A�C�X", "���W�X�`��", "���e�B�A�X", "���e�B�I�X" };
        private static readonly uint[] RamanasSubLegsLv = { 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70 };
        private static readonly string[] RamanasLegs = { "�~���E�c�[", "���M�A", "�z�E�I�E", "�J�C�I�[�K", "�O���[�h��", "���b�N�E�U" };
        private static readonly uint[] RamanasLegsLv = { 70, 70, 70, 70, 70, 70 };

        private static readonly string[] Gifts = { "�~���E", "�W���[�`" };
        private static readonly uint[] GiftsLv = { 1, 5 };

        private static readonly string[][] spieciesNamesArray = new string[][] { SinnohSubLegs, SinnohLegsMyths, Roamers, RamanasSubLegs, RamanasLegs, Gifts };
        private static readonly uint[][] spieciesLvsArray = new uint[][] { SinnohSubLegsLv, SinnohLegsMythsLv, RoamersLv, RamanasSubLegsLv, RamanasLegsLv, GiftsLv };

        public BDSPSearchForm()
        {
            InitializeComponent();
            //��{�����̃R���{�{�b�N�X��������
            //�C�x���g���X�i�[�̓o�^
            SymbolTypeComboBox.TextChanged += SymbolTypeComboBox_TextChanged;

            //�����������̃R���{�{�b�N�X��������
            //���i
            var naturelist = new List<string>();
            foreach (Nature ntr in Enum.GetValues(typeof(Nature))) naturelist.Add(ntr.ToJapanese());
            NatureComboBox.Items.Clear();
            NatureComboBox.Items.AddRange(naturelist.ToArray());

            SynchronizeComboBox.Items.Clear();
            SynchronizeComboBox.Items.AddRange(naturelist.ToArray()[0..^1]);
            //�e�R���{�{�b�N�X�̃C���f�b�N�X���Z�b�g
            SymbolTypeComboBox.SelectedIndex = 0;
            SpeciesComboBox.SelectedIndex = 0;
            SynchronizeComboBox.SelectedIndex = 0;
            NatureComboBox.SelectedIndex = NatureComboBox.Items.Count - 1;
            GenderComboBox.SelectedIndex = GenderComboBox.Items.Count - 1;
            ShinyComboBox.SelectedIndex = ShinyComboBox.Items.Count - 1;
        }

        private void SymbolTypeComboBox_TextChanged(object? sender, EventArgs e)
        {
            var STidx = SymbolTypeComboBox.SelectedIndex;
            if (STidx == -1) return;

            //���ނɑΉ�����|�P�������ꗗ�ɍX�V
            SpeciesComboBox.Items.Clear();
            SpeciesComboBox.Items.AddRange(spieciesNamesArray[STidx]);
            SpeciesComboBox.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var stidx = SymbolTypeComboBox.SelectedIndex;
            var spidx = SpeciesComboBox.SelectedIndex;
            if ((stidx == -1) || (spidx == -1)) return;

            //seed0/seed1��s0/s1/s2/s3�ɒ���
            //textbox��BaseSeed����state���擾
            var x0 = Convert.ToUInt64(seed0.Text, 16);
            var x1 = Convert.ToUInt64(seed1.Text, 16);
            if (x0 == 0 && x1 == 0) return;

            var state = ((uint)(x0 >> 32), (uint)(x0 & 0xFFFFFFFF), (uint)(x1 >> 32), (uint)(x1 & 0xFFFFFFFF));

            //�����͈͂̍ŏ��l����state��i�߂�
            state.Advance((uint)Math.Min(MinSearchRange.Value, MaxSearchRange.Value));
            //�ǉ���delay���i�߂�
            state.Advance((uint)Delay.Value);

            //Advance�̑��Ί (delay���܂߂Ȃ�)
            var initadv = (uint)(Math.Min(MinSearchRange.Value, MaxSearchRange.Value));

            var searchRange = (uint)(Math.Abs(MaxSearchRange.Value - MinSearchRange.Value));

            var pokename = SpeciesComboBox.Text;
            var pokeLv = spieciesLvsArray[stidx][spidx];

            var fixedAbility = 3U;
            //�n�}�i�X�`���̏ꍇ�͋����I�ɉB�����
            if((stidx == 3) || (stidx == 4)) fixedAbility = 2;
            //�C�x���g�n(�~���E�E�W���[�`)�̏ꍇ�͓���1�ŌŒ�
            if ((stidx == 5)) fixedAbility = 0;

            //�C�x���g�n�̓u���b�N���[�`�����|����
            var neverShiny = (stidx == 5);

            var isRoamers = (stidx == 2);
            var useSync = UseSynchronize.Checked;

            var tsv = 0u;//��tsv
            var generator = new StaticSymbolGenerator(pokename, pokeLv, tsv, 3, fixedAbility, neverShiny);
            var roamergenerator = new RoamerGenerator(pokename, pokeLv, tsv);


            Synchronize sync = new Synchronize(SynchronizeComboBox.Text.ConvertToNature());

            var natureCondition = (Nature)NatureComboBox.SelectedIndex;
            var genderCondition = (GenderCondition)GenderComboBox.SelectedIndex;
            var shinyCondition = (ShinyCondition)ShinyComboBox.SelectedIndex;
            var minHeight = (byte)MinHeight.Value;
            var maxHeight = (byte)MaxHeight.Value;
            var minWeight = (byte)MinWeight.Value;
            var maxWeight = (byte)MaxWeight.Value;

            //Validator����
            SearchCondition sc = new SearchCondition(natureCondition, genderCondition, shinyCondition, minHeight, maxHeight, minWeight, maxWeight);

            Task task = new(() =>
            {
                this.Invoke(() =>
                {
                    SearchButton.Enabled = false;
                });
                var results = new List<string[]>();
                for (uint i = 0; i < searchRange; i++, state.Advance())
                {
                    Individual pk = null;
                    //TODO:���̏�������{���ɂǂ��ɂ�������
                    if (isRoamers)
                    {
                        pk = useSync ? roamergenerator.Generate(state, sync) : roamergenerator.Generate(state);
                    }
                    else
                    {
                        pk = useSync ? generator.Generate(state, sync) : generator.Generate(state);
                    }

                    if (!sc.Validate(pk)) continue;

                    var advance = initadv + i;
                    results.Add(Misc.ToResultArray(advance, pk));
                    if (results.Count >= 1000)
                    {
                        //TODO:�Ȃ񂩃��[�_�����b�Z�[�W���o���đł��؂�
                        break;
                    }
                }
                this.Invoke(() =>
                {
                    //TODO:�A�z�Ȃ��Ƃ��Ă�C������̂łǂ��ɂ�������
                    dataGridView1.Rows.Clear();
                    foreach (var row in results) dataGridView1.Rows.Add(row);
                    SearchButton.Enabled = true;

                });
            });
            task.Start();


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