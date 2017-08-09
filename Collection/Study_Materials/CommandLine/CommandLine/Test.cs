/*
* Test class: main testing class
*
* Authors:		R. LOPES
* Contributors:	R. LOPES
* Created:		28 October 2002
* Modified:		28 October 2002
*
* Version:		1.0
*/

using System;
using CommandLine.Utility;

namespace CommandLine
{
    /// <summary>
    /// Testing class
    /// </summary>
    class Test
    {
        /// <summary>
        /// Main loop
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            // Command line parsing
            Arguments CommandLine = new Arguments(Args);

            // Look for specific arguments values and display them if they exist (return null if they don't)
            if (CommandLine["param1"] != null) Console.WriteLine("Param1 value: " + CommandLine["param1"]);
            else Console.WriteLine("Param1 not defined !");

            if (CommandLine["uname"] != null) Console.WriteLine("uname value: " + CommandLine["uname"]);
            else Console.WriteLine("uname not defined !");

            if (CommandLine["pwd"] != null) Console.WriteLine("pwd value: " + CommandLine["pwd"]);
            else Console.WriteLine("pwd not defined !");

            if (CommandLine["cname"] != null) Console.WriteLine("cname value: " + CommandLine["cname"]);
            else Console.WriteLine("cname not defined !");

            if (CommandLine["pgname"] != null) Console.WriteLine("pgname value: " + CommandLine["pgname"]);
            else Console.WriteLine("pgname not defined !");

            if (CommandLine["transdir"] != null) Console.WriteLine("transdir value: " + CommandLine["transdir"]);
            else Console.WriteLine("transdir not defined !");

            if (CommandLine["runrules"] != null) Console.WriteLine("runrules value: " + CommandLine["runrules"]);
            else Console.WriteLine("runrules not defined !");

            // Wait for key
            Console.Out.WriteLine("Arguments parsed. Press a key...");
            Console.Read();
        }
    }
}
