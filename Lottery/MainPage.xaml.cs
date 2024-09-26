namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        readonly List<IGenerator> Generators = [new UKGenerator(), new EuroGenerator(), new SetForLifeGenerator(), new ThunderBallGenerator()];
        IGenerator Generator;
        const KindOfLotto DEFAULT_GENERATOR = KindOfLotto.Uk;
        Dictionary<KindOfLotto, string> SpecialIdentifiers = new() {
            { KindOfLotto.Euro, "Lucky Stars" },
            { KindOfLotto.SetForLife, "Life Ball" },
            { KindOfLotto.Thunderball, "Thunderball" }
        };

        public MainPage()
        {
            InitializeComponent();

            List<string> lottos = ["UK Lotto", "EuroMillions", "Set For Life", "Thunderball"];
            LottoPicker.ItemsSource = lottos;
            LottoPicker.SelectedIndex = (int)DEFAULT_GENERATOR;

            Generator = Generators[LottoPicker.SelectedIndex];
        }

        private void SpinButton_Clicked(object sender, EventArgs e)
        {
            Numbers numbers = Generator.Generate();
            switch (numbers.Kind)
            {
                case KindOfLotto.Uk:
                    NumbersLabel.Text = $"Numbers: {string.Join(", ", numbers.Normal)}";
                    break;
                case KindOfLotto.Euro:
                case KindOfLotto.SetForLife:
                case KindOfLotto.Thunderball:
                    if (numbers is NumbersWithSpecial numbersWithSpecial)
                    {
                        List<string> output = [
                            $"Numbers: {string.Join(", ", numbersWithSpecial.Normal)}",
                            $"{SpecialIdentifiers[numbers.Kind]}: {string.Join(", ", numbersWithSpecial.Special)}"
                        ];
                        NumbersLabel.Text = string.Join("\t", output);
                    }
                    break;
                default:
                    throw new LottoPickerException($"no NumbersLabel output defined for {numbers.Kind}");
            };
        }

        private void LottoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generator = Generators[LottoPicker.SelectedIndex];
        }
    }
}
