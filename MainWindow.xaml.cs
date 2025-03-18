using System.Windows;
using System.Windows.Controls;

namespace Zufall;

public partial class MainWindow : Window
{
    private Random random = new Random();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (ComboBox.SelectedItem != null)
        {
            if (int.TryParse(ComboBox.Text, out int maxZahl))
            {
                int zufallszahl = random.Next(1, maxZahl + 1);
                for (int i = 0; i <= 10; i++)
                {
                    int zufallszahlNeu = random.Next(1, maxZahl + 1);
                    ZahlLabel.Content = zufallszahlNeu.ToString();
                    await Task.Delay(50);
                }
                ZahlLabel.Content = zufallszahl.ToString();
                string zeitstempel = DateTime.Now.ToString("HH:mm:ss");
                ListView.Items.Insert(0, new ListViewItem { Content = $"{zeitstempel} = {zufallszahl}", Focusable = false });
            }
        }
    }
}
