using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJJ.Models;


namespace TJJ
{
    public interface ITicketRepository
    {
        IEnumerable<tbl_Tickets> Get_All_Tickets();

        tbl_Tickets Get_Tickets_By_TicketID(int Tickets_ID);

        IEnumerable<tbl_Tickets> Get_UnRead_Tickets(bool Un_Read,string UserID);

        IEnumerable<tbl_Tickets> Get_Tickets_BY_UserID(string UserID);

        IEnumerable<tbl_Tickets> Get_Question_Tickets_By_ID(int AnswerID);

        IEnumerable<tbl_Tickets> Get_Question_Tickets(tbl_Tickets tbt);

        bool Insert_Ticket(tbl_Tickets tbt);

        bool Update_Ticket(tbl_Tickets tbt);

        bool Delete_Ticket_By_ID(int Ticket_ID);

        bool Delete_Ticket(tbl_Tickets tbt);
        bool Read_All_Tickets();
        bool SaveChanges();
        bool Dispos_DB();

    }
}
