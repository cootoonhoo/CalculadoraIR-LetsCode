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
1 - Cadastrar uma nova pessoa
2 - Consultar DataBase
3 - Sair
"
    );
        }
        public static void ConsultMenu()
        {
            Console.WriteLine(
@"                  Consulta
1 - Pesquisar por nome
2 - Exibir todos
3 - Sair
"
    );
        }
    }
}
