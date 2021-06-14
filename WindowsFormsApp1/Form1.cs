using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Lexico Analiza_Lexico = new Lexico();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        class Automata{
            string _textoIma;
            int _edoAct;
            char SigCar(ref int i)
            {
                if (i == _textoIma.Length)
                {
                    i++;
                    return ' ';

                }
                else
                    return _textoIma[i++];
            }
             public bool Reconoce (string texto,int iniToken,ref int i,int noAuto)
            {
                char c;
                _textoIma = texto;
                string lenguaje;
                switch (noAuto)
                {
                    case 0: _edoAct = 0;
                        break;
                        //---------Automata delimmm-----
                    case 1: _edoAct = 3;
                        break;
                    //---------Automata delimmm-----
                    case 2: _edoAct = 6;
                        break;
                    case 3: _edoAct = 9;
                        break;
                    case 4: _edoAct = 11;
                        break;

                }
                while(i<=_textoIma.Length)
                    switch (_edoAct)
                    {
                        case 0: c = SigCar(ref i);
                            if ((lenguaje = " \n\r\t").IndexOf(c) >= 0)
                                _edoAct=1;
                            else
                            {
                                i = iniToken;
                                return false;
                            }
                            break;
                        case 1:  c= SigCar(ref i);
                            if ((lenguaje = " \n\r\t").IndexOf(c)>= 0)
                                _edoAct = 1;
                            else {
                                if ((lenguaje = "!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_'abcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                                    _edoAct = 2;
                                else
                                {
                                    i = iniToken;
                                    return false;
                                } 
                                    
                            }break;
                        case 2: i--;
                            return true;
                            break;
                        case 3: c = SigCar(ref i);
                            if ((lenguaje = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                                _edoAct = 4;
                            else
                            {
                                i = iniToken;
                                return false;
                            }break;
                        case 4: c = SigCar(ref i);
                            if ((lenguaje = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                                _edoAct = 4;
                            else  if ((lenguaje = "0123456789").IndexOf(c) >= 0)
                                    _edoAct = 4;
                            else  if ((lenguaje = "_").IndexOf(c) >= 0)
                                        _edoAct = 4;
                                            
                            else  if ((lenguaje = "!\"#$%&\'()*+,-./:;<=>?@[\\]^`{│}~ \n\t\r\f").IndexOf(c) >= 0)
                                        _edoAct = 5;
                                             else { i = iniToken;
                                    return false;
                                }
                                break;
                        case 5: i--;
                            return true;
                            break;
                        case 6:
                            c = SigCar(ref i);
                            if ((lenguaje = "0123456789").IndexOf(c) >= 0)
                                _edoAct = 7; else
                            {
                                i = iniToken;
                                return false;
                            } break;
                        case 7: c = SigCar(ref i);
                            if ((lenguaje = "0123456789").IndexOf(c) >= 0)
                                _edoAct = 7;
                            else if ((lenguaje = "!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_'abcdefghijklmnopqr").IndexOf(c) >= 0)
                                _edoAct = 8; else
                            {
                                i = iniToken;
                                return false;
                            }break;

                        case 8: i--;
                            return true;
                            break;
                        case 9: c = SigCar(ref i);
                            if ((lenguaje = "=").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = ";").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = ",").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = ".").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = "+").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = "_").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = "*").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = "/").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = "(").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else if ((lenguaje = ")").IndexOf(c) >= 0)
                                _edoAct = 10;
                            else { i = iniToken;return false; }
                            break;
                        case 10: return true;
                            break;
                        case 11: c = SigCar(ref i);
                            if ((lenguaje = "\"").IndexOf(c) >= 0)
                                _edoAct = 12;
                            else { i = iniToken;
                                return false;
                            }break;
                        case 12: c = SigCar(ref i);
                            if ((lenguaje = "\"").IndexOf(c) >= 0)
                                _edoAct = 13;
                            else if ((lenguaje = "!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_'abcdefghijklmnopqrstuvwxyz").IndexOf(c) >= 0)
                                _edoAct = 12;
                            else { i = iniToken;
                                return false;
                            }break;
                        case 13: return true;
                            break;

                          







                    }
                switch(_edoAct)
                {
                    case 2:
                    case 5:
                    case 8:
                        --i;
                        return true;
                }
                return false;
                        

            }//Fin de clase Automata.
        } class Lexico
        {
            const int Tokenc = 5;
            const int maxtokens = 500;
            string[] _lexemas;
            string[] _tokens;
            string _lexema;
            int _notokens;
            int _i;
            int _initoken;
            Automata oAFD;
            public Lexico()
            {
                _lexemas = new string[maxtokens];
                _tokens = new string[maxtokens];
                oAFD = new Automata();
                _i = 0;
                _initoken = 0;
                _notokens = 0;
            }
            public int Notokens
            {
                get { return _notokens; }
            }
            public string [] Lexema
            {
                get { return _lexemas; }
            }

            public string [] Token
            {
                get { return _tokens; }
            }
            public void Inicia()
            {
                _i = 0;
                _initoken = 0;
                _notokens = 0;

            }
            public void Analiza(string texto)
            {
                bool recAuto;
                int noAuto;
                while(_i< texto.Length)
                {
                    recAuto = false;
                    noAuto = 0;
                    for (; noAuto < Tokenc && !recAuto;)
                        if (oAFD.Reconoce(texto, _initoken, ref _i, noAuto))
                            recAuto = true;
                        else noAuto++;
                    if (recAuto)
                    {
                        _lexema = texto.Substring(_initoken, _i - _initoken);
                        switch (noAuto)
                        {
                            case 0:
                                break;
                            case 1:
                                if (EsId())
                                    _tokens[_notokens] = "id";
                                else _tokens[_notokens] = _lexema;
                                break;
                            case 2:
                                _tokens[_notokens] = "num";
                                break;
                            case 3:
                                _tokens[_notokens] = _lexema;
                                break;
                            case 4:
                                _tokens[_notokens] = "cad";
                                break;

                        }
                        if (noAuto != 0)
                            _lexemas[_notokens++] = _lexema;

                    }
                    else _i++;
                    _initoken = _i;
                       
                }
            }
            private bool EsId()
            {
                string[] palres = { "inicio", "fin", "const", "var", "entero", "real", "cadena", "leer", "visua" };
                for (int i = 0; i < palres.Length; i++)
                    if (_lexema == palres[i])
                        return false;
                return true;
            }

                

        }//Fin clase lexico

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Analiza_Lexico.Inicia();
            Analiza_Lexico.Analiza(textBox1.Text);
            dataGridView1.Rows.Clear();
            if (Analiza_Lexico.Notokens > 0)
                dataGridView1.Rows.Add(Analiza_Lexico.Notokens);
            for(int i =0; i<Analiza_Lexico.Notokens;i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = Analiza_Lexico.Token[i];
                dataGridView1.Rows[i].Cells[1].Value = Analiza_Lexico.Lexema[i];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = " ";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
