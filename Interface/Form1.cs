using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CalculatorLibrary.General;
using CalculatorLibrary.Memories;

namespace Interface
{
    public partial class Form1 : Form
    {
        private RealCalculator calc = new RealCalculator();
        private string currentInput = "";
        private string operation = "";
        /// <summary>
        /// Эхний операторын өмнө гараас оруулсан тоог шууд result руу хадгална
        /// Дараагийн оролтуудыг шууд add/substruct function ажиллуулах замаар result-д нэмнэ.
        /// </summary>
        private bool isFirstOperation = true;
        private FlowLayoutPanel memoryPanel = new FlowLayoutPanel(); // Panel for memory
        private FlowLayoutPanel optionPanel = null; // Panel for MC, M+, M-
        private FlowLayoutPanel memoryItemPanel = null; //Panel for memory item
        public Form1()
        {
            InitializeComponent();

            // Initialize memory panel (always visible)
            memoryPanel.AutoSize = true;
            memoryPanel.FlowDirection = FlowDirection.TopDown;
            memoryPanel.Visible = true;
            memoryPanel.BackColor = System.Drawing.Color.LightGray;
            Controls.Add(memoryPanel);
            memoryPanel.Location = new System.Drawing.Point(350, 75); // Adjust location

            // Number buttons
            foreach (var btn in new[] { button0, button1, button2, button3, button4, button5, button6, button7, button8, button9 })
            {
                btn.Click += NumberButton_Click;
            }

            // Operator buttons
            foreach (var btn in new[] { buttonAdd, buttonSubtract, buttonEqual })
            {
                btn.Click += OperationButton_Click;
            }

            // Clear button
            buttonClear.Click += buttonClear_Click;

            // Memory buttons
            buttonMemoryStore.Click -= buttonMemoryStore_Click;
            buttonMemoryStore.Click += buttonMemoryStore_Click;

            // Load existing memory items on startup
            UpdateMemoryPanel();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            currentInput += btn.Text;
            textBoxResult.Text = currentInput; //result ruu shuud nemeh
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            if (!string.IsNullOrEmpty(currentInput))
            {
                if (isFirstOperation)
                {
                    FirstOperation();
                    isFirstOperation = false;
                }
                else
                {
                    SecondOperation();
                }
            }

            if (btn.Text == "=")
            {
                textBoxResult.Text = calc.Result.ToString();
                isFirstOperation = true;
                operation = "";
            }
            else
            {
                operation = btn.Text;
            }
        }

        private void FirstOperation()
        {
            if (double.TryParse(currentInput, out double num))
            {
                calc.Result = num;
                currentInput = "";
            }
        }

        private void SecondOperation()
        {
            if (!double.TryParse(currentInput, out double num)) return;

            switch (operation)
            {
                case "+":
                    calc.Add(num);
                    break;
                case "-":
                    calc.Subtract(num);
                    break;
            }

            textBoxResult.Text = calc.Result.ToString();
            currentInput = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            calc.Clear();
            textBoxResult.Text = "0";
            currentInput = "";
            operation = "";
            isFirstOperation = true;
        }

        // Memory Functions
        private void buttonMemoryStore_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxResult.Text, out double value))
            {
                calc.Memo.Store(value);
                UpdateMemoryPanel();
                currentInput = "";
            }
        }

        private void UpdateMemoryPanel()
        {
            memoryPanel.Controls.Clear(); //  Remove old items before updating

            List<double> memoryValues = calc.Memo.RecallAll();
            if (memoryValues.Count > 0)
            {
                for (int i = 0; i < memoryValues.Count;  i++)
                {
                    int index = i;
                    //
                    memoryItemPanel = new FlowLayoutPanel() { AutoSize = true, FlowDirection = FlowDirection.TopDown }; ;

                    Label memoryButton = new Label()
                    {
                        Text = memoryValues[i].ToString(), //Display stored value
                        AutoSize = true,
                        Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                        Tag = index,
                        Anchor = AnchorStyles.Right,
                        
                    };

                    //new panel for MC, M+, M-                    
                    optionPanel = new FlowLayoutPanel() { AutoSize = true };
                    Button btnMC = new Button() { Text = "MC", AutoSize = true };
                    Button btnMPlus = new Button() { Text = "M+", AutoSize = true };
                    Button btnMMinus = new Button() { Text = "M-", AutoSize = true };



                    btnMC.Click += (s, ev) =>
                    {
                        calc.Memo.ClearMemoryItem(index);
                        UpdateMemoryPanel(); // Refresh panel after clearing item
                    };

                    btnMPlus.Click += (s, ev) =>
                    {
                        if (double.TryParse(textBoxResult.Text, out double value))
                        {
                            calc.Memo.AddToMemory(index, value);
                            memoryButton.Text = calc.Memo.RecallAll()[index].ToString(); //Update button text
                        }
                    };

                    btnMMinus.Click += (s, ev) =>
                    {
                        if (double.TryParse(textBoxResult.Text, out double value))
                        {
                            calc.Memo.SubtractFromMemory(index, value);
                            memoryButton.Text = calc.Memo.RecallAll()[index].ToString(); //Update button text
                        }
                    };


                    optionPanel.Controls.Add(btnMC);
                    optionPanel.Controls.Add(btnMPlus);
                    optionPanel.Controls.Add(btnMMinus);

                    memoryItemPanel.Controls.Add(memoryButton);
                    memoryItemPanel.Controls.Add(optionPanel);

                    memoryPanel.Controls.Add(memoryItemPanel);
                }
            }
        }


    }
}
