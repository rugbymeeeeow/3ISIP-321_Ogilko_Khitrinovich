using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.IO;//using WpfMath;

namespace _3ISIP_321_Ogilko_Khitrinovich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(X.Text)) && !(string.IsNullOrEmpty(I.Text)) && (shx.IsChecked == true || x2.IsChecked == true || ex.IsChecked == true)) //(int.TryParse(X.Text, out int result).)
            {
                int xsmall;
                int ismall;
                bool isnumx = int.TryParse(X.Text, out xsmall);
                bool isnumi = int.TryParse(I.Text, out ismall);
                if (isnumx && isnumi)
                {
                    if (xsmall == Convert.ToDouble(X.Text) && ismall == Convert.ToDouble(I.Text))
                    {
                        if (shx.IsChecked == true)
                        {
                            if (xsmall > 0 && ismall % 2 == 1)
                            {
                                double sinhvalue = Math.Sinh(xsmall);
                                Answer.Text = Convert.ToString(ismall * Math.Sqrt(sinhvalue));
                            }
                            else if (ismall % 2 == 0 && xsmall < 0)
                            {
                                double sinhvalue = Math.Sinh(xsmall);
                                Answer.Text = Convert.ToString(ismall / 2 * Math.Sqrt(Math.Abs(sinhvalue)));
                            }
                            else
                            {
                                double sinhvalue = Math.Sinh(xsmall);
                                Answer.Text = Convert.ToString(Math.Sqrt(Math.Abs(ismall * sinhvalue)));
                            }
                        }
                        else if (x2.IsChecked == true)
                        {
                            if (xsmall > 0 && ismall % 2 == 1)
                            {
                                int xtwo = xsmall * xsmall;
                                Answer.Text = Convert.ToString(ismall * Math.Sqrt(xtwo));
                            }
                            else if (ismall % 2 == 0 && xsmall < 0)
                            {
                                int xtwo = xsmall * xsmall;
                                Answer.Text = Convert.ToString(ismall / 2 * Math.Sqrt(Math.Abs(xtwo)));
                            }
                            else
                            {
                                int xtwo = xsmall * xsmall;
                                Answer.Text = Convert.ToString(Math.Sqrt(Math.Abs(ismall * xtwo)));
                            }

                        }
                        else if (ex.IsChecked == true)
                        {
                            if (xsmall > 0 && ismall % 2 == 1)
                            {
                                Answer.Text = Convert.ToString(ismall * Math.Sqrt(Math.Exp(xsmall)));
                            }
                            else if (ismall % 2 == 0 && xsmall < 0)
                            {
                                Answer.Text = Convert.ToString(ismall / 2 * Math.Sqrt(Math.Abs(Math.Exp(xsmall))));
                            }
                            else
                            {
                                Answer.Text = Convert.ToString(Math.Sqrt(Math.Abs(ismall * Math.Exp(xsmall))));
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите целое число!");
                }
            }
            else
            {
                MessageBox.Show("Видимо вы не заполнили значения X или I или не нажали на одну из кнопок-переключателей");
            }
        }
        

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            X.Clear();
            I.Clear();
            Answer.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти? \nВ случае выхода данные не сохранятся!", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
