using System;
using System.Collections.Generic;
using ValidityCheckService;
using ValidityCheckService.ValidityCheckers;

namespace NummerValidatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Här startas console-applikationen. Vill du hellre använda en collection av teststrängar så finns
            //exempel på sådan kod utkommenterad nedan. 
            ValidityCheckApplication validityCheckApplication = new();
            validityCheckApplication.Start();

            //ValidityCheckManager personNummerValidator = new(new PersonNummerValidityChecker());
            //ValidityCheckManager samordningsNummerValidator = new(new SamordningsNummerValidityChecker());
            //ValidityCheckManager organisationsNummerValidator = new(new OrganisationsNummerValidityChecker());
            //string[] testData = new string[]{<INSERT TEST DATA>};
            //foreach(string s in testData)
            //{
            //    Console.WriteLine(personNummerValidator.Validate(s));
            //    Console.WriteLine("-------------------------------");
            //}
        }
    }
}
