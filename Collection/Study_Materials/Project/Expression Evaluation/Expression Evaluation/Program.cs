using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expression_Evaluation
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var list1 = new List<string> { "Doc1", "Doc3", "Doc4", "Doc5" };
            //var list2 = new List<string> { "Doc1", "Doc4", "Doc5", "Doc6" };
            //var list3 = new List<string> { "Doc5", "Doc6" };

            //var termsDocMappings = new Dictionary<string, List<string>>();
            //termsDocMappings.Add("Apple", list1);
            //termsDocMappings.Add("Cat", list2);
            //termsDocMappings.Add("Dog", list3);

            //var testresult1 = EvaluateString1.Evaluate("( Apple AND Cat ) OR ( Apple AND Dog )");

            //var testresult2 = EvaluateString1.Evaluate("(Apple AND Cat) AND Dog )");

            //var result1 = EvaluateString1.IntersectionLogic(list1, list2);
            //var result2 = EvaluateString1.Intersection(list1, list2);
            //Console.WriteLine(EvaluateString1.evaluate("Dog AND Cat NOT Deer"));
            Console.WriteLine(EvaluateString.evaluate("100 + 12 / 12"));
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 )"));
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 ) / 14"));
            Console.ReadLine();
        }
    }

    public class EvaluateString
    {
        public static int evaluate(String expression)
        {
            char[] tokens = expression.ToCharArray();

            // Stack for numbers: 'values'
            Stack<int> values = new Stack<int>();

            // Stack for Operators: 'ops'
            Stack<char> ops = new Stack<char>();

            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it
                if (tokens[i] == ' ')
                    continue;

                // Current token is a number, push it to stack for numbers
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();
                    // There may be more than one digits in number
                    while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                        sbuf.Append(tokens[i++]);
                    values.Push(int.Parse(sbuf.ToString()));
                }

                // Current token is an opening brace, push it to 'ops'
                else if (tokens[i] == '(')
                    ops.Push(tokens[i]);

                // Closing brace encountered, solve entire brace
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                    ops.Pop();
                }

                // Current token is an operator.
                else if (tokens[i] == '+' || tokens[i] == '-' ||
                         tokens[i] == '*' || tokens[i] == '/')
                {
                    // While top of 'ops' has same or greater precedence to current
                    // token, which is an operator. Apply operator on top of 'ops'
                    // to top two elements in values stack
                    while (ops.Count() > 0 && hasPrecedence(tokens[i], ops.Peek()))
                        values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));

                    // Push current token to 'ops'.
                    ops.Push(tokens[i]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining
            // ops to remaining values
            while (ops.Count() > 0)
                values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));

            // Top of 'values' contains result, return it
            return values.Pop();
        }

        // Returns true if 'op2' has higher or same precedence as 'op1',
        // otherwise returns false.
        public static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
                return false;
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;
            else
                return true;
        }

        // A utility method to apply an operator 'op' on operands 'a'
        // and 'b'. Return the result.
        public static int applyOp(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                        break;
                    return a / b;
            }
            return 0;
        }
    }

    public class EvaluateString1
    {
        private static List<string> resultantList = new List<string>();
        private static List<string> list1 = new List<string> { "Doc1", "Doc3", "Doc4", "Doc5" };
        private static List<string> list2 = new List<string> { "Doc1", "Doc4", "Doc5", "Doc6" };
        private static List<string> list3 = new List<string> { "Doc5", "Doc6" };
        private static Dictionary<string, List<string>> termsDocMappings = new Dictionary<string, List<string>>();


        public static List<string> Evaluate(String expression)
        {
            termsDocMappings.Add("Apple", list1);
            termsDocMappings.Add("Cat", list2);
            termsDocMappings.Add("Dog", list3);

            expression = expression.Replace("(", "( ").Replace(")", " )");
            string[] tokens = expression.Split().Select(token => token.Trim()).ToArray();

            // Stack for numbers: 'values'
            Stack<List<string>> values = new Stack<List<string>>();

            // Stack for Operators: 'ops'
            Stack<string> ops = new Stack<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it
                if (tokens[i] == string.Empty)
                    continue;

                // Current token is an opening brace, push it to 'ops'
                if (tokens[i] == "(")
                    ops.Push(tokens[i]);

                // Closing brace encountered, solve entire brace
                else if (tokens[i] == ")")
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    if (ops.Count > 0)
                        ops.Pop();
                }

                // Current token is an operator.
                else if (tokens[i] == "AND" || tokens[i] == "OR" ||
                         tokens[i] == "NOT")
                {
                    // While top of 'ops' has same or greater precedence to current
                    // token, which is an operator. Apply operator on top of 'ops'
                    // to top two elements in values stack
                    while (ops.Count() > 0 && HasPrecedence(tokens[i], ops.Peek()))
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));

                    // Push current token to 'ops'.
                    ops.Push(tokens[i]);
                }
                else
                {
                    values.Push(termsDocMappings[tokens[i].ToString()]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining
            // ops to remaining values
            while (ops.Count() > 0)
                values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));

            // Top of 'values' contains result, return it
            return values.Pop();
        }

        // Returns true if 'op2' has higher or same precedence as 'op1',
        // otherwise returns false.
        public static bool HasPrecedence(string op1, string op2)
        {
            if (op2 == "(" || op2 == ")")
                return false;
            if ((op1 == "AND" || op1 == "OR") && (op2 == "NOT"))
                return false;
            else
                return true;
        }

        // A utility method to apply an operator 'op' on operands 'a'
        // and 'b'. Return the result.
        public static List<string> ApplyOp(string op, List<string> p1, List<string> p2)
        {
            switch (op)
            {
                case "AND":
                    return Intersection(p1, p2);
                case "OR":
                    return Union(p1, p2);
            }
            return new List<string>();
        }

        public static string AddOperation(string b, string a)
        {
            return string.Empty;
        }

        public static List<string> Intersection(List<string> p1, List<string> p2)
        {
            p1.Intersect(p2);
            return p1.Intersect(p2).ToList();
        }

        public static List<string> Union(List<string> p1, List<string> p2)
        {
            return p1.Union(p2).ToList();
        }

        public static List<string> IntersectionLogic(List<string> posting1, List<string> posting2)
        {
            var intersectionOfPostings = new List<string>();
            var maxlistCount = posting1.Count > posting2.Count ? posting1.Count : posting2.Count;
            int posting1index = 0, posting2index = 0;
            string currentPosting1Item = posting1[posting1index], currentPosting2Item = posting2[posting2index];

            do
            {
                if (currentPosting1Item == currentPosting2Item)
                {
                    intersectionOfPostings.Add(currentPosting1Item);
                    if (posting2.Count == posting2index + 1)
                        break;
                    currentPosting1Item = posting1[++posting1index];
                    currentPosting2Item = posting2[++posting2index];
                }
                else
                {
                    if (currentPosting1Item.CompareTo(currentPosting2Item) < 0)
                    {
                        currentPosting1Item = posting1[posting1index + 1];
                    }
                    else
                    {
                        currentPosting2Item = posting2[posting2index + 1];
                    }
                }
            } while (maxlistCount != posting1index + 1);

            return intersectionOfPostings;
        }

        public static List<string> ParsingTheTerms(Dictionary<string, List<string>> termDocMapping)
        {
            var result = termDocMapping["Apple"];
            var terms = new List<string> { "Cat", "Dog" };
            foreach (var item in termDocMapping)
            {
                result = Intersection(result, item.Value);
            }
            return result;
        }

    }
}
