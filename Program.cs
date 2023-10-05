namespace LottoModels;

internal class Program
{
    static void Main(string[] args)
    {

        PlayGame game = new PlayGame();


        // NEW Player Jimi is at index 0.
        game.NewPlayer("Jimi", "123456", "jimi@jimi");
        game.NewTicket(game.UsersList[0], 1, 2, 3, 4, 5, 6);

        // Existing Player Jimi at index 0 selects lucky dip.
        game.NewTicket(game.UsersList[0], true);

        // NEW Player Fred is at index 1.
        game.NewPlayer("Fred", "987654321", "fred@fred");
        game.NewTicket(game.UsersList[1], true);

        // TESTING TICKETS
        foreach (LotteryTicket ticket in game.TicketList)
        {
            Console.WriteLine(ticket.ToString()+"\n");
        }

        Console.WriteLine("\n\n*** Let's Draw *** \n\n");

        game.RunDraw();

        foreach (LotteryTicket ticket in game.TicketList)
        {
            Console.WriteLine(ticket.ToString()+"\n");
        }

        //OLD TESTS ///

        //User me = new User("Jimi", "Jimi@jimi.com", "1234567");
        //LotteryTicket ticket = new LotteryTicket(me);
        //ticket.LuckyDipGenerator();
        //ticket.TicketNumbers = new List<int> { -1, 12, 22, 44, 23, 5 };
        //foreach (var item in ticket.TicketNumbers)
        //{
        //    Console.WriteLine(item);
        //}

        //Console.WriteLine(ticket.ToString());
    }
}
