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
using Microsoft.Win32;
using System.Windows.Forms;


namespace WpfGun7_250717
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string selectedFileName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButonAra_Click(object sender, RoutedEventArgs e) // Ara Butonu
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = " Media files All Files (*.*)|*.*";  //Dosya tipi secme

            // dlg.Filter = " Media files (*.mp4)|*.mp4|All Files (*.*)|*.*";



            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {


                selectedFileName = dlg.FileName;
                LabelDosya.Content = selectedFileName;
                Media.Source = new Uri(selectedFileName);
                Media.Play();


            }

        }



        private void ButonPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                Media.Play();
            }
            catch (Exception)
            {

                throw new Exception("Dosyanız eksik veya hatalı");
            }


        }

        private void ButonPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Media.Pause();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // Gereksiz Buton
        //private void ButonStop_Click(object sender, RoutedEventArgs e)
        //{
        //    Media.Stop();
        //}

        private void SliderSes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = (double)SliderSes.Value;
        }

        private void SliderHiz_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.SpeedRatio = (double)SliderHiz.Value;
        }
    }
}
