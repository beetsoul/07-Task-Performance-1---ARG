using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GuessApplicationForm
{
    public partial class Form1 : Form

    {

        string wordToGuess = "computer";
        StringBuilder displayWord = new StringBuilder();
        List<string> wrongGuesses = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void guessBtn_Click(object sender, EventArgs e)
        {

            string guess = guessTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(guess))
            {
                MessageBox.Show("Enter a letter or word!");
                return;
            }

            bool correct = false;

 
            if (guess.Length == 1)
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i].ToString() == guess)
                    {
                        displayWord[i] = wordToGuess[i]; 
                        correct = true;
                    }
                }
            }
            else
            {
                if (guess == wordToGuess)
                {
                    displayWord.Clear();
                    displayWord.Append(wordToGuess);
                    correct = true;
                }
            }

            if (correct)
            {
                label1.Text = displayWord.ToString();

                if (label1.Text == wordToGuess)
                {
                    MessageBox.Show("Correct guess!");
                }
            }
            else
            {
                if (!wrongGuesses.Contains(guess))
                {
                    wrongGuesses.Add(guess);
                    listBox.Items.Add(guess);
                }

                MessageBox.Show("Wrong guess! Try Again.");
            }

            guessTextBox.Clear();
        }
    }
}
