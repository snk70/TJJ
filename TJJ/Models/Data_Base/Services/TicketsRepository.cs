using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentitySample.Models;
using TJJ.Models;




namespace TJJ.Services
{
    public class TicketsRepository : ITicketRepository
    {
        ApplicationDbContext db;
        public TicketsRepository(ApplicationDbContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<tbl_Tickets> Get_All_Tickets()
        {
            return db.Tickets_tbl;
        }

        public IEnumerable<tbl_Tickets> Get_Tickets_BY_UserID(string UserID)
        {
            return db.Tickets_tbl.Where(p => p.Id == UserID);
        }

        public IEnumerable<tbl_Tickets> Get_UnRead_Tickets(bool Un_Read, string UserID)
        {
            return db.Tickets_tbl.Where(p => p.read_ticket == Un_Read &&p.Id==UserID);
        }

        public bool Delete_Ticket(tbl_Tickets tbt)
        {
            try
            {
                db.Tickets_tbl.Remove(tbt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete_Ticket_By_ID(int Ticket_ID)
        {
            try
            {
                Delete_Ticket(db.Tickets_tbl.Find(Ticket_ID));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Dispos_DB()
        {
            try
            {
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Insert_Ticket(tbl_Tickets tbt)
        {
            try
            {
                db.Tickets_tbl.Add(tbt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update_Ticket(tbl_Tickets tbt)
        {
            try
            {
                db.Entry(tbt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<tbl_Tickets> Get_Question_Tickets_By_ID(int AnswerID)
        {
            return db.Tickets_tbl.Where(p => p.ticket_id==AnswerID);
        }

        public IEnumerable<tbl_Tickets> Get_Question_Tickets(tbl_Tickets tbt)
        {
            return db.Tickets_tbl.Where(p => p.ticket_id==tbt.ticket_answer_id);
        }

        public tbl_Tickets Get_Tickets_By_TicketID(int Tickets_ID)
        {
            return db.Tickets_tbl.Find(Tickets_ID);
        }

        public bool Read_All_Tickets()
        {
            try
            {
                var All_Tickets=Get_All_Tickets();
                foreach (var item in All_Tickets)
                {
                    item.read_ticket = true;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
