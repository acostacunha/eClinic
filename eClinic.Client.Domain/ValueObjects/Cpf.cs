using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace eClinic.Client.Domain.ValueObjects
{
    public class Cpf
    {
        public string CpfNumber { get; private set; }

        public Cpf() { }
        private Cpf(string cpf) => CpfNumber = cpf;

        public static Cpf Create(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O Cpf é obrigatório.");

            return new Cpf(cpf);
        }
    }
}
