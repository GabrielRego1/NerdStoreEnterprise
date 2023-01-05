using NSE.Core.Utils;

namespace NSE.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLengh = 11;

        public string Numero { get; private set; }

        //Construtor do EF
        protected Cpf() { }
        public Cpf(string numero)
        {
            if (!Validar(numero))
                throw new DomainException("CPF Inválido");
            Numero = numero;
        }

        public static bool Validar(string cpf)
        {
            cpf = cpf.ApenasNumeros(cpf);


            if (cpf.Length > CpfMaxLengh)
                return false;

            while (cpf.Length != CpfMaxLengh)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < CpfMaxLengh && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[CpfMaxLengh];

            for (var i = 0; i < CpfMaxLengh; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % CpfMaxLengh;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != CpfMaxLengh - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (CpfMaxLengh - i) * numeros[i];

            resultado = soma % CpfMaxLengh;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != CpfMaxLengh - resultado)
                return false;

            return true;
        }

    }
}
