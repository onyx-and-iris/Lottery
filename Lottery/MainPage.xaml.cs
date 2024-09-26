namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        List<IGenerator> generators = [new UKGenerator(), new EuroGenerator(), new SetForLifeGenerator()];
        IGenerator generator;
        const KindOfLotto DEFAULT_GENERATOR = KindOfLotto.Uk;

        public MainPage()
        {
            InitializeComponent();

            List<string> lottos = ["UK", "Euro", "Set For Life"];
            LottoPicker.ItemsSource = lottos;
            LottoPicker.SelectedIndex = (int)DEFAULT_GENERATOR;

            generator = generators[LottoPicker.SelectedIndex];
        }

        private void SpinButton_Clicked(object sender, EventArgs e)
        {
            List<int> numbers = generator.Generate();
            Numbers.Text = $"Numbers: {string.Join(", ", numbers)}";
        }

        private void LottoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            generator = generators[LottoPicker.SelectedIndex];
        }
    }
}
