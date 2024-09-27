namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        readonly List<Lottery> Lotteries = [
            new UKLottoLottery(new UKLottoGenerator()), 
            new EuroMillionsLottery(new EuroMillionsGenerator()), 
            new SetForLifeLottery(new SetForLifeGenerator()), 
            new ThunderballLottery(new ThunderBallGenerator())
        ];
        const KindOfLottery DefaultLottery = KindOfLottery.Uk;
        Lottery Lottery;

        public MainPage()
        {
            InitializeComponent();

            List<string> lottos = ["UK Lotto", "EuroMillions", "Set For Life", "Thunderball"];
            LottoPicker.ItemsSource = lottos;
            LottoPicker.SelectedIndex = (int)DefaultLottery;

            Lottery = Lotteries[LottoPicker.SelectedIndex];
        }

        private void SpinButton_Clicked(object sender, EventArgs e)
        {
            Numbers numbers = Lottery.GenerateNumbers();
            List<string> output = [];
            switch (numbers.Kind)
            {
                case KindOfLottery.Uk:
                    output.Add($"Numbers: {string.Join(", ", numbers.Normal)}");
                    break;
                case KindOfLottery.Euro:
                case KindOfLottery.SetForLife:
                case KindOfLottery.Thunderball:
                    if (numbers is NumbersWithSpecial numbersWithSpecial)
                    {
                        output.AddRange([
                            $"Numbers: {string.Join(", ", numbersWithSpecial.Normal)}",
                            $"{Lottery.SpecialIdentifier}: {string.Join(", ", numbersWithSpecial.Special)}"
                        ]);
                    }
                    break;
                default:
                    throw new LottoPickerException($"no NumbersLabel output defined for {numbers.Kind}");
            };
            NumbersLabel.Text = string.Join("\t", output);
        }

        private void LottoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lottery = Lotteries[LottoPicker.SelectedIndex];
        }
    }
}
