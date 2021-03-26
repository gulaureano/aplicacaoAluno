using System;

namespace AplicacaoAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Insira aqui apenas valores decimais");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno ++;
                        
                        break;

                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno {a.Nome} - Nota: {a.Nota}");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        decimal mediaTotal = 0;
                        var nrAlunos = 0;
                        for (int i=0; i<alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                mediaTotal = mediaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = mediaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;
                        if (mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }

                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }

                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }

                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }

                        conceitoGeral = ConceitoEnum.A;

                        Console.WriteLine($"Media: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;

                    default:

                        throw new ArgumentOutOfRangeException("Valor informado não esta nas opções disponiveis");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
