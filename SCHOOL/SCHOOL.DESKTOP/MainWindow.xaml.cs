using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SCHOOL.DESKTOP.Student;

namespace SCHOOL.DESKTOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Consumo consumo = new Consumo();
                DataContext = new ConsumoViewModel(consumo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

           
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    StudentSearchWindow SSW = new StudentSearchWindow();
        //    Close();
        //    SSW.ShowDialog();

        //    //MessageBox.Show("Its Working fine");
        //}

    }

    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
        public string Titulo { get; private set; }
        public int Porcentagem { get; private set; }

        public Consumo()
        {
            Titulo = "Consumo Atual";
            Porcentagem = CalcularPorcentagem();
        }

        private int CalcularPorcentagem()
        {
            return 47; //Calculo da porcentagem de consumo
        }
    }

}

