using System;

namespace AOC2015
{
    public interface IStandardMessages
    {
        void ApplicationTitle();

        void SelectDay();

        void ExitApplication();

        void SelectPart();

        void QuestionInputType();

        void ManualInputMessage();

        void ProblemAnswered(String text);

        void StartingProblem();
    }
}