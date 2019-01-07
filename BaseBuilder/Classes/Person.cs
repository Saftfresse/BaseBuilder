using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBuilder.Classes
{
    class Person : GameObject
    {
        class Line
        {
            string text;
            int index;
            bool unlocked;
            bool shown = false;

            public string Text { get => text; set => text = value; }
            public int Index { get => index; set => index = value; }
            public bool Unlocked { get => unlocked; set => unlocked = value; }
            public bool Shown { get => shown; set => shown = value; }
        }

        public Person()
        {
            Line[] lns = new Line[] {
                new Line() { Text = "Hi stranger! Click me to continue...", Index = 0, Unlocked = true },
                new Line() { Text = "This is your Starter Tent!\nIt provides basic Support for you...", Index = 1, Unlocked = true },
                new Line() { Text = "Click the Tent to get additional Info!", Index = 2, Unlocked = true },
                new Line() { Text = "Great!", Index = 3, Unlocked = false },
                new Line() { Text = "New Topic!", Index = 10, Unlocked = false } };
            lines.AddRange(lns);
            breaks.AddRange(new int[] { 1 });
        }

        public enum LineTopics
        {
            Introduction = 0,
            Basics = 10
        }

        public void JumpToTopic(LineTopics topic)
        {
            currentLine = (int)topic;
        }

        List<Line> lines = new List<Line>();
        int currentLine = 0;
        List<int> breaks = new List<int>();
        
        public void UnlockLine(int index)
        {
            lines.Find(x => x.Index == index).Unlocked = true;
        }

        public void UnlockLineAndJumpTo(int index)
        {
            lines.Find(x => x.Index == index).Unlocked = true;
            lines.Find(x => x.Index == index).Shown = true;
            currentLine = index;
        }

        public string CurrentLine()
        {
            return lines[currentLine].Unlocked && !lines[currentLine].Shown?lines[currentLine].Text:string.Empty;
        }

        public void NextLine()
        {
            if(currentLine + 1 < lines.Count) currentLine++;
        }
    }
}
