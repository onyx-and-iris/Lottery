namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        readonly List<Lottery> Lotteries = [
            new UKLottoLottery(), 
            new EuroMillionsLottery(), 
            new SetForLifeLottery(), 
            new ThunderballLottery()
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
