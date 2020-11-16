using System;
using System.Collections.Generic;
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
    /// Lógica interna para frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair???", "",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void CadastrarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastro frm = new frmCadastro();
            frm.ShowDialog();
        }

        private void BuscarPaciente_Click(object sender, RoutedEventArgs e)
        {
            frmBuscaPaciente frm = new frmBuscaPaciente();
            frm.ShowDialog();
        }

        private void Atendimento_Click(object sender, RoutedEventArgs e)
        {
            frmMedico frm = new frmMedico();
            frm.ShowDialog();
        }
    }
}
