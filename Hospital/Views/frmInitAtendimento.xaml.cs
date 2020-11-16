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
    /// Lógica interna para frmInitAtendimento.xaml
    /// </summary>
    public partial class frmInitAtendimento : Window
    {
        private int id;
        private Atendimento atendimento;

        public frmInitAtendimento(int ID)
        {
            InitializeComponent();
            id = ID;
            var paciente = PacienteDAO.BuscaPacienteID(ID);
            txtNome.Text = paciente.Nome;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            atendimento = new Atendimento
            {
                PacienteID = id,
                Tipo = combAtendimento.Text,
                Chegada = combChegada.Text,
                Sintomas = combSintomas.Text
            };
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                if (AtendimentoDAO.CadastrarAtendimento(atendimento))
                {
                    MessageBox.Show("Atendimento cadastrado com sucesso!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Paciente já existe!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
