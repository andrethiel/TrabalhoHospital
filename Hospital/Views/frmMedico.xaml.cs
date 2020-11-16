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
    /// Lógica interna para frmMedico.xaml
    /// </summary>
    public partial class frmMedico : Window
    {
        Prescricao prescricao;
        int ID, ID_Prescricao;
        public frmMedico()
        {
            InitializeComponent();
            grid.ItemsSource = AtendimentoDAO.BuscaAtendimento();
        }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedItem == null)
            {
                return;
            }
                
            else
            {
                var select = grid.SelectedItem as AtendimentoPaciente;
                ID = select.ID;
                //var paciente = PrescricaoDAO.BuscaPrescricaoAtendimento(ID);

                if (PrescricaoDAO.BuscaPrescricaoAtendimento(ID) != null)
                {
                    var atendimento = PrescricaoDAO.BuscaPrescricaoAtendimento(ID);
                    grid_prescricao.ItemsSource = atendimento;
                    
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prescricao = new Prescricao
            {
                TextoPrescricao = txtPrescricao.Text,
                AtendimentoID = ID
            };
            if (!string.IsNullOrWhiteSpace(txtPrescricao.Text))
            {
                if (PrescricaoDAO.CadastroPrescricao(prescricao))
                {
                    MessageBox.Show("Prescrição cadastrado com sucesso!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    grid_prescricao.ItemsSource = PrescricaoDAO.BuscaPrescricaoAtendimento(ID);
                    LimpaFormulario();
                }
                else
                {
                    MessageBox.Show("Erro ao inserir!!!", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo prescrição!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void grid_prescricao_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedItem == null)
                return;
            var select = grid_prescricao.SelectedItem as Prescricao;
            ID_Prescricao = select.ID;
            var texto = PrescricaoDAO.BuscarPrescricao(select.ID);

            txtPrescricao.Text = texto.TextoPrescricao;

            btnAlterar.Visibility = Visibility.Visible;
            btnRemover.Visibility = Visibility.Visible;
            btnCadastrar.Visibility = Visibility.Hidden;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (PrescricaoDAO.AlterarPrescricao(txtPrescricao.Text, ID_Prescricao))
            {
                MessageBox.Show("Prescricao alterado com sucesso!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                grid_prescricao.ItemsSource = PrescricaoDAO.BuscaPrescricaoAtendimento(ID);
                LimpaFormulario();
                btnAlterar.Visibility = Visibility.Hidden;
                btnRemover.Visibility = Visibility.Hidden;
                btnCadastrar.Visibility = Visibility.Visible;
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {

            if (ID_Prescricao != 0)
            {
                PrescricaoDAO.Remover(ID_Prescricao);
                MessageBox.Show("Excluido com sucesso!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                LimpaFormulario();
                grid_prescricao.ItemsSource = PrescricaoDAO.BuscaPrescricaoAtendimento(ID);
                btnAlterar.Visibility = Visibility.Hidden;
                btnRemover.Visibility = Visibility.Hidden;
                btnCadastrar.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("ERRO!!!", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void LimpaFormulario()
        {
            txtPrescricao.Text = "";

        }
    }
}
