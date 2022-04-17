using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBaseCalculator
{

    public class Tokenizer
    {

        private TextReader _reader;
        private char _currentChar;

        public Tokenizer(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextToken();
        }

        public Token Token { get; private set; }
        public double Number { get; private set; }
        public string Identifier { get; private set; }


        // Read the next character from the input strem
        // and store it in _currentChar, or load '\0' if EOF
        void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }

        // Read the next token from the input stream
        public void NextToken()
        {
            // Skip whitespace
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            // Special characters
            switch (_currentChar)
            {
                case '\0':
                    Token = Token.EOF;
                    return;

                case '+':
                    NextChar();
                    Token = Token.Add;
                    return;

                case '-':
                    NextChar();
                    Token = Token.Subtract;
                    return;

                case '*':
                    NextChar();
                    Token = Token.Multiply;
                    return;

                case '/':
                    NextChar();
                    Token = Token.Divide;
                    return;

                case '(':
                    NextChar();
                    Token = Token.OpenParenthesis;
                    return;

                case ')':
                    NextChar();
                    Token = Token.CloseParenthesis;
                    return;

                case ',':
                    NextChar();
                    Token = Token.Comma;
                    return;
            }

            // Number?
            if (char.IsDigit(_currentChar) || _currentChar =='.')
            {
                // Capture digits/double point
                var sb = new StringBuilder();
                bool havedoublePoint = false;
                while (char.IsDigit(_currentChar) || (!havedoublePoint && _currentChar == '.'))
                {
                    sb.Append(_currentChar);
                    havedoublePoint = _currentChar == '.';
                    NextChar();
                }

                // Parse it
                Number = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                Token = Token.Number;
                return;
            }

            // Identifier - starts with letter or underscore
            if (char.IsLetter(_currentChar) || _currentChar == '_')
            {
                var sb = new StringBuilder();

                // Accept letter, digit or underscore
                while (char.IsLetterOrDigit(_currentChar) || _currentChar == '_')
                {
                    sb.Append(_currentChar);
                    NextChar();
                }

                // Setup token
                Identifier = sb.ToString();
                Token = Token.Variable;
                return;
            }
        }
    }
}
