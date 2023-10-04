//*****************************************************************************************************
//
//  Company: Paradigma
//  
//  Program Name: Avaliação Técnica - Tarefa 03
//  
//  Description: Desenvolva um algoritmo que, dado um conjunto de números inteiros,
//  retorne o índice da posição da soma de dois números desse conjunto. Você pode assumir que
//  cada conjunto de números tem apenas uma solução, e você não pode usar o mesmo número duas vezes. 
//  
//  Author: Jéssica Alves Nepomuceno
//  
//  Created date: 03/10/2023
//
//*****************************************************************************************************

var strNumber = String.Empty;
var listNumbers = new List<int>();
var listNumbersOrdered = new List<int>();
var controlWhile = new bool();
var sum = new int();
var headDescription = "--> Avaliação Técnica - Tarefa 03";
var headSubDescription = "--> Realizado por: Jéssica Nepomuceno";

// Cabeçalho para identificação da aplicação
void ShowHead()
{
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine(headDescription);
    Console.WriteLine(headSubDescription);
    Console.WriteLine("=======================================================================================================");
    Console.WriteLine("\n");
}

ShowHead();

#region .: Preenchimento do conjunto de números inteiros :.

Console.WriteLine("=======================================================================================================");
Console.WriteLine("--> Digite os números desejados para criar o conjunto de números inteiros. \n");
Console.WriteLine("--> Para concluir a digitação, pressione a tecla: S / s \n");

// Preenchimento dinâmico do conjunto de números inteiros, com possibilidade de conclusão informada pelo usuário
controlWhile = true;
while (controlWhile)
{
    Console.Write($"--> ");
    strNumber = Console.ReadLine();

    if (int.TryParse(strNumber, out int number) ? true : false)
        listNumbers.Add(number);
    else if (strNumber == "s" || strNumber == "S")
    {
        if (listNumbers.Count == 1)
            Console.WriteLine("--> ATENÇÃO: O conjunto deve ter mais de um elemento!");
        else
            controlWhile = false;
    }        
    else
        Console.WriteLine($"--> ATENÇÃO: Valor \"{strNumber}\" é inválido! Digite um número inteiro para acrescentar ao conjunto ou \"S\" para conclui-lo.");
}

Console.WriteLine($"\n--> O conjunto digitado foi: [{string.Join(", ", listNumbers.Select(x => x))}]");
Console.WriteLine("=======================================================================================================");
Console.WriteLine("\n");

#endregion

#region .: Preenchimento do valor da soma :.

Console.WriteLine("=======================================================================================================");
Console.WriteLine("--> Digite o valor da soma: ");

// Preenchimento dinâmico do valor da soma desejada pelo usuário
controlWhile = true;
while (controlWhile)
{
    Console.Write("--> ");
    strNumber = Console.ReadLine();

    if (int.TryParse(strNumber, out int number) ? true : false)
    {
        sum = number;
        controlWhile = false;
    }
    else
        Console.WriteLine($"--> ATENÇÃO: Valor \"{strNumber}\" é inválido! Digite um número inteiro.");
}

#endregion

#region .: Verificação dos elementos do conjunto que geram a soma :.

//Ordenação ascendente do conjunto informado pelo usuário, e
//geração de um novo conjunto com os numeros menores que o valor da soma informada
listNumbersOrdered = (listNumbers.OrderBy(x => x).ToList()).Where(x => x < sum).Select(x => x).ToList();

if (listNumbersOrdered.Any() && listNumbersOrdered.Count > 1)
{
    //Identificação dos dois elementos distintos que somados resultem no valor da soma informada pelo usuário
    var retornSearchSum = listNumbersOrdered.SelectMany((numberList01, indexList01) =>
            listNumbersOrdered.Select((numberList02, indexList02) =>
            new { number01 = numberList01, number02 = numberList02, index01 = indexList01, index02 = indexList02 }))
            .Where(x => x.index01 != x.index02).Where(x => x.number01 + x.number02 == sum).FirstOrDefault();

    if (retornSearchSum is not null)
    {
        Console.WriteLine($"\n--> {sum} é a soma de: {retornSearchSum.number01} e {retornSearchSum.number02}");
        Console.WriteLine($"--> {retornSearchSum.number01} e {retornSearchSum.number02} são números inteiros encontrados no conjunto informado!");
    }        
    else
        Console.WriteLine($"\n--> Não existe no conjunto dois elementos distintos que somados resultem em {sum}");
}
else
    Console.WriteLine($"\n--> Não existe no conjunto dois elementos distintos que somados resultem em {sum}");

#endregion
Console.WriteLine("=======================================================================================================");
Console.WriteLine("\n--> Para sair, pressione Enter! <--");

while (Console.ReadKey().Key != ConsoleKey.Enter) {}



