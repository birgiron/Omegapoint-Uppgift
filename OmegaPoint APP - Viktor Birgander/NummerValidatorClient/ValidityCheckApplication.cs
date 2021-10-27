using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService;
using ValidityCheckService.ValidityCheckers;

namespace NummerValidatorClient
{
    public class ValidityCheckApplication
    {
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("|--------------------------------------------------------|");
                Console.WriteLine("|Välj vilken typ av nummer du vill validera (ange 1/2/3) |");
                Console.WriteLine("|--------------------------------------------------------|");
                Console.WriteLine("|1: Personnummer                                         |");
                Console.WriteLine("|2: Samordningsnummer                                    |");
                Console.WriteLine("|3: Organisationsnummer                                  |");
                Console.WriteLine("|--------------------------------------------------------|");

                char type = Console.ReadKey().KeyChar;
                while (!TryType(type))
                {
                    Console.WriteLine("\nDu angav inte ett giltigt alternativ, vänligen försök igen.\n\n");
                    type = Console.ReadKey().KeyChar;
                }

                Console.WriteLine("\nAnge numret (10 eller 12 siffror): ");
                string number = Console.ReadLine();
                Console.WriteLine("------------------------------");
                string result = Validate(type, number) ? "giltigt" : "ogiltigt";
                Console.WriteLine($"Strängen {'"' + number + '"'} är ett {result} nummer för nummertypen du valde");

                Console.WriteLine("\nTryck på E/e för att avsluta eller valfri annan tangent för att validera ett nytt nummer: \n");
                var key = Console.ReadKey().KeyChar;
                if (key == 'E' || key == 'e')
                    break;
            }
        }

        //Controls if the provided character is one of the valid alternatives
        private bool TryType(char type)
        {
            if (type == '1' || type == '2' || type == '3')
                return true;
            return false;
        }

        private bool Validate(char type, string number)
        {
            ValidityCheckManager validityCheckManager; 
            switch (type)
            {
                case '1': validityCheckManager = new(new PersonNummerValidityChecker());
                    break;
                case '2': validityCheckManager = new(new SamordningsNummerValidityChecker());
                    break;
                case '3': validityCheckManager = new(new OrganisationsNummerValidityChecker());
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
            return validityCheckManager.Validate(number);
        }
    }
}
