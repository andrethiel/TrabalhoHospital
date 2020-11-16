using Hospital.DAL;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital.Views
{
    /// <summary>
    /// Lógica interna para frmBuscaPaciente.xaml
    /// </summary>
    public partial class frmBuscaPaciente : Window
    {
        public frmBuscaPaciente()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var paciente = PacienteDAO.BuscaPacienteLista(txtNome.Text);

            dataGrid1.ItemsSource = paciente;

        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGrid1.SelectedItem == null)
                return;
            var select  = dataGrid1.SelectedItem as Paciente;
            frmOpcao frm = new frmOpcao(select.ID);
            frm.ShowDialog();
            //MessageBox.Show(string.Format("The Person you double clicked on is - Name: {0}", select.ID));



        }
    }
}
