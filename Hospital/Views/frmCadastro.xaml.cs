using Hospital.DAL;
using Hospital.Model;
using System;
using System.Windows;

namespace Hospital.Views
{
    /// <summary>
    /// Lógica interna para frmCadastro.xaml
    /// </summary>
    public partial class frmCadastro : Window
    {
        private Paciente paciente;
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            frmBuscaPaciente busca = new frmBuscaPaciente();
            busca.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            paciente = new Paciente
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                Celular = txtCelular.Text
            };
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (PacienteDAO.CadastrarPaciente(paciente))
                {
                    MessageBox.Show("Paciente cadastrado com sucesso!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Paciente já existe!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    frmBuscaPaciente frm = new frmBuscaPaciente();
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo nome!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
