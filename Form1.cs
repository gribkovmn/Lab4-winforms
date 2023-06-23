using System.Globalization;
using System.Numerics;

namespace Lab4_winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double stringToDouble(string s)
        {
            // Разбираемся с точками и запятыми в разных локалях.
            double result;

            double.TryParse(
                s.Replace(",", "."),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out result
            );
            return result;

        }


        private double process(double x, double a, double b, double c)
        {
            /* Прогон по формуле */
            return Math.Pow(10, -2) * b * c / x + Math.Cos(Math.Sqrt(Math.Pow(a, 3) * x));

        }
        private Complex processComplex(double x, double a, double b, double c)
        {
            /* Там, где вторая часть формулы принимает отрицательное значение, используем комплексные числа. */
            return Complex.Pow(10, -2) * b * c / x + Complex.Cos(Complex.Sqrt(Complex.Pow(a, 3) * x));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x0 = stringToDouble(textBox1.Text.ToString());
            double xk = stringToDouble(textBox2.Text.ToString());
            double dx = stringToDouble(textBox3.Text.ToString());

            double a = stringToDouble(textBox4.Text.ToString());
            double b = stringToDouble(textBox5.Text.ToString());
            double c = stringToDouble(textBox6.Text.ToString());

            double x = x0;
            int counter = 0;
            textBox7.Text = $"ЛР №4, выполнил ст. гр 19-ИБ411 Грибков М.Н. {Environment.NewLine}";
            textBox7.AppendText($"x0 = {x0}; xk = {xk}; dx = {dx}{Environment.NewLine}a = {a}; b = {b}; c = {c} {Environment.NewLine}");
            while (x < xk)
            {
                if (Math.Pow(a, 3) * x < 0)
                {
                    textBox7.AppendText($"x({counter}) = {x}; y(x) = (комплексное число) {processComplex(x, a, b, c)}{Environment.NewLine}");
                } else
                {
                    textBox7.AppendText($"x({counter}) = {x}; y(x) = {process(x, a, b, c)}{Environment.NewLine}");
                }
                
                x += dx;
                counter++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Табулирование функций";

            textBox1.Text = "-1.5";  //x0
            textBox2.Text = "3.5";   //xk
            textBox3.Text = "0.5";   //dx

            textBox4.Text = "-1.25"; //a
            textBox5.Text = "-1.5";  //b
            textBox6.Text = "0.75";  //c


        }
    }
}