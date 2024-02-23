using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; set; }
        List<Mail> Inbox { get; set; }
        List<Mail> Archive { get; set; }
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }
        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }

        }
        public bool DeleteMail(string sender)
        {
            Mail mail = Inbox.FirstOrDefault(x => x.Sender == sender);
            if (mail == null)
            {
                return false;
            }
            return Inbox.Remove(mail); 
        }
        public int ArchiveInboxMessages()
        {
            Archive.AddRange(Inbox);
            int count = Inbox.Count;
            Inbox = new List<Mail>();
             
            return count;
        }
        public string GetLongestMessage()
        {
            Mail longest = Inbox.OrderByDescending(x=>x.Body).First();

            return longest.ToString();
        }
        public string InboxView()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Inbox:");    
            foreach(var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
