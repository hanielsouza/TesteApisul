// See https://aka.ms/new-console-template for more information

using ProvaApisul.Services.Elevador;

Console.WriteLine("-------------------Resultado do levantamento dos usuários-------------------------------------");

var elevadorService = new ElevadorService();
Console.WriteLine("-------------------Andares menos utilizados---------------------------------------------------");
foreach (var item in elevadorService.andarMenosUtilizado())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Elevadores mais frequentados-----------------------------------------------");
foreach (var item in elevadorService.elevadorMaisFrequentado())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Elevadores menos frequentados----------------------------------------------");
foreach (var item in elevadorService.elevadorMenosFrequentado())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Percentual Elevador A------------------------------------------------------");
Console.WriteLine($"{elevadorService.percentualDeUsoElevadorA()}%");

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Percentual Elevador B------------------------------------------------------");
Console.WriteLine($"{elevadorService.percentualDeUsoElevadorB()}%");

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Percentual Elevador C------------------------------------------------------");
Console.WriteLine($"{elevadorService.percentualDeUsoElevadorC()}%");

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Percentual Elevador D------------------------------------------------------");
Console.WriteLine($"{elevadorService.percentualDeUsoElevadorD()}%");

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Percentual Elevador E------------------------------------------------------");
Console.WriteLine($"{elevadorService.percentualDeUsoElevadorE()}%");

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Período de maior fluxo dos elevadores mais frequentados--------------------");
foreach (var item in elevadorService.periodoMaiorFluxoElevadorMaisFrequentado())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Período de menor fluxo dos elevadores menos frequentados-------------------");
foreach (var item in elevadorService.periodoMenorFluxoElevadorMenosFrequentado())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.WriteLine("-------------------Período de maior utilização do conjunto de elevadores----------------------");
foreach (var item in elevadorService.periodoMaiorUtilizacaoConjuntoElevadores())
    Console.WriteLine(item);

Console.WriteLine("----------------------------------------------------------------------------------------------");

Console.ReadKey();
