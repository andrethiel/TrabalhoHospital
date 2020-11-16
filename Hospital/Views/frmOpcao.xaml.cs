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
    /// Lógica interna para frmOpcao.xaml
    /// </summary>
    public partial class frmOpcao : Window
    {
        public int paciente_id;
        public frmOpcao(int ID)
        {
            InitializeComponent();
            paciente_id = ID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            frmAlterarPaciente frm = new frmAlterarPaciente(paciente_id);
            frm.ShowDialog();
            //frm.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            frmInitAtendimento frm = new frmInitAtendimento(paciente_id);
            frm.ShowDialog();
            
        }
    }
}
