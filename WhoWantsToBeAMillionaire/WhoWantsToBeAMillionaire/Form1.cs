using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class Form1 : Form
    {
        List<Question> questions = new List<Question>();
        private Random rnd = new Random();
        int level = 0;
        Question currentQuestion;
        bool useRightToMistake;
        int cheetCount;
        Button[] answerBtns;
        Button[] cheetBtns;
        Dictionary<string, string> friends;
        int unburnedAmount, unburnedAmountLevel;

        public Form1()
        {
            InitializeComponent();
            InitializeBtns();
            ReadFile();
            startGame();
            friends = null;
        }

        private void InitializeBtns()
        {
            answerBtns = new Button[] { btnAnswerA, btnAnswerB, btnAnswerC, btnAnswerD };
            cheetBtns = new Button[] { btnCallFriend, btnChangeQuestion, btnFiftyFifty,
                btnPeopleHelp, btnRightToMistake };
        }

        private void ReadFile()
        {
            string path = @"Вопросы.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    questions.Add(new Question(line.Split('\t')));
                }
            }
        }

        private void ShowQuestion(Question q)
        {
            lblQuestion.Text = q.Text;
            btnAnswerA.Text = q.Answers[0];
            btnAnswerB.Text = q.Answers[1];
            btnAnswerC.Text = q.Answers[2];
            btnAnswerD.Text = q.Answers[3];
        }

        private Question GetQuestion(int level)
        {
            var questionsWithLevel = questions.Where(q => q.Level == level).ToList();
            return questionsWithLevel[rnd.Next(questionsWithLevel.Count)];
        }

        private void NextStep()
        {
            foreach (Button btn in answerBtns)
                btn.Enabled = true;
            level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
            if (level == 2)
            {
                btnDeclareFriends.Enabled = false;
                lblSetAmount.Visible = false;
                btnSetAmount.Enabled = false;
            }
        }

        private void EnableCheetBtns()
        {
            foreach (var btn in cheetBtns)
                btn.Enabled = true;
        }

        private void DisableCheetBtns()
        {
            foreach (var btn in cheetBtns)
                btn.Enabled = false;
        }

        private void startGame()
        {
            useRightToMistake = false;
            level = 0;
            NextStep();
            EnableCheetBtns();
            btnDeclareFriends.Enabled = true;
            cheetCount = 0;
            unburnedAmount = 0;
            unburnedAmountLevel = 0;
            lblSetAmount.Visible = true;
            btnSetAmount.Enabled = true;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
            {
                if (level < 15) NextStep();
                else
                {
                    MessageBox.Show($"Ваш выигрыш составил: 3 000 000");
                    startGame();
                }
            }
            else
            {
                
                if (useRightToMistake)
                {
                    MessageBox.Show("Неверный ответ!");
                    button.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Неверный ответ!\nВаш выигрыш составил: " + 
                            (level > unburnedAmountLevel? unburnedAmount : 0).ToString());
                    startGame();
                }
            }
            if (useRightToMistake) useRightToMistake = false;
        }

        private void btnAnswerA_Click(object sender, EventArgs e)
        {
            btnAnswer_Click(sender, e);
        }

        private void btnAnswerB_Click(object sender, EventArgs e)
        {
            btnAnswer_Click(sender, e);
        }

        private void btnAnswerC_Click(object sender, EventArgs e)
        {
            btnAnswer_Click(sender, e);
        }

        private void btnAnswerD_Click(object sender, EventArgs e)
        {
            btnAnswer_Click(sender, e);
        }

        private void btnFiftyFifty_Click(object sender, EventArgs e)
        {
            int count = 0;
            while (count < 2)
            {
                int n = rnd.Next(4);
                int answer = int.Parse(answerBtns[n].Tag.ToString());

                if (answer != currentQuestion.RightAnswer && answerBtns[n].Enabled)
                {
                    answerBtns[n].Enabled = false;
                    count++;
                }
            }
            CheckCheetCount();
            btnFiftyFifty.Enabled = false;
        }

        private void btnChangeQuestion_Click(object sender, EventArgs e)
        {
            level--;
            NextStep();
            btnChangeQuestion.Enabled = false;
            CheckCheetCount();
        }

        private void btnRightToMistake_Click(object sender, EventArgs e)
        {
            useRightToMistake = true;
            btnRightToMistake.Enabled = false;
            CheckCheetCount();
        }
        /// <summary>
        /// Делает неактивными все кнопки подсказок при использовании четырех из них
        /// </summary>
        private void CheckCheetCount()
        {
            if(++cheetCount == 4)
            {
                DisableCheetBtns();
            }
        }
        /// <summary>
        /// Использование подсказки помощь зала
        /// Добавляет к каждому активному ответу информацию о проценте зрителей,
        /// проголосовавших за данный ответ
        /// </summary>
        private void btnPeopleHelp_Click(object sender, EventArgs e)
        {
            CheckCheetCount();
            btnPeopleHelp.Enabled = false;
            List<int> activAnswers = new List<int>();
            foreach (var btn in answerBtns)
                if (btn.Enabled) activAnswers.Add(int.Parse(btn.Tag.ToString()));
            int[] voteResult = GetProbability(activAnswers);
            foreach (var btn in answerBtns)
                btn.Text = $"{btn.Text}: {voteResult[int.Parse(btn.Tag.ToString()) - 1]}%";
        }
        /// <summary>
        /// Возвращает массив вероятностей для четырех ответов
        /// Вероятность правильного ответа падает с ростом сложности
        /// </summary>
        /// <param name="activAnswers">Список кнопок активных ответов</param>
        /// <returns></returns>
        private int[] GetProbability(List<int> activAnswers)
        {
            int percentValue = GetRigthAnswerPercent(activAnswers.Count);
            int residue = 100 - percentValue;
            int[] answersProbability = new int[4];
            answersProbability[currentQuestion.RightAnswer - 1] = percentValue;
            for (int i = 0; i < 4; i++)
            {
                if (answersProbability[i] == 0 && activAnswers.Contains(i + 1))
                {
                    percentValue = (int)(100 / activAnswers.Count + rnd.Next(-level / 2, level / 2));
                    if (percentValue < residue)
                    {
                        answersProbability[i] = percentValue;
                        residue -= percentValue;
                    }
                    else
                    {
                        answersProbability[i] = residue;
                        residue = 0;
                    }
                }
            }
            return answersProbability;
        }
        /// <summary>
        /// Эмуляция процента голосов зрителей за правильный ответ, падает с ростом сложности
        /// </summary>
        /// <param name="answerCount">Количество ответов участвующих в голосовании</param>
        /// <returns>Процент голосов зрителей за правильный ответ</returns>
        private int GetRigthAnswerPercent(int answerCount)
        {
            double power;
            if (answerCount == 4) power = -0.5;//падение от 100 до ~25 за 15 уровней
            else if (answerCount == 3) power = -0.4;//падение от 100 до ~33 за 15 уровней
            else if (answerCount == 2) power = -0.25;//падение от 100 до ~50 за 15 уровней
            else power = 0;
            return (int)(100 * Math.Pow(level, power));
        }

        private void btnCallFriend_Click(object sender, EventArgs e)
        {
            btnCallFriend.Enabled = false;
            if(friends == null)
            {
                MessageBox.Show("Вы не заявили друзей до начала игры" +
                    "\nВоспользуйтесь другой подсказкой");
                return;
            }
            List<int> activAnswers = new List<int>();
            foreach (var btn in answerBtns)
                if (btn.Enabled) activAnswers.Add(int.Parse(btn.Tag.ToString()));
            int[] answerProbability = GetProbability(activAnswers);
            int indexMax = 0;
            int max = 0;
            for (int i = 0; i < 4; i++)
                if (answerProbability[i] > max)
                {
                    max = answerProbability[i];
                    indexMax = i;
                }
            string friendAnswer = currentQuestion.Answers[indexMax];
            var formCallFriend = new FormCallFriend(friends, friendAnswer);
            formCallFriend.ShowDialog();
            CheckCheetCount();
        }

        private void btnDeclareFriends_Click(object sender, EventArgs e)
        {
            var formFriends = new FormFriends();
            var diagResult = formFriends.ShowDialog();
            if (diagResult == DialogResult.OK)
                this.friends = formFriends.friends;
        }

        private void btnSetAmount_Click(object sender, EventArgs e)
        {
            unburnedAmount = int.Parse(lstLevel.SelectedItem.ToString());
            unburnedAmountLevel = 15 - lstLevel.SelectedIndex;
            lblSetAmount.Visible = false;
            btnSetAmount.Enabled = false;
        }
    }
}
