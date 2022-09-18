using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analizadorSintactico
{
    internal class analizador
    {
        public const int ERROR = -1;
        public const int INICIAL = 55;
        public const int IDENTIFICADOR = 0;
        public const int ENTERO = 1;
        public const int REAL = 2;
        public const int CADENA = 3;
        public const int TIPO = 4;
        public const int OPSUMA = 5;
        public const int OPMUL = 6;
        public const int OPRELAC = 7;
        public const int OPOR = 8;
        public const int OPAND = 9;
        public const int OPNOT = 10;
        public const int OPIGUALDAD = 11;
        public const int PUNTOCOMA = 12;
        public const int COMA = 13;
        public const int PARENTESISIZQ = 14;
        public const int PARENTESISDER = 15;
        public const int LLAVEIZQ = 16;
        public const int LLAVEDER = 17;
        public const int IGUAL = 18;
        public const int IF = 19;
        public const int WHILE = 20;
        public const int RETURN = 21;
        public const int ELSE = 22;
        public const int SIGNOPESOS = 23;

        public String[] tipoDatos = new String[] { "int", "float", "void" };
        public String[] reservadas = new String[] { "if", "while", "return", "else" };


        List<String> errores;
        List<String> tokens;
        List<String> analisis;
        List<String> obtenerAnalisis;
        List<Reglas> reglas;

        Pila pila;
        int[,] matriz = new int[95, 45];

        int cont;

        public analizador()
        {
            errores = new List<String>();
            tokens = new List<String>();
            analisis = new List<String>();
            obtenerAnalisis = new List<String>();
            reglas = new List<Reglas>();

            pila = new Pila();
            cargarMatriz();
            cargarReglas();
            cont = 0;
        }

        public void cargarMatriz()
        {
            int delimitador = 9;
            char _dem = Convert.ToChar(delimitador);
            String[] lineas = File.ReadAllLines(@"C:\Users\samgl\Documents\Seminario Traductores II\este si funciona{\analizadorSintactico\compilador.lr", Encoding.Default);
            for (int i = 0; i < lineas.Count(); i++)
            {
                for (int j = 0; j < 45; j++)
                {
                    matriz[i, j] = Convert.ToInt32(lineas[i].Split(_dem)[j]);
                }
            }
        }

        public void cargarReglas()
        {
            int delimitador = 9;
            char _dem = Convert.ToChar(delimitador);
            string[] lineas = File.ReadAllLines(@"C:\Users\samgl\Documents\Seminario Traductores II\este si funciona{\analizadorSintactico\reglas.txt", Encoding.Default);
            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(_dem);
                string primero = partes[0];
                string segundo = partes[1];
                reglas.Add(new Reglas(Convert.ToInt32(primero), Convert.ToInt32(segundo), partes[2]));
            }
        }

        public void agregarToken(String lexema, int tipo)
        {
            String nuevoToken;
            switch (tipo)
            {
                case IDENTIFICADOR:
                    nuevoToken = lexema + " Identificador" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case ENTERO:
                    nuevoToken = lexema + " Entero" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case REAL:
                    nuevoToken = lexema + " Real" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case CADENA:
                    nuevoToken = lexema + " Cadena" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case TIPO:
                    nuevoToken = lexema + " Tipo de dato" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case OPSUMA:
                    if (lexema == "+")
                    {
                        nuevoToken = lexema + " Operador suma" + "\n";
                        tokens.Add(nuevoToken);
                    }
                    else if (lexema == "-")
                    {
                        nuevoToken = lexema + " Operador resta" + "\n";
                        tokens.Add(nuevoToken);
                    }
                    break;
                case OPMUL:
                    if (lexema == "*")
                    {
                        nuevoToken = lexema + " Operador multiplicación" + "\n";
                        tokens.Add(nuevoToken);
                    }
                    else if (lexema == "/")
                    {
                        nuevoToken = lexema + " Operador división" + "\n";
                        tokens.Add(nuevoToken);
                    }
                    break;
                case OPRELAC:
                    nuevoToken = lexema + " Operador relacional" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case OPOR:
                    nuevoToken = lexema + " Operador OR" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case OPAND:
                    nuevoToken = lexema + " Operador AND" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case OPNOT:
                    nuevoToken = lexema + " Operador NOT" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case OPIGUALDAD:
                    nuevoToken = lexema + " Operador igualdad" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case PUNTOCOMA:
                    nuevoToken = lexema + " punto y coma" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case COMA:
                    nuevoToken = lexema + " coma" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case PARENTESISIZQ:
                    nuevoToken = lexema + " Paréntesis Izquierdo" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case PARENTESISDER:
                    nuevoToken = lexema + " Paréntesis Derecho" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case LLAVEIZQ:
                    nuevoToken = lexema + " Llave Izquierda" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case LLAVEDER:
                    nuevoToken = lexema + " Llave Derecha" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case IGUAL:
                    nuevoToken = lexema + " Igual" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case IF:
                case WHILE:
                case RETURN:
                case ELSE:
                    nuevoToken = lexema + " es una palabra reservada" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                case SIGNOPESOS:
                    nuevoToken = lexema + " Signo de pesos" + "\n";
                    tokens.Add(nuevoToken);
                    break;
                default:
                    break;
            }
        }

        public void agregaError(String lexema)
        {
            //Añade un error
            String nuevoError;
            nuevoError = lexema + " es un carácter no admitido" + "\n";
            errores.Add(nuevoError);
        }


        public void Analizador(String texto)
        {
            int estado = 0; 
            String lexema = "";
            Char c;
            bool hayPunto = false; 
            texto = texto + "$";
            pila.push(new NoTerminal(0, "$"));
            analisis.Add(getPila());

            //Inicia el automata del analizador
            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];
                switch (estado)
                {
                    case INICIAL:
                        if (Char.IsLetter(c) || c == '_')
                        { //Verifica si es letra o empieza con un "_"
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else if (Char.IsDigit(c))
                        { //Verifica si es digito
                            estado = ENTERO;
                            lexema += c;
                        }
                        else if (c == '"')
                        {
                            estado = CADENA;
                            lexema += c;
                        }
                        else if (c == '+' || c == '-')
                        {
                            lexema += c;

                            agregarToken(lexema, OPSUMA);
                            analizadorSint(OPSUMA, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '*' || c == '/')
                        {
                            lexema += c;

                            agregarToken(lexema, OPMUL);
                            analizadorSint(OPMUL, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '<' || c == '>')
                        {
                            estado = OPRELAC;
                            lexema += c;
                        }
                        else if (c == '|')
                        {
                            estado = OPOR;
                            lexema += c;
                        }
                        else if (c == '&')
                        {
                            estado = OPAND;
                            lexema += c;
                        }
                        else if (c == '=' || c == '!')
                        {
                            if (texto[i + 1] != '=')
                            {
                                if (c == '=')
                                {
                                    lexema += c;

                                    agregarToken(lexema, IGUAL);
                                    analizadorSint(IGUAL, lexema);
                                    lexema = "";
                                    estado = INICIAL;
                                }
                                else if (c == '!')
                                {
                                    lexema += c;

                                    agregarToken(lexema, OPNOT);
                                    analizadorSint(OPNOT, lexema);
                                    estado = INICIAL;
                                    lexema = "";
                                }
                            }
                            else
                            {
                                estado = OPIGUALDAD;
                                lexema += c;
                            }
                        }
                        else if (c == ';')
                        {
                            lexema += c;

                            agregarToken(lexema, PUNTOCOMA);
                            analizadorSint(PUNTOCOMA, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;

                            agregarToken(lexema, COMA);
                            analizadorSint(COMA, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;

                            agregarToken(lexema, PARENTESISIZQ);
                            analizadorSint(PARENTESISIZQ, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;

                            agregarToken(lexema, PARENTESISDER);
                            analizadorSint(PARENTESISDER, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '{')
                        {
                            lexema += c;

                            agregarToken(lexema, LLAVEIZQ);
                            analizadorSint(LLAVEIZQ, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;

                            agregarToken(lexema, LLAVEDER);
                            analizadorSint(LLAVEDER, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else if (c == '$')
                        {
                            lexema += c;

                            agregarToken(lexema, SIGNOPESOS);
                            analizadorSint(SIGNOPESOS, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        break;
                    case IDENTIFICADOR:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            estado = IDENTIFICADOR;
                            lexema += c;
                        }
                        else
                        {
                            if (esTipoDato(lexema))
                            {
                                agregarToken(lexema, TIPO);
                                analizadorSint(TIPO, lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else if (esReservada(lexema))
                            {
                                agregarToken(lexema, tipoReservada(lexema));
                                analizadorSint(tipoReservada(lexema), lexema);
                                estado = INICIAL;
                                lexema = "";
                            }
                            else
                            {
                                agregarToken(lexema, IDENTIFICADOR);
                                analizadorSint(IDENTIFICADOR, lexema);
                                estado = INICIAL;
                                lexema = "";
                                i--;
                            }
                        }
                        break;
                    case ENTERO:
                        if (Char.IsDigit(c))
                        {
                            estado = ENTERO;
                            lexema += c;
                        }
                        else if (c == '.')
                        {
                            if (hayPunto == false)
                            {
                                estado = REAL;
                                lexema += c;
                                hayPunto = true;

                            }
                            else
                            {
                                lexema += c;
                                agregaError(lexema);

                                estado = INICIAL;
                                lexema = "";
                            }
                        }
                        else
                        {
                            agregarToken(lexema, ENTERO);
                            analizadorSint(ENTERO, lexema);
                            estado = INICIAL;
                            lexema = "";
                            i--;
                        }
                        break;
                    case REAL:
                        if (Char.IsDigit(c))
                        {
                            estado = REAL;
                            lexema += c;
                        }
                        else if (c == '.')
                        {
                            if (hayPunto)
                            {
                                lexema += c;
                                agregaError(lexema);

                                estado = INICIAL;
                                lexema = "";
                            }
                        }
                        else
                        {
                            agregarToken(lexema, REAL);
                            analizadorSint(REAL, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        break;
                    case CADENA:
                        if (c == '"')
                        {
                            lexema += c;
                            agregarToken(lexema, CADENA);
                            analizadorSint(CADENA, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else
                        {
                            estado = CADENA;
                            lexema += c;
                        }
                        break;
                    case OPRELAC:
                        if (c == '=')
                        {
                            lexema += c;

                            agregarToken(lexema, OPRELAC);
                            analizadorSint(OPRELAC, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else
                        {
                            agregarToken(lexema, OPRELAC);
                            analizadorSint(OPRELAC, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        break;
                    case OPOR:
                        if (c == '|')
                        {
                            lexema += c;

                            agregarToken(lexema, OPOR);
                            analizadorSint(OPOR, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else
                        {
                            agregarToken(lexema, OPOR);
                            analizadorSint(OPOR, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        break;
                    case OPAND:
                        if (c == '&')
                        {
                            lexema += c;

                            agregarToken(lexema, OPAND);
                            analizadorSint(OPAND, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        else
                        {
                            agregarToken(lexema, OPAND);
                            analizadorSint(OPAND, lexema);
                            estado = INICIAL;
                            lexema = "";
                        }
                        break;
                    case OPIGUALDAD:
                        lexema += c;

                        agregarToken(lexema, OPIGUALDAD);
                        analizadorSint(OPIGUALDAD, lexema);
                        estado = INICIAL;
                        lexema = "";
                        break;
                    default:
                        break;
                }
            }
            //Termina el automata
        }

        public void analizadorSint(int estado, String simb) //Analizador sintáctico
        {
            if (estado == SIGNOPESOS)
            {
                int i = (matriz[cont, estado] * -1) - 2;
                if (i == -1)
                {
                    obtenerAnalisis.Add("R" + 0);
                    return;
                }
                else
                {
                    if (reglas[i].num_va == 0)
                    {
                        int num_regla = reglas[i].num;
                        cont = matriz[cont, num_regla];
                        pila.push(new Terminal(cont, reglas[i].nombre));
                        analisis.Add(getPila());
                        obtenerAnalisis.Add("R" + (i + 1));
                        analizadorSint(estado, simb);
                    }
                    else
                    {
                        int num_regla = reglas[i].num;
                        pila.vaciarPila();
                        pila.push(new NoTerminal(0, "$"));
                        cont = matriz[0, num_regla];
                        pila.push(new Terminal(cont, reglas[i].nombre));
                        analisis.Add(getPila());
                        obtenerAnalisis.Add("R" + (i + 1));
                        analizadorSint(estado, simb);
                    }
                }
            }
            else
            {
                if (matriz[cont, estado] > 0)
                {
                    cont = matriz[cont, estado];
                    pila.push(new NoTerminal(cont, simb));
                    analisis.Add(getPila());
                    obtenerAnalisis.Add("D" + cont);
                }
                else if (matriz[cont, estado] < 0)
                {
                    int i = (matriz[cont, estado] * -1) - 1;
                    int num_regla = reglas[i].num;
                    cont = matriz[cont, num_regla];
                    pila.push(new NoTerminal(cont, reglas[i].nombre));
                    analisis.Add(getPila());
                    obtenerAnalisis.Add("R" + i);
                    analizadorSint(estado, simb);
                }
            }
        }

        public Boolean esTipoDato(String lexema)
        {
            for (int i = 0; i < tipoDatos.Length; i++)
            {
                if (tipoDatos[i].Equals(lexema))
                {
                    return true;
                }
            }
            return false;
        }


        public Boolean esReservada(String lexema)
        {
            for (int i = 0; i < reservadas.Length; i++)
            {
                if (reservadas[i].Equals(lexema))
                {
                    return true;
                }
            }
            return false;
        }

        public int tipoReservada(String lexema)
        {
            switch (lexema)
            {
                case "if":
                    return IF;
                case "while":
                    return WHILE;
                case "return":
                    return RETURN;
                case "else":
                    return ELSE;
                default:
                    return ERROR;
            }
        }

        public String getToken()
        {
            String lista = String.Join(Environment.NewLine, tokens.ToArray());
            return lista;

        }

        public String getErrores()
        {
            String lista = String.Join(Environment.NewLine, errores.ToArray());
            return lista;
        }

        public String getPila()
        {
            String s = "";
            foreach (Elemento dato in pila.listaPila)
            {
                s = s + dato.simbolo + dato.tipo;
            }
            s = s + "\n";
            return s;
        }

        public List<String> getAnalisis()
        {
            return analisis;
        }

        public List<String> getSalida()
        {
            return obtenerAnalisis;
        }
    }
}
