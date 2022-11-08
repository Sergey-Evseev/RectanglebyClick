/*4.Разработать приложение, созданное на основе формы. Пользователь «щелкает» 
левой кнопкой мыши по форме и, не отпуская кнопку, ведет по ней мышку,
а в момент отпускания кнопки по полученным координатам прямоугольника (вам, конечно, известно,
что двух точек на плоскости достаточно для создания прямоугольника) необходимо создать «статик»,
который содержит свой порядковый номер (имеется в виду порядок появления на форме).*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace RectanglebyClick
{
    public partial class Form1 : Form
    {
        private int X, Y;
        //счетчик лейблов
        static int count = 0;        

        public Form1()        {          
            
            InitializeComponent();
        }
        //обработчик нажатия кнопки
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }
        //обработчик отжатия кнопки
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int size1 = e.X - X; //разница координат Х между нажатием и отжатием левой кнопки
                int size2 = e.Y - Y; //разница координат Y между нажатием и отжатием левой кнопки

                //обработка отрицательных отрезков
                if (size1 < 0)
                {
                    size1 = -size1; X = e.X;
                }
                if (size2 < 0)
                {
                size2 = -size2; Y = e.Y;
                }
                //проверка условия на минимальный размер
                if ((size1 < 10) || (size2 < 10))
                {
                    MessageBox.Show("Размер меньше 10 px, выберите больший размер", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //создание и инициализация лейбла по углам нажатия мыши
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                //лейбл создается в точке нажатия левой кнопки при положительных отрезках
                //и при отжатии кнопки при отрицательных (см. строку кода 50)
                lbl.Location = new System.Drawing.Point(X, Y); 
                lbl.Size = new System.Drawing.Size(size1, size2);

                //блок формирования случайного цвета лейбла
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                lbl.BackColor = randomColor; //Color.RoyalBlue;

                lbl.Text = (++count).ToString(); //присвоение порядкового номера
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.Fixed3D; //форма границы фигуры //.FixedSingle;
                this.Controls.Add(lbl); //добавление лейбла в контейнер 
                lbl.MouseClick += Lbl_MouseClick; //добавление обработчика события на одинарный клик на лейбл 
                lbl.MouseDoubleClick += Lbl_MouseDoubleClick; //добавление обработчика события двойной клик на лейбл
            }
        }//end of MouseUp handler

        //удаление лейбла по двойному клику
        private void Lbl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label lbl = sender as Label;
                this.Controls.Remove(lbl);
                lbl.Dispose();
            }
        }
        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
            Label lbl = sender as Label;
                this.Text = $"Area: {lbl.Width * lbl.Height}, " +
                    $"location X: {lbl.Location.X}, location Y: {lbl.Location.Y}"; ;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
