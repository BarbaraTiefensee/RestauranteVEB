using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DTO
{
    public static class EXT
    {
        public static int ToInt(this string val)
        {
            int temp;
            int.TryParse(val, out temp);
            return temp;
        }

        public static double ToDouble(this string val)
        {
            double temp;
            double.TryParse(val, out temp);
            return temp;
        }

        public static bool IsCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsEmail(this string email)
        {
            //Regular Expression
            //É um padrão que valida se determinada
            //string está em um formato correto, no caso do email,
            //só pode começar com letrar (pode possuir símbolos e números
            //após o primeiro caracter), necessita de @, etc...
            string regex = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";
            return Regex.IsMatch(email, regex);
        }

        public static bool CorrectName(this string nome)
        {
            string regex = "^[A-Za-z ]+$";
            return Regex.IsMatch(nome, regex);
        }

        static public bool CorrectPassWord(this string senha)
        {
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            return Regex.IsMatch(senha, regex);
        }

        static public bool IsTelephone(this string telefone)
        {
            string regex = @"\(\d{2}\)\s\d{4,5}\-\d{4}";
            return Regex.IsMatch(telefone, regex);
        }

        public static string NormatizarCPF(this string cpf)
        {
            //Retirando a mascara do CPF para armazenar no banco.
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            return cpf;
        }

        public static string NormatizarEmail(this string email)
        {
            email = email.Trim();
            return email;
        }

        public static string NormatizarNome(this string nome)
        {
            nome = nome.Trim();
            nome = Regex.Replace(nome, @"\s+", " ");
            return nome;
        }
    }
}
