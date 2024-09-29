namespace SmartArrayConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // use our smart array
            SmartArray mySpecialArray = new SmartArray(5);
            mySpecialArray.SetAtIndex(2, 22);
            mySpecialArray.SetAtIndex(3, 33);
          

            mySpecialArray.PrintAllElements();
            Console.WriteLine();

            Console.WriteLine();

            mySpecialArray.Resize(10);
            mySpecialArray.SetAtIndex(9, 99);
            mySpecialArray.PrintAllElements();

            Console.WriteLine();

            mySpecialArray.Resize(6);
            mySpecialArray.PrintAllElements();
        }
    }
}
