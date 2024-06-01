using System;

namespace Console2

{
    class Program
        
{
    static void Main(string[] args)
    {
            List<string> names= new List<string> { "Ram", "Sam" };
            names.Add("End");
            foreach(var chare in names)
            {
                Console.WriteLine(chare);
            }
            Console.WriteLine(names);
            Console.WriteLine(names.Count);
        }
    
}


}
