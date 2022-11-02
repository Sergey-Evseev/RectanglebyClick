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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectanglebyClick
{
    public partial class Form1 : Form
    {
        private int X, Y;
        static int count;        

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
            int size1 = e.X - X; 
            int size2 = e.Y - Y;

                if (size1 < 0)
                {
                    size1 = -size1;
                    X = e.X;
                }
                if (size2 < 0)
                {
                size2 = -size2;
                    Y = e.Y;
                }
                if ((size1 < 10) || (size2 < 10))
                {
                    MessageBox.Show("Размер меньше 10 px, выберите больший размер", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }//end of MouseUp handler

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

    }
}
