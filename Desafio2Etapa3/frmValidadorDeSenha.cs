using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Desafio2Etapa3
{
    public partial class ValidadorDeSenha : Form
    {
        public ValidadorDeSenha()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            //Valida se a senha digitada é nula ou vazia
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Não é permitido senha em branco!");
            }//Valida se a senha digitada é menor que 6 digitos
            else if (GetTamanho(txtSenha.Text) < 6)
            {
                MessageBox.Show("A senha precisa ter no mínimo 6 caracteres!");
            }//Valida se a senha digitadatem pelo menos um digito
            else if (GetDigitos(txtSenha.Text) == 0)
            {
                MessageBox.Show("A senha precisa ter pelo menos um digito!");
            }//Valida se a senha digitadatem pelo menos 1 letra em minúscula
            else if (GetMinusculas(txtSenha.Text) == 0)
            {
                MessageBox.Show("A senha precisa ter no mínimo 1 letra em minúsculo!");
            }//Valida se a senha digitadatem pelo menos 1 letra em maiúscula
            else if (GetMaiusculas(txtSenha.Text) == 0)
            {
                MessageBox.Show("A senha precisa ter no mínimo 1 letra em maiúsculo!");
            }//Valida se a senha digitadatem pelo menos 1 caractere especial
            else if (GetSimbolos(txtSenha.Text) == 0)
            {
                MessageBox.Show("A senha precisa ter no mínimo 1 caractere especial. Os caracteres especiais são: !@#$%^&*()-+!");
            }
            else
            {
                //Retorna senha válida
                MessageBox.Show("Senha válida!");
            }
        }
        private int GetDigitos(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(2, rawplacar) ;
        }

        private int GetTamanho(string senha)
        {
            return Math.Min(6, senha.Length);
        }

        private int GetMinusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return Math.Min(2, rawplacar) ;
        }

        private int GetMaiusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(2, rawplacar) ;
        }

        private int GetSimbolos(string senha)
        {
            int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, rawplacar) ;
        }

    }
}
