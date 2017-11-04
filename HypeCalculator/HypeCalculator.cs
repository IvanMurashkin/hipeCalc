using CalcLibrary;
using DBModel;
using DBModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private IOperation currentOperation { get; set; }

        private IList<string> Favorites { get; set; }

        private IList<string> heavyOperations { get; set; }

        public HypeCalculator() {
            InitializeComponent();
            heavyOperations = DB.GetHeavyOperations();
            Favorites = new List<string>();
            foreach (var fav in DB.GetFavorits()) {
                AddFavoriteButton(fav.Name, Favorites.Count());
                Favorites.Add(fav.Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void cbOperation_SelectedIndexChanged(object sender, EventArgs e) {
            currentOperation = cbOperation.SelectedItem as IOperation;

            if(currentOperation != null && Favorites.Contains(currentOperation.Name)) {
                btnLikeOrDel.Text = "Delete";
            } else if (!Favorites.Contains(currentOperation.Name)) {
                btnLikeOrDel.Text = "Like";
            }

        }

        private void HypeCalculator_Load(object sender, EventArgs e) {

            Calc = new Calculator();
            var operations = CalcHelper.GetOperations();
            foreach (var op in operations) {
                Calc.Operations.Add(op);
            }

            cbOperation.DataSource = Calc.Operations;
            cbOperation.DisplayMember = "Name";
            cbOperation.ValueMember = "Name";

        }

        private void btnCalc_Click(object sender, EventArgs e) {
            Calculate();
        }

        private void btnLikeOrDel_Click(object sender, EventArgs e) {

            if (currentOperation == null)
                return;

            if (btnLikeOrDel.Text == "Like") {

                AddFavoriteButton(currentOperation.Name, Favorites.Count());
                DB.AddFavorite(new Favorite(currentOperation.Name, currentOperation.IsCustom));
                Favorites.Add(currentOperation.Name);
                btnLikeOrDel.Text = "Delete";
            } else {
                DB.DeleteFavorite(new Favorite(currentOperation.Name));
                RemoveFavoriteButton();
                btnLikeOrDel.Text = "Like";
            }
        }

        private Button AddFavoriteButton(string name, int countPanleItems) {
            var button = new Button();
            ToolTip toolTip = new ToolTip();
            
            var calcBtnLocationX = 5 * countBtnsRow + ( countBtnsRow * button.Width );
            var calcBtnLocationY = button.Height * (int) Math.Floor((double) ( countPanleItems / MaxCountBnnsRow ));

            
            if (countPanleItems == 0) {
                button.Location = new Point(1, calcBtnLocationY);
            } else {
                if (countBtnsRow >= MaxCountBnnsRow) {
                    calcBtnLocationX = 1;
                    countBtnsRow = 1;
                    button.Location = new Point(calcBtnLocationX, calcBtnLocationY);
                } else {
                    countBtnsRow++;
                    button.Location = new Point(calcBtnLocationX, calcBtnLocationY);
                }
            }

            button.Name = "button" + panelBtns.Controls.Count;
            button.Size = new Size(75, 23);
            button.TabIndex = 0;
            button.Text = name;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(btn_Click);
            toolTip.SetToolTip(button, button.Text);

            panelBtns.Controls.Add(button);

            return button;
        }

        private void RemoveFavoriteButton() {
            var removeBtn = panelBtns.Controls[Favorites.IndexOf(currentOperation.Name)];
            removeBtn.Click -= new EventHandler(btn_Click);
            panelBtns.Controls.Remove(removeBtn);
            removeBtn.Dispose();
        }

        private void btn_Click(object sender, EventArgs e) {

            var button = sender as Button;
            if (button == null) {
                return;
            }

            cbOperation.SelectedItem = button.Text;

            Calculate();
        }

        private void Calculate() {
            timer1.Stop();

            // понять какая операция выбрана
            if (currentOperation == null)
                return;

            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
                return;

            var args = textBoxInput.Text.Trim();

            double? result;

            OperationHistory history = null;

            if (!heavyOperations.Contains(currentOperation.Name)) {
                result = Calculate(args, out history);
            }
            else {
                var dbResult = DB.GetOperationHistory(currentOperation.Name, args);
                if (dbResult != null) {
                    result = dbResult.Result;
                }
                else {
                    result = Calculate(args, out history);
                }
            }

            labelResult.Text = $"{result}";

            if (history != null) {
                DB.AddOperationHistory(history);
            }
        }

        private double? Calculate(string args, out OperationHistory history) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var inputData = CalcHelper.StringConvert(args);
            var result = currentOperation.Excecute(inputData);
            stopWatch.Stop();

            history = new OperationHistory() {
                Name = currentOperation.Name,
                Result = result,
                Args = args,
                ExcecTime = stopWatch.ElapsedMilliseconds
            };

            return result;
        }

        private void textBoxInput_Click(object sender, EventArgs e) {
            textBoxInput.SelectAll();
        }

        private void textBoxInput_KeyUp(object sender, KeyEventArgs e) {

            timer1.Stop();

            timer1.Start();

            if (e.KeyCode == Keys.Enter) {
                Calculate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Calculate();
        }
    }
}
