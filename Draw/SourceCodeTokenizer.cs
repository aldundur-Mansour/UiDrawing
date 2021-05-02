using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
 

        public delegate bool InputCondition(Input input);
        public class Input
        {
            private readonly string input;
            private readonly int length;
            private int position;
            private int lineNumber;
            //Properties
            public int Length
            {
                get
                {
                    return this.length;
                }
            }
            public int Position
            {
                get
                {
                    return this.position;
                }
            }
            public int NextPosition
            {
                get
                {
                    return this.position + 1;
                }
            }
            public int LineNumber
            {
                get
                {
                    return this.lineNumber;
                }
                set
                {
                    this.lineNumber = value;
                }
            }
            public char Character
            {
                get
                {
                    if (this.position > -1) return this.input[this.position];
                    else return '\0';
                }
            }
            public Input(string input)
            {
                this.input = input;
                this.length = input.Length;
                this.position = -1;
                this.lineNumber = 1;
            }
            public bool hasMore(int numOfSteps = 1)
            {
                if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
                return (this.position + numOfSteps) < this.length;
            }
            public bool hasLess(int numOfSteps = 1)
            {
                if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
                return (this.position - numOfSteps) > -1;
            }
            //callback -> delegate
            public Input step(int numOfSteps = 1)
            {
                if (this.hasMore(numOfSteps))
                    this.position += numOfSteps;
               /* else
                {
                    throw new Exception("There is no more step");
                }*/
                return this;
            }
            public Input back(int numOfSteps = 1)
            {
                if (this.hasLess(numOfSteps))
                    this.position -= numOfSteps;
                else
                {
                    throw new Exception("There is no more step");
                }
                return this;
            }
            public Input reset() { return this; }
        public char peek(int numOfSteps = 1)
        {
            if (this.hasMore(numOfSteps)) return this.input[this.Position + numOfSteps];
            return '\0';
        }
        public string loop(InputCondition condition)
            {
                string buffer = "";
                while (this.hasMore() && condition(this))
                    buffer += this.step().Character;

                return buffer;
            }
        }
        public class Token
        {
            public int Position { set; get; }
            public int LineNumber { set; get; }
            public string Type { set; get; }
            public string Value { set; get; }
            public Token(int position, int lineNumber, string type, string value)
            {
                this.Position = position;
                this.LineNumber = lineNumber;
                this.Type = type;
                this.Value = value;
            }
        }
        public abstract class Tokenizable
        {
            public bool isOptional;
            public Tokenizable(bool isOptional = false)
            {
                this.isOptional = isOptional;
            }
            public abstract bool tokenizable(Tokenizer tokenizer);
            public abstract Token tokenize(Tokenizer tokenizer);
        }
        public class Tokenizer
        {
            public List<Token> tokens;
            public bool enableHistory;
            public Input input;
            public Tokenizable[] handlers;
            public Tokenizer(string source, Tokenizable[] handlers)
            {
                this.input = new Input(source);
                this.handlers = handlers;
            }
            public Tokenizer(Input source, Tokenizable[] handlers)
            {
                this.input = source;
                this.handlers = handlers;
            }
            public Token tokenize()
            {
                for (int i = 0; i < this.handlers.Length; i++)
                {
                    if (this.handlers[i].tokenizable(this))
                    {
                        if (this.handlers[i].isOptional)
                        {
                            this.handlers[i].tokenize(this);
                            i = -1;
                        }
                        else
                        {
                            return this.handlers[i].tokenize(this);
                        }

                    }
                }

                //if(this.input.hasMore())
                //   throw new Exception("Tokenizer: Unexpected token at line number: " + this.input.LineNumber);
                // Message box  when exception happend
                return null;
            }
            public List<Token> all() { return null; }
        }

        public class NewLineTokenizer : Tokenizable
        {
            public NewLineTokenizer(bool isOptional = false)
            {
                this.isOptional = isOptional;
            }
            public override bool tokenizable(Tokenizer t)
            {
                return String.Concat(t.input.peek(), t.input.peek(2)) == Environment.NewLine || t.input.peek().ToString() == Environment.NewLine;
            }

            public override Token tokenize(Tokenizer t)
            {
                t.input.step(Environment.NewLine.Length);
                t.input.LineNumber++;
                return new Token(t.input.Position, t.input.LineNumber,
                    "NewLine", Environment.NewLine);
            }
        }

        public class sourceCodeTokenozer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                //    WriteLine("Handler "); 
              //  List<string> keywords = new List<string> { "CRC", "LIN", "REC" };
               // string concatnatedStrings = String.Concat(String.Concat(t.input.peek(), t.input.peek(2)), t.input.peek(3));

                return true;
            }

            bool hex(string word)
            {
                word = word.ToUpper();
                foreach (var letter in word)
                {
                    if (!((letter >= '0' && letter <= '9') || (letter >= 'A' && letter <= 'F')))
                    {
                        return false;
                    }
                }

                return true;
            }

            public override Token tokenize(Tokenizer t)
            {

                string value = "";
                Console.WriteLine("We are in");
                List<string> styles = new List<string> { "DASH", "SOLID", "DOT" ,"DASHDOT"};
                List<string> truth = new List<string> { "TRUE", "FALSE" };

                for (int i = 0; i < 3; i++)
                {
                    value += t.input.step().Character;
                }

                if (t.input.hasMore() && t.input.peek() == '(') //Check open bracket 
                {
                    value += t.input.step().Character;

                    if (t.input.hasMore() && Char.IsDigit(t.input.peek())) // check X 
                    {
                        while (t.input.hasMore() && Char.IsDigit(t.input.peek()))
                        {
                            value += t.input.step().Character;
                        }
                        if (t.input.hasMore() && t.input.peek() == ',') //  first comma 
                        {
                            value += t.input.step().Character;
                            if (t.input.hasMore() && Char.IsDigit(t.input.peek())) //Check Y 
                            {

                                while (t.input.hasMore() && Char.IsDigit(t.input.peek()))
                                {
                                    value += t.input.step().Character;
                                }
                                if (t.input.hasMore() && t.input.peek() == ',') //  sec comma 
                                {
                                    value += t.input.step().Character;

                                    if (t.input.hasMore() && Char.IsDigit(t.input.peek())) //Check width
                                    {
                                        while (t.input.hasMore() && Char.IsDigit(t.input.peek()))
                                        {
                                            value += t.input.step().Character;
                                        }
                                        if (t.input.hasMore() && t.input.peek() == ',') //third comma 
                                        {
                                            value += t.input.step().Character;
                                            if (t.input.hasMore() && Char.IsDigit(t.input.peek())) //Check Height
                                            {
                                                while (t.input.hasMore() && Char.IsDigit(t.input.peek()))
                                                {
                                                    value += t.input.step().Character;
                                                }

                                                if (t.input.hasMore() && t.input.peek() == ')')
                                                {
                                                    value += t.input.step().Character;
                                                    string concatnatedStrings = String.Concat(String.Concat(t.input.peek(), t.input.peek(2)), t.input.peek(3)); // hardcoded we need to use concat somehow 
                                                    Console.WriteLine(concatnatedStrings);
                                                    if (concatnatedStrings.ToUpper() == "PEN")  // Check pen
                                                    {
                                                        for (int i = 0; i < 3; i++)
                                                        {
                                                            value += t.input.step().Character;
                                                        }
                                                        if (t.input.hasMore() && t.input.peek() == '(')
                                                        {
                                                            value += t.input.step().Character;
                                                            concatnatedStrings = "";
                                                            while (t.input.hasMore() && Char.IsLetterOrDigit(t.input.peek()))
                                                            {
                                                                concatnatedStrings += t.input.step().Character;
                                                            }
                                                            try
                                                            {
                                                                if (concatnatedStrings.Length == 8 && hex(concatnatedStrings))
                                                                {
                                                                    ColorTranslator.FromHtml("#" + concatnatedStrings);
                                                                }
                                                                else
                                                                {
                                                                    ColorTranslator.FromHtml(concatnatedStrings);
                                                                }

                                                                value += concatnatedStrings;
                                                            }
                                                            catch
                                                            {
                                                                value = "invalid";
                                                                return new Token(t.input.Position, t.input.LineNumber, "Source code", value);


                                                                // add error message
                                                            }
                                                            // Don't forget to create a try and catch clauses
                                                        }
                                                        if (t.input.hasMore() && t.input.peek() == ',')
                                                        {
                                                            value += t.input.step().Character;

                                                            if (t.input.hasMore() && Char.IsDigit(t.input.peek()))
                                                            {


                                                                value += t.input.step().Character;
                                                                if (t.input.hasMore() && t.input.peek() == ',')
                                                                {
                                                                    value += t.input.step().Character;
                                                                    if (t.input.hasMore() && Char.IsLetter(t.input.peek()))
                                                                    {
                                                                        concatnatedStrings = "";
                                                                        while (t.input.hasMore() && Char.IsLetter(t.input.peek()))
                                                                        {
                                                                            concatnatedStrings += t.input.step().Character;

                                                                        }
                                                                        if (styles.Contains(concatnatedStrings.ToUpper()))
                                                                        {
                                                                            value += concatnatedStrings;
                                                                            if (t.input.hasMore() && t.input.peek() == ',')
                                                                            {
                                                                                value += t.input.step().Character;
                                                                                if (t.input.hasMore() && Char.IsLetter(t.input.peek()))
                                                                                {
                                                                                    concatnatedStrings = "";
                                                                                    while (t.input.hasMore() && Char.IsLetter(t.input.peek()))
                                                                                    {
                                                                                        concatnatedStrings += t.input.step().Character;

                                                                                    }
                                                                                    if (truth.Contains(concatnatedStrings.ToUpper()))
                                                                                    {
                                                                                        value += concatnatedStrings;

                                                                                        if (t.input.hasMore() && t.input.peek() == ')')
                                                                                        {
                                                                                            value += t.input.step().Character;
                                                                                            if (t.input.hasMore() && t.input.peek() == ';')
                                                                                            {
                                                                                                value += t.input.step().Character;


                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }
                                                                        }


                                                                    }
                                                                }
                                                            }
                                                        }



                                                    }

                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }


                else
                {

                    value = "invalid";
                }

                if (!value.Contains(';'))
                {
                    value = "invalid";
                }
                return new Token(t.input.Position, t.input.LineNumber, "Source code", value);
            }
        }

    

}
