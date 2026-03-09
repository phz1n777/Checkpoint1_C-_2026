using SistemaCadastroGenerico;
using System;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        // Instância do cadastro genérico
        Cadastro<Pessoa> cadastro = new Cadastro<Pessoa>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // ADICIONAR
        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaID.Text);
                string nome = EntradaNome.Text;

                Pessoa pessoa = new Pessoa(id, nome);

                cadastro.Adicionar(id, pessoa);

                MessageBox.Show("Cadastro realizado com sucesso!");

                AtualizarTabela();
            }
            catch
            {
                MessageBox.Show("Digite um ID válido.");
            }
        }

        // LISTAR
        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarTabela();
        }

        // BUSCAR
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaID.Text);

                Pessoa pessoa = cadastro.Buscar(id);

                if (pessoa != null)
                {
                    MessageBox.Show($"Encontrado: {pessoa.Nome}");
                }
                else
                {
                    MessageBox.Show("ID não encontrado.");
                }
            }
            catch
            {
                MessageBox.Show("Digite um ID válido.");
            }
        }

        // REMOVER
        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaID.Text);

                bool removido = cadastro.Remover(id);

                if (removido)
                {
                    MessageBox.Show("Registro removido!");
                }
                else
                {
                    MessageBox.Show("ID não encontrado.");
                }

                AtualizarTabela();
            }
            catch
            {
                MessageBox.Show("Digite um ID válido.");
            }
        }

        // LIMPAR CAMPOS
        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            EntradaID.Text = "";
            EntradaNome.Text = "";
        }

        // ATUALIZAR TABELA
        private void AtualizarTabela()
        {
            TabelaDados.ItemsSource = null;
            TabelaDados.ItemsSource = cadastro.Listar().Values;
        }
    }
}