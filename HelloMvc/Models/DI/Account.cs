namespace HelloMvc.Models.DI {
    public class Account {
        private ISender _sender;
        public Account(ISender notificationSender)
        {
            _sender = notificationSender;
        }
        public int Id { get; set; }

        public void Deposit(decimal amount) {
            var message = $"You deposited {amount.ToString("C")}";
            _sender.Send(message);


            //var pref = "sms";

            //if (pref == "sms")
            //{
            //    var sender = new SmsSender();
            //    sender.Send(message);
            //}
            //else
            //{
            //    var sender = new EmailSender();
            //    sender.Send(message);
            //}
 
        }

        public void Transfer(decimal amount, string toAccount) {
            var message = $"You Transfer {amount.ToString("C")}";
            _sender.Send(message);


            //var pref = "sms";

            //if (pref == "sms")
            //{
            //    var sender = new SmsSender();
            //    sender.Send(message);
            //}
            //else
            //{
            //    var sender = new EmailSender();
            //    sender.Send(message);
            //}

        }
    }
}
