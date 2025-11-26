namespace Domain
{


    public class Quiz : Space
    {
        public static int playerScore = 0;

        public Quiz(string name, string description) : base(name, description)
        {
        }

        public override string Welcome()
        {
            return "quiz 1";
        }

    }




    public class Quiz2 : Space
    {
        public static int playerScore = 0;

        public Quiz2(String name, string description) : base(name, description)
        {
        }

        public override string Welcome()
        {
            return "quiz2";
        }


    }


    public class Quiz3 : Space
    {
        public static int playerScore = 0;

        public Quiz3(String name, string description) : base(name, description)
        {
        }

        public override string Welcome()
        {
            return "quiz3";
        }


    }
}
