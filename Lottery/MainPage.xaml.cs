namespace Lottery
{
    internal record Limits(int Count, int Lower, int Upper);

    public partial class MainPage : ContentPage
    {
        readonly List<Lottery> Lotteries = [
            new Lottery(limits: new Limits(6, 1, 59)), 
            new EuroMillionsLottery(limits: new Limits(5, 1, 50), specialLimits: new Limits(2, 1, 12)), 
            new SetForLifeLottery(limits: new Limits(5, 1, 47), specialLimits: new Limits(1, 1, 10)), 
            new ThunderballLottery(limits: new Limits(5, 1, 39), specialLimits: new Limits(1, 1, 14))
        ];
        const KindOfLottery DefaultLottery = KindOfLottery.Uk;
        Lottery Lottery;

        public MainPage()
        {
            InitializeComponent();

            List<string> lottos = ["UK Lotto", "EuroMillions", "Set For Life", "Thunderball"];
            LotteryPicker.ItemsSource = lottos;
            LotteryPicker.SelectedIndex = (int)DefaultLottery;

            Lottery = Lotteries[LotteryPicker.SelectedIndex];
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            NumbersLabel.Text = Lottery.Play();
            SemanticScreenReader.Announce(NumbersLabel.Text);
        }

        private void LotteryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lottery = Lotteries[LotteryPicker.SelectedIndex];
        }
    }
}
