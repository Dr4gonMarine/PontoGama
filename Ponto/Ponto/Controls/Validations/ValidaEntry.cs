using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Controls.Validations
{
    public static class ValidaEntry
    {
        public static bool ValidaEntryEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            else if (email.Contains("@"))            
                return true;            
            else
                return false;
        }
        public static bool ValidaSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return false;
            else 
                return true;            
        }
        public static bool ValidaNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return false;
            else
                return true;
        }
    }
}
