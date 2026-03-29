using System;
using System.Linq;

namespace Lab3
{
    public class Task2
    {
        /// <summary>
        /// Executes Task 2: creating an array of polymorphic Trial objects and sorting them by type.
        /// </summary>
        public static void Execute()
        {
            Trial[] trials = new Trial[]
            {
                new Test("Math", 50),
                new Exam("Physics", "Dr. Smith"),
                new Trial("Physical Education"),
                new FinalExam("Computer Science", "Prof. Johnson", 90),
                new Test("History", 20)
            };

            Console.WriteLine("--- Original Array ---");
            foreach (var trial in trials)
            {
                trial.Show();
            }

            var sortedTrials = trials.OrderBy(t => t.GetType().Name).ToArray();

            Console.WriteLine("\n--- Sorted by Class Type ---");
            foreach (var trial in sortedTrials)
            {
                trial.Show();
            }
        }
    }

    /// <summary>
    /// Base class representing a generic trial.
    /// </summary>
    public class Trial
    {
        protected string subject;

        public Trial(string subject)
        {
            this.subject = subject;
        }

        public virtual void Show()
        {
            Console.WriteLine($"[Trial] Subject: {subject}");
        }
    }

    /// <summary>
    /// Derived class representing a test with a specific number of questions.
    /// </summary>
    public class Test : Trial
    {
        protected int questionsCount;

        public Test(string subject, int questionsCount) : base(subject)
        {
            this.questionsCount = questionsCount;
        }

        public override void Show()
        {
            Console.WriteLine($"[Test] Subject: {subject}, Questions: {questionsCount}");
        }
    }

    /// <summary>
    /// Derived class representing an exam with an examiner.
    /// </summary>
    public class Exam : Trial
    {
        protected string examiner;

        public Exam(string subject, string examiner) : base(subject)
        {
            this.examiner = examiner;
        }

        public override void Show()
        {
            Console.WriteLine($"[Exam] Subject: {subject}, Examiner: {examiner}");
        }
    }

    /// <summary>
    /// Derived class representing a final exam with a minimum passing score.
    /// </summary>
    public class FinalExam : Exam
    {
        protected int minPassingScore;

        public FinalExam(string subject, string examiner, int minPassingScore) : base(subject, examiner)
        {
            this.minPassingScore = minPassingScore;
        }

        public override void Show()
        {
            Console.WriteLine($"[FinalExam] Subject: {subject}, Examiner: {examiner}, Min Score to Pass: {minPassingScore}");
        }
    }
}