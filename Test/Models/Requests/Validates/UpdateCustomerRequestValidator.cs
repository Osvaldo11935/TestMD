using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Models.Requests.Validates
{
    public class UpdateCustomerRequestValidator
    {
        public static string ValidateCustomerInfo(string name, string email, string phoneNumber, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Por favor, insira o nome do cliente." + "Erro de Validação";
            }

            if (!IsValidEmail(email))
            {
                return "Por favor, insira um email válido." + "Erro de Validação";
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                return "O número de telefone deve estar no formato (00) 00000-0000." +
                                "Formato Inválido";
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                return "Por favor, insira o endereço do cliente." + "Erro de Validação";
            }

            return null;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\(\d{2}\) \d{5}-\d{4}$";
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                return false;
            }
            return true;
        }
    }
}
