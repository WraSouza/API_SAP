using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_SAP.Helpers
{
    public class FormataString
    {
        public static string RetiraAcento(string name)
        {
            StringBuilder nomeFormatado = new StringBuilder();

             var formattedString = name.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char c in formattedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                nomeFormatado.Append(c);
            }

            return nomeFormatado.ToString();
        }
    }
}