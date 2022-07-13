namespace CalculadoraIR.Presetation
{
    public static class Screens
    {
        public static void Header()
        {
            Console.WriteLine(
 $@"--- Calculadora IR Anual Let's Code ---");
        }
        public static void MainMenu()
        {
            Console.WriteLine(
    @"                MENU
1 - Fazer o cáculo e cadastrar um novo cliente
2 - Consultar IR de um cliente pelo nome
3 - Exibir todos os clientes
4 - Sair
"
    );
        }
    }
}
