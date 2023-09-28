namespace LottoModels;

internal class Program
{
    static void Main(string[] args)
    {
       
        User me = new User("Jimi", "Jimi@jimi.com", "1234567");
        LotteryTicket ticket = new LotteryTicket(me);
        ticket.LuckyDipGenerator();
        //ticket.TicketNumbers = new List<int> { -1, 12, 22, 44, 23, 5 };
        foreach (var item in ticket.TicketNumbers)
        {
            Console.WriteLine(item);
        }
    }
}
