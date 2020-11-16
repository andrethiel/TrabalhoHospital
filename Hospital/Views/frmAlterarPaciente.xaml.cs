using Hospital.DAL;
using Hospital.Model;
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
    /// Lógica interna para frmAlterarPaciente.xaml
    /// </summary>
    public partial class frmAlterarPaciente : Window
    {
        Paciente paciente;
        public int id_paciente;
        public frmAlterarPaciente(int ID)
        {
            InitializeComponent();

            paciente = PacienteDAO.BuscaPacienteID(ID);
            id_paciente = ID;

            if (paciente != null)
            {
                txtNome.Text = paciente.Nome;
                txtCPF.Text = paciente.CPF;
                txtEmail.Text = paciente.Email;
                txtTelefone.Text = paciente.Telefone;
                txtCelular.Text = paciente.Celular;
            }
            else
            {
                MessageBox.Show("Paciente não encontrado", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paciente.ID = id_paciente;
            paciente.Nome = txtNome.Text;
            paciente.CPF = txtCPF.Text;
            paciente.Email = txtEmail.Text;
            paciente.Telefone = txtTelefone.Text;
            paciente.Celular = txtCelular.Text;

            if (PacienteDAO.AlteraraPaciente(paciente))
            {
                MessageBox.Show("Paciente alterado com sucesso!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
    }
}
