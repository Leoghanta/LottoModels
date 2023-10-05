using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoModels;
internal class PlayGame
{
    public List<User> UsersList = new List<User>();
    public List<LotteryTicket> TicketList = new List<LotteryTicket>();
    public LottoDraw draw = null;


    public void NewPlayer(string name, string phone, string email)
    {
        if (draw != null)
        {
            // Draw has taken place, no more users.
            throw new Exception("Draw has already taken place!");
        }

        try
        {
            User usr = new User(name, email, phone);
            UsersList.Add(usr);
        }
        catch (Exception e)
        {
            throw new Exception (e.Message);   //Caught an exception, throw it back to UI
        }
    }

    public string NewTicket(User usr, int ball1, int ball2, int ball3, int ball4, int ball5, int ball6)
    {
        if (draw != null)
        {
            // Draw has taken place, no more users.
            throw new Exception("Draw has already taken place!");
        }

        try
        {
            List<int> balls = new List<int> { ball1, ball2, ball3, ball4, ball5, ball6 };
            LotteryTicket ticket = new LotteryTicket(usr);
            ticket.TicketNumbers = balls;
            TicketList.Add(ticket);
            return ticket.ToString();
        }
        catch (Exception e)
        {
            throw new Exception (e.Message); // throw this exception back to the UI
        }
    }

    public string NewTicket(User usr, bool luckyDip)
    {
        if (draw != null)
        {
            // Draw has taken place, no more users.
            throw new Exception("Draw has already taken place!");
        }

        try
        {
            LotteryTicket ticket = new LotteryTicket(usr);
            ticket.LuckyDipGenerator();
            TicketList.Add(ticket);
            return ticket.ToString();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message); // throw this exception back to the UI
        }
    }

    public void RunDraw()
    {
        if (draw != null)
        {
            // Draw has taken place, no more users.
            throw new Exception("Draw has already taken place!");
        }

        draw = new LottoDraw();

        // For each ticket in the list, check the numbers and generate a prize.
        foreach (LotteryTicket ticket in TicketList)
        {
            try
            {
                var matches = draw.CheckMatches(ticket);
                ticket.generatePrize(matches, draw.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); //Errors get thrown back to the UI
            }
        }
    }
}
