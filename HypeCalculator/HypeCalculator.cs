using CalcLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypeCalculator {
    public partial class HypeCalculator : Form {

        const int MaxCountBnnsRow = 4;
        int countBtnsRow = 1;

        private Calculator Calc { get; set; }

        private IOperation usedOperation = null;

        private IList<string> Favorites { get; set; }

        public HypeCalculator() {
            Favorites = new List<string>();
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedItem = cbOperation.SelectedItem as string;

            btnLike.Visible = !Favorites.Contains(selectedItem);
        }

        private void HypeCalculator_Load(object sender, EventArgs e) {

            Calc = new Calculator();

            var operations = CalcHelper.GetOperations();
            foreach (var op in operations) {

                Calc.Operations.Add(op);

            }
            cbOperation.Items.AddRange(Calc.Operations.Select(o => o.Name).ToArray());
        }

        private void btnCalc_Click(object sender, EventArgs e) {
            IOperation currentOperation;
            var selectedItem = cbOperation.SelectedItem as string;
            if (usedOperation != null && usedOperation.Name == selectedItem) {
                currentOperation = usedOperation;
            } else {
                currentOperation = Calc.Operations.FirstOrDefault(o => o.Name == selectedItem);
            }

            if (currentOperation == null) {
                labelRes.Text = $"operation \"{selectedItem}\" not found...";
                return;
            }
            usedOperation = currentOperation;

            var data = textBoxInput.Text.Split(' ')
                .Select(n => n.ToDouble())
                .ToArray();

            var inputData = data;

            var result = currentOperation.Excecute(inputData);

            labelRes.Text = $"{result}";
        }

        private void btnLike_Click(object sender, EventArgs e) {

            var selectedItem = cbOperation.SelectedItem as string;

            var countPanleItems = panelBtns.Controls.Count;

            #region Добавляем кнопку

            var button = new Button();
            ToolTip toolTip = new ToolTip();

            var calcBtnLocationX = 5 * countBtnsRow + ( countBtnsRow * button.Width );
            var calcBtnLocationY = button.Height * (int) Math.Floor((double) ( countPanleItems / MaxCountBnnsRow ));

            if (countPanleItems == 0) {
                button.Location = new Point(1, calcBtnLocationY);
            } else {
                if (calcBtnLocationX > panelBtns.Width) {
                    calcBtnLocationX = 1;
                    countBtnsRow = 1;
                    button.Location = new Point(calcBtnLocationX, calcBtnLocationY);
                } else {
                    countBtnsRow++;
                    button.Location = new Point(calcBtnLocationX, calcBtnLocationY);
                }
            }
            // this.button2.Location = new System.Drawing.Point(95, 9);
            // this.button3.Location = new System.Drawing.Point(13, 38);

            button.Name = "button" + panelBtns.Controls.Count;
            button.Size = new Size(75, 23);
            button.TabIndex = 0;
            button.Text = selectedItem;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(btn_Click);
            toolTip.SetToolTip(button, button.Text);

            panelBtns.Controls.Add(button);

            #endregion

            // добавляем операцию в список избранных
            Favorites.Add(selectedItem);

            // скрыть кнопку
            btnLike.Visible = false;

        }

        private void btn_Click(object sender, EventArgs e) {

            var button = sender as Button;
            if (button == null) {
                return;
            }

            cbOperation.SelectedItem = button.Text;

        }

    }
}
