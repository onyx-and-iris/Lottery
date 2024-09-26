namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        readonly List<IGenerator> generators = [new UKGenerator(), new EuroGenerator(), new SetForLifeGenerator(), new ThunderBallGenerator()];
        IGenerator generator;
        const KindOfLotto DEFAULT_GENERATOR = KindOfLotto.Uk;

        public MainPage()
        {
            InitializeComponent();

            List<string> lottos = ["UK Lotto", "EuroMillions", "Set For Life", "Thunderball"];
            LottoPicker.ItemsSource = lottos;
            LottoPicker.SelectedIndex = (int)DEFAULT_GENERATOR;

            generator = generators[LottoPicker.SelectedIndex];
        }

        private void SpinButton_Clicked(object sender, EventArgs e)
        {
            Numbers numbers = generator.Generate();
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
                            $"Normal: {string.Join(", ", numbersWithSpecial.Normal)}", 
                            $"Special: {string.Join(", ", numbersWithSpecial.Special)}"
                        ];
                        NumbersLabel.Text = string.Join("\t", output);
                    }
                    break;
                default:
                    throw new LottoPickerException($"no NumbersLabel output defined for {numbers.Kind}");
            }         
        }

        private void LottoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            generator = generators[LottoPicker.SelectedIndex];
        }
    }
}
