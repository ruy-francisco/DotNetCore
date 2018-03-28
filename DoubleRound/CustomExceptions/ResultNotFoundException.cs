using System;

namespace DoubleRound.CustomExceptions
{
    public class ResultNotFoundException: Exception
    {
        private static string _defaultMessage = "Não foi encontrado nenhum resultado";

        public ResultNotFoundException(): base(_defaultMessage) {}

        public ResultNotFoundException(string message): base(message) {}
    }
}